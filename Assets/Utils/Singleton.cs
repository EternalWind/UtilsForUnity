using UnityEngine;

using TBase = UnityEngine.MonoBehaviour;

namespace Utils
{
    public abstract class SingletonBase<TSelf> : TBase
        where TSelf : SingletonBase<TSelf>
    {
        protected static TSelf m_Instance = null;

        private void Awake()
        {
            if (m_Instance != null)
            {
                Debug.Log("Destroying " + name + "! You cannot have more than one singleton at the same time!");
                Destroy(gameObject);
            }

            m_Instance = (TSelf)this;

            if (OnAwake())
                DontDestroyOnLoad(gameObject);
        }

        protected abstract bool OnAwake();
    }

    public abstract class AutoConstructSingleton<TSelf> : SingletonBase<TSelf>
        where TSelf : AutoConstructSingleton<TSelf>
    {
        public static TSelf Instance
        {
            get
            {
                if (m_Instance == null || m_Instance.gameObject == null)
                {
                    var obj = new GameObject();
                    obj.name = typeof(TSelf).Name;
                    obj.AddComponent<TSelf>();
                }

                return m_Instance;
            }
        }
    }

    public abstract class Singleton<TSelf> : SingletonBase<TSelf>
        where TSelf : Singleton<TSelf>
    {
        public static TSelf Instance
        {
            get
            {
                return m_Instance;
            }
        }
    }
}