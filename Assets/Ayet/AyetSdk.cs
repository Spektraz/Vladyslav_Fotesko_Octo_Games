using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices; 
using AOT; 
using System;

public class AyetSdk {

	#if UNITY_IOS  
	static SdkUserBalance sdkBalanceCallback = null;
	static SdkDeductCallback sdkDeductCallback = null;
	#endif

	#if UNITY_IOS     
	[DllImport("__Internal")]
	private static extern void sdkInit(string appKey , string externalUserId , DelegateMessage callback);

	private delegate void DelegateMessage(int availBalance , int pendBalance , int spentBalance);

	[MonoPInvokeCallback(typeof(DelegateMessage))] 
	private static void delegateMessageReceived(int availBalance , int pendBalance , int spentBalance) {
		//Debug.Log("AyetSdkIos::delegateMessageReceived => Message received available: " + availBalance.ToString());
		if (sdkBalanceCallback != null) {
			sdkBalanceCallback.userBalanceInitialized (availBalance , pendBalance , spentBalance);
		}
	}

	[DllImport("__Internal")]
	private static extern void sdkDeduct(int amount , DeductCallbackMessage callback);

	private delegate void DeductCallbackMessage(string status);

	[MonoPInvokeCallback(typeof(DeductCallbackMessage))] 
	private static void deductMessageReceived(string status) {
		//Debug.Log("AyetSdkIos::deductMessageReceived => Message received: " + status);
		if (sdkDeductCallback != null) {
			if (status.Equals ("success")) {
				sdkDeductCallback.deductSuccess ();
			} else {
				sdkDeductCallback.deductFailed ();
			}

		}
		else{
			sdkDeductCallback.deductFailed();
		}
	}

	[DllImport("__Internal")]
	private static extern void sdkOfferwall(string adslotName);

	[DllImport("__Internal")]
	private static extern int getAvailableBalance();
	[DllImport("__Internal")]
	private static extern int getPendingBalance();
	[DllImport("__Internal")]
	private static extern int getSpentBalance();

	#endif  

	public static void init(string appKey , string externalUserId ,SdkUserBalance sdkUserBalance ){
		
		Debug.Log ("AyetSdk::init  appKey:" + appKey + "  external user id: " + externalUserId);

		#if UNITY_ANDROID
		var extUserId = "";
		if (string.IsNullOrEmpty (externalUserId))
			extUserId = "";
		else
			extUserId = externalUserId;
			

		UserBalanceProxy userBalanceProxy = new UserBalanceProxy (sdkUserBalance);


		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                AndroidJavaObject ja = jo.Call<AndroidJavaObject>("getApplication");
                using (var plugin = new AndroidJavaClass("com.ayetstudios.publishersdk.AyetSdk"))
                {
                    if (plugin != null)
                    {
                        plugin.CallStatic("init", ja, extUserId, userBalanceProxy, appKey);
                    }
                };
            }

		}	
		#endif

		#if UNITY_IOS
		if (sdkUserBalance != null)
		sdkBalanceCallback = sdkUserBalance;

		if (string.IsNullOrEmpty (appKey)) {
			Debug.Log ("AyetSdk::init => Error: appKey is null or empty.");
			return;
		}

		var extUserId = "";
		if (string.IsNullOrEmpty (externalUserId))
		extUserId = "";
		else
		extUserId = externalUserId;


		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			sdkInit(appKey , extUserId , delegateMessageReceived);
		}
		#endif
	}

	public static void showOfferwall(string adslotName){

		#if UNITY_ANDROID
		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                AndroidJavaObject ja = jo.Call<AndroidJavaObject>("getApplication");
                using (var plugin = new AndroidJavaClass("com.ayetstudios.publishersdk.AyetSdk"))
                {
                    if (plugin != null)
                    {
                        plugin.CallStatic("showOfferwall", ja, adslotName);
                    }
                };
            }
		}	
		#endif

		#if UNITY_IOS
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
        sdkOfferwall (adslotName);
		}
		#endif
	}

	public static void deductUserBalance(int amount , SdkDeductCallback sdkDeductCall){

		Debug.Log ("AyetSdk::deductUserBalance");

		#if UNITY_ANDROID
		DeductUserBalanceCallbackProxy deductUserCallbackProxy = new DeductUserBalanceCallbackProxy (sdkDeductCall);


		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                AndroidJavaObject ja = jo.Call<AndroidJavaObject>("getApplication");
                using (var plugin = new AndroidJavaClass("com.ayetstudios.publishersdk.AyetSdk"))
                {
                    if (plugin != null)
                    {
                        plugin.CallStatic("deductUserBalance", ja, amount, deductUserCallbackProxy);
                    }
                };
            }

		}	
		#endif

		#if UNITY_IOS
		if (sdkDeductCall != null)
			sdkDeductCallback = sdkDeductCall;

		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			sdkDeduct(amount , deductMessageReceived);
		}
		#endif
	}

	public static int getAvailableCurrency(){

		#if UNITY_ANDROID
				using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
					using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						AndroidJavaObject ja = jo.Call<AndroidJavaObject>("getApplication");
						using (var plugin = new AndroidJavaClass("com.ayetstudios.publishersdk.AyetSdk"))
						{
							if (plugin != null)
							{
								return plugin.CallStatic<int>("getAvailableBalance", ja);
							}
							else
							{
								return -1;
							}
						};
					}

				}
		#endif
		#if UNITY_IOS

				if (Application.platform == RuntimePlatform.IPhonePlayer) {
					return getAvailableBalance();
				}
				else{
					return -1;
				}
		#endif

		return -1;
	}

	public static int getPendingCurrency(){

		#if UNITY_ANDROID
				using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
					using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						AndroidJavaObject ja = jo.Call<AndroidJavaObject>("getApplication");
						using (var plugin = new AndroidJavaClass("com.ayetstudios.publishersdk.AyetSdk"))
						{
							if (plugin != null)
							{
								return plugin.CallStatic<int>("getPendingBalance", ja);
							}
							else
							{
								return -1;
							}
						};
					}
				}	
		#endif

		#if UNITY_IOS
				if (Application.platform == RuntimePlatform.IPhonePlayer) {
					return getPendingBalance();
				}
				else{
					return -1;
				}
		#endif

		return -1;
	}
	public static int getSpentCurrency(){

		#if UNITY_ANDROID
				using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
					using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						AndroidJavaObject ja = jo.Call<AndroidJavaObject>("getApplication");
						using (var plugin = new AndroidJavaClass("com.ayetstudios.publishersdk.AyetSdk"))
						{
							if (plugin != null)
							{
								return plugin.CallStatic<int>("getSpentBalance", ja);
							}
							else
							{
								return -1;
							}
						};
					}

				}	
		#endif

		#if UNITY_IOS
				if (Application.platform == RuntimePlatform.IPhonePlayer) {
					return getSpentBalance();
				}
				else{
					return -1;
				}
		#endif

		return -1;
	}
}
