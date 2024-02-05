using System;

namespace Save
{
   public class CoinsController
   {
      private int m_coins = 0;
      private int MainCoinsInt => LoadInt();
      public string MainCoins => Load();
      private string m_coinsString;
      public void SaveCoins(string coins)
      {
         var coinsInt = Int32.Parse(coins);
         m_coinsString = MainCoins;
         if (m_coinsString == null)
            m_coins = 0 + coinsInt;
         else
         {
            m_coins = MainCoinsInt + coinsInt;
         }

         Save();  
      }
      private void Save()
      {
         SaveManager.Save(GlobalConst.CoinsString, m_coins.ToString());
         SaveManager.Save(GlobalConst.CoinsInt, m_coins);
      }

      private string Load()
      {
         var result = SaveManager.LoadString(GlobalConst.CoinsString);
         if (result == null)
            return result;
         var intResult = Int32.Parse(result);
         if (intResult >= GlobalConst.CoinsK)
         {
            intResult =  intResult / GlobalConst.CoinsDivisorK;
            result = intResult + "k";
         }
         if (intResult >= GlobalConst.CoinsM)
         {
            intResult =  intResult / GlobalConst.CoinsDivisorM;
            result = intResult + "m";
         }
         return result;
      }

      private int LoadInt()
      {
         var result = SaveManager.LoadInt(GlobalConst.CoinsInt);
         return result;
      }
   }
}
