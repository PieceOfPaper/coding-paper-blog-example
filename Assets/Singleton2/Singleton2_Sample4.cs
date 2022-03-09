using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton2.Sample4
{
    public class SingletonTemplate<T> where T : class, new()
    {
        static T m_Instance = null;

        public static T Instance
        {
            get
            {
                if (m_Instance == null) m_Instance = new T();

                return m_Instance;
            }
        }

    }

    public class MonoBehaviourSingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T m_Instance = null;

        public static T Instance
        {
            get
            {
#if UNITY_EDITOR
                if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode == false)
                    return null;
#endif
                if (m_Instance == null)
                {
                    var obj = new GameObject(typeof(T).Name);
                    m_Instance = obj.AddComponent<T>();
                }
                return m_Instance;
            }
        }

        protected void Awake()
        {
            if (m_Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }

    public class CameraManager : SingletonTemplate<CameraManager>
    {
        public CameraManager()
        {
            if (MonoBehaviourEventListener.Instance != null)
            {
                MonoBehaviourEventListener.Instance.OnUpdateEvent += OnMonoBehaviourUpdate;
            }
        }

        private void OnMonoBehaviourUpdate()
        {
            Camera.main.transform.Translate(Vector3.forward * Time.deltaTime);
            Debug.Log(Camera.main.transform.position);
        }

        public Camera GetMainCamera() => Camera.main;
    }
}