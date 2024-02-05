using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SdkUserBalance  {

	void userBalanceInitialized(int available_currency , int pending_currency , int spent_currency);
	void userBalanceChanged (int available_currency , int pending_currency , int spent_currency);

}
