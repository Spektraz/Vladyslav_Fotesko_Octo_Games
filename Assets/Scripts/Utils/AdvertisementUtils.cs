using UnityEngine;

namespace Utils
{
    public class AdvertisementUtils : MonoBehaviour , SdkUserBalance  , SdkDeductCallback  
    {
        
        
        public void userBalanceInitialized (int available_currency, int pending_currency, int spent_currency)
        {
            
            Debug.Log("ExampleScript::userBalanceInitialized => available_currency: " + available_currency.ToString() + "  pending_currency: "+pending_currency.ToString() + "  spent_currency: " + spent_currency.ToString() );
        }

        public void userBalanceChanged (int available_currency, int pending_currency, int spent_currency){

            Debug.Log("ExampleScript::userBalanceChanged => available_currency: " + available_currency.ToString() + "  pending_currency: "+pending_currency.ToString() + "  spent_currency: " + spent_currency.ToString() );
        }

        public void deductSuccess (){

            Debug.Log ("ExampleScript::deductSuccess");
        }

        public void deductFailed (){

            Debug.Log ("ExampleScript::deductFailed");
        }

        void Start () {
          
#if UNITY_IOS
            AyetSdk.init ("1818ff9901debda6632887e2539b57df ", "2>", this);
        #endif
            
        #if UNITY_ANDROID
            AyetSdk.init ("700d3c346cf8bc802465980ce5728ddc", "1", this);
        #endif
          
        }

        public void ShowOffer()
        {
            AyetSdk.showOfferwall("Coins");
            
        }
        // void Update () {
        //
        //     if (Input.touchCount == 1) {
        //
        //         Touch touch = Input.touches [0];
        //
        //         if (touch.phase == TouchPhase.Ended) {
        //
        //             if (Input.GetTouch (0).position.y > (Screen.height/2)) {
        //                 //sdk initialization
        //                 AyetSdk.init ("abcde123abcde123abcde123", "user_id_123", this);
        //
        //             } else {
        //
        //                 if (Input.GetTouch (0).position.x < (Screen.width/3)) {
        //                     //show offerwall
        //                     AyetSdk.showOfferwall("offerwall adslot name");
        //                 }
        //                 else if(Input.GetTouch (0).position.x > ((Screen.width/3)*2)){
        //                     //show user current balance
        //                     Debug.Log ("ExampleScript  Available currency: " + AyetSdk.getAvailableCurrency());
        //                     Debug.Log ("ExampleScript  Pending currency: " + AyetSdk.getPendingCurrency ());
        //                     Debug.Log ("ExampleScript  Spent currency: " + AyetSdk.getSpentCurrency ());
        //                 }
        //                 else {
        //                     int amount = 1;
        //                     //deduct balance
        //                     AyetSdk.deductUserBalance (amount, this);
        //                 }
        //             }
        //         }
        //     }

    }
}
