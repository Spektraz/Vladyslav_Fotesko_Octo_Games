using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeductUserBalanceCallbackProxy  : AndroidJavaProxy {

	private SdkDeductCallback sdkDeductCallback = null;

	public DeductUserBalanceCallbackProxy(SdkDeductCallback sdkDeductCallback) : base("com.ayetstudios.publishersdk.interfaces.DeductUserBalanceCallback") { 
		this.sdkDeductCallback = sdkDeductCallback;
	}

	public void success() {

		if (this.sdkDeductCallback != null)
			sdkDeductCallback.deductSuccess();

	}
	public void failed() {

		if (this.sdkDeductCallback != null)
			sdkDeductCallback.deductFailed();
	}
}