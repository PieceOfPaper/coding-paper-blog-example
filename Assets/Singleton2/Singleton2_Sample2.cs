using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton2.Sample2
{
    public class MonoBehaviourSingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T m_Instance = null;

        public static T Instance
        {
            get
            {
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

    public class CameraManager : MonoBehaviourSingletonTemplate<CameraManager>
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("TestMenu/Singleton2/Get Main Camera")]
        public static void GetMapData_10205()
        {
            CameraManager.Instance.GetMainCamera();
        }
#endif

        private void Start()
        {
            Invoke("OnOneSec", 1f);
        }

        private void Update()
        {
            Camera.main.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        private void OnDestroy()
        {
            if (Instance != this) return;
            Destroy(Camera.main.gameObject);
        }

        private void OnOneSec()
        {
            Debug.Log(Camera.main.transform.position);
        }

        public Camera GetMainCamera() => Camera.main;
    }
}
