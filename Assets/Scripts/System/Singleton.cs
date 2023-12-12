using UnityEngine;

namespace System
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning(string.Format("[Singleton] Instance '{0}' already destroyed on application quit. Won't create again - returning null.", typeof(T)));
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError(string.Format("[Singleton] Something went really wrong - there should never be more than 1 singleton! Reopening the scene might fix it."));
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = string.Format("(singleton) {0}", typeof(T));
                            DontDestroyOnLoad(singleton);
                            Debug.Log(string.Format("[Singleton] An instance of {0}  is needed in the scene, so '{1}' was created with DontDestroyOnLoad.", typeof(T), singleton));
                        }
                        else
                        {
                            //Debug.Log(string.Format("[Singleton] Using instance already created: {0}", _instance.gameObject.name));
                        }
                    }

                    return _instance;
                }
            }
        }

        private static bool applicationIsQuitting = false;

        public void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }
}