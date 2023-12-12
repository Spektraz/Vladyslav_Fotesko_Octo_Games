using System;

namespace Name
{
   public class NameController
   {
      private string m_mainName = null;
      public string MainName => Load();

      public void SaveName(string mainName)
      {
         m_mainName = mainName;
         Save();  
      }
      private void Save()
      {
         SaveManager.Save(GlobalConst.NameKey, m_mainName);
      }

      private string Load()
      {
         return SaveManager.LoadString(GlobalConst.NameKey) ?? m_mainName;
      }
   }
}
