using System;
using System.Collections;
using Assets.Scripts.UI.Window;
using Ui.Panel;
using UnityEngine;

namespace Ui
{
    public class ObjectWindow : MonoBehaviour, IWindow
    {

        public virtual bool IsModal { get { return true; } }

        public virtual void Close()
        {
            ApplicationContainer.Instance.EventHolder.OnChangeStateWindow(this);
            gameObject.SetActive(false);
        }

        public virtual void Initialize(IPanel parent)
        {

        }

        public virtual void Initialize()
        {
            
        }

        public virtual void Initialize(string message, Action onYes, Action onNo)
        {
                
        }

        public virtual void Initialize(string message, Action onOk)
        {

        }
        
        public virtual void Initialize(bool isOpenedFromMap)
        {

        }

        public virtual void Show()
        {
            ApplicationContainer.Instance.EventHolder.OnChangeStateWindow(this);
            
            gameObject.SetActive(true);
										 
        }
        
        public virtual void Show(Action onWindowClosed)
        {
            ApplicationContainer.Instance.EventHolder.OnChangeStateWindow(this);
            //ApplicationContainer.Instance.EventHolder.NeedRefreshRewardAds();
            
            gameObject.SetActive(true);
        }
        
        public virtual void Show(bool isOpenedFromMap)
        {
            ApplicationContainer.Instance.EventHolder.OnChangeStateWindow(this);
            //ApplicationContainer.Instance.EventHolder.NeedRefreshRewardAds();
            
            gameObject.SetActive(true);
        }
        
        public virtual void Show(bool isOpenedFromMap, Action onClosedOrTriggered)
        {
            ApplicationContainer.Instance.EventHolder.OnChangeStateWindow(this);
            //ApplicationContainer.Instance.EventHolder.NeedRefreshRewardAds();
            
            gameObject.SetActive(true);
        }
        
        
        public virtual void Show(string headerText, string messageText, Action onOkAction, Action onCancelAction)
        {
            ApplicationContainer.Instance.EventHolder.OnChangeStateWindow(this);
            
            gameObject.SetActive(true);
        }

        protected void ScaleTo(Vector2 scale, float time, Action onFinish = null)
        {
            StartCoroutine(Scale(scale, time, onFinish));
        }
        protected void ScaleTo(Transform objectScale, Vector2 scale, float time, Action onFinish = null)
        {
            StartCoroutine(Scale(objectScale, scale, time, onFinish));
        }

      

        private IEnumerator Scale(Vector2 scale, float time, Action onFinish)
        {
             bool isScale = true;
            float distance = Vector2.Distance(transform.localScale, scale);
            float speed = distance / time;
            while (isScale)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(scale.x, scale.y, transform.localScale.z), speed * Time.deltaTime);
                if (new Vector2(transform.localScale.x, transform.localScale.y)== scale)
                {
                    isScale = false;
                    if(onFinish != null)
                    {
                        onFinish();
                    }
                }
                yield return null;
            }
        }
        private IEnumerator Scale(Transform obj, Vector2 scale, float time, Action onFinish)
        {
            bool isScale = true;
            float distance = Vector2.Distance(obj.localScale, scale);
            float speed = distance / time;
            while (isScale)
            {
                obj.localScale = Vector3.MoveTowards(obj.localScale, new Vector3(scale.x, scale.y, obj.localScale.z), speed * Time.deltaTime);
                if (new Vector2(obj.localScale.x, obj.localScale.y) == scale)
                {
                    isScale = false;
                    if (onFinish != null)
                    {
                        onFinish();
                    }
                }
                yield return null;
            }
        }
    }
}
