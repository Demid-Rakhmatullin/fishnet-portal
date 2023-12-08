using UnityEngine;

namespace Assets.Game.Scripts
{
    class MonoSingleton<T> : MonoBehaviour 
        where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType(typeof(T), true) as T;

                    if (_instance == null)
                    {                       
                        Debug.LogWarning($"Can't find object of type {typeof(T)} on scene.");                        
                    }
                }
                return _instance;
            }
        }
    }
}
