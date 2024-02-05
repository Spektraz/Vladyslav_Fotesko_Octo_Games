using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class UserBalanceProxy : AndroidJavaProxy {

	private SdkUserBalance sdkUserBal = null;

	public UserBalanceProxy(SdkUserBalance sdkUserBalance) : base("com.ayetstudios.publishersdk.interfaces.UserBalanceCallback") { 
		this.sdkUserBal = sdkUserBalance;
	}

	public void userBalanceChanged(AndroidJavaObject data) {

		Debug.Log("UserBalanceProxy::userBalanceChanged");

		int available_currency = -1;
		int pending_currency = -1;
		int spent_currency = -1;			

		if (data != null) {

			try{
				available_currency = data.Get<int>("availableBalance");
				pending_currency = data.Get<int>("pendingBalance");
				spent_currency = data.Get<int>("spentBalance");				
			}
			catch{
				available_currency = -1;
				pending_currency = -1;
				spent_currency = -1;	
			}

		}
		sdkUserBal.userBalanceChanged (available_currency, pending_currency, spent_currency);

	}
	public void userBalanceInitialized(AndroidJavaObject data) {

		Debug.Log("UserBalanceProxy::userBalanceInitialized");

		int available_currency = -1;
		int pending_currency = -1;
		int spent_currency = -1;			

		if (data != null) {

			try{
				available_currency = data.Get<int>("availableBalance");
				pending_currency = data.Get<int>("pendingBalance");
				spent_currency = data.Get<int>("spentBalance");				
			}
			catch{
				available_currency = -1;
				pending_currency = -1;
				spent_currency = -1;	
			}
		
		}

		sdkUserBal.userBalanceInitialized (available_currency, pending_currency, spent_currency);

	}
}