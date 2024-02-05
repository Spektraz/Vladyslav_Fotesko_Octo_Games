using UnityEngine;

namespace System
{
   public static class SaveManager 
   {
      public static void Save(string key, string saveData)
      {
         PlayerPrefs.SetString(key, saveData);
      }
      public static void Save(string key, int saveData)
      {
         PlayerPrefs.SetInt(key, saveData);
      }
      public static int LoadInt(string key)
      {
         if (PlayerPrefs.HasKey(key))
         {
            var loadedString = PlayerPrefs.GetInt(key);
            return loadedString;
         }

         return 0;
      }
      public static string LoadString(string key)
      {
         if (PlayerPrefs.HasKey(key))
         {
            string loadedString = PlayerPrefs.GetString(key);
            return loadedString;
         }

         return null;
      }
   }
}
