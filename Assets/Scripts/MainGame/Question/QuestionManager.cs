using System;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.Question
{
    public class QuestionManager
    {
        private Dictionary<int, QuestionItem> m_itemsCache = new Dictionary<int, QuestionItem>();
        public QuestionItem TryGetItem(int id, bool useCache = true)
        {
            if (useCache && m_itemsCache.ContainsKey(id))
                return m_itemsCache[id];
            
            var path = $"{GlobalConst.QuestionItems}/item_{id}";
            var item = Resources.Load<QuestionItem>(path);
            if (item != null && useCache)
                m_itemsCache.Add(id, item);
            else
            {
                var customQuestion = SaveManager.Load(GlobalConst.QuestionKey);
                if (customQuestion == null)
                    return null;
                if (customQuestion.ID != id)
                    return item;
                if (!ApplicationContainer.Instance.ResultGame.IsSave)
                {
                    ApplicationContainer.Instance.ResultGame.IsSave = true;
                    m_itemsCache.Add(id, customQuestion);
                }
                if (customQuestion != null)
                    return customQuestion;
            }
            return item;
        }

        public void ResetIsUse()
        {
            CountItem();
            foreach (var var in m_itemsCache)
            {
                var.Value.IsUse = false;
            }
        }
        public int CountItem()
        {
            var result = 0;
            TryGetItem(result);
            for (var i = 0; i < m_itemsCache.Count; i++)
            {
                result++;
                TryGetItem(result);
            }
            return result;
        }
        public void TryCreateNewItem(QuestionItem questionItem)
        {
            SaveManager.Save(GlobalConst.QuestionKey, questionItem);
        }
    }
}   
