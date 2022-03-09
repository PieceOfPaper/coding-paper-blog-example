using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Singleton2.Sample4
{
    public class MonoBehaviourEventListener : MonoBehaviour
    {
        static MonoBehaviourEventListener m_Instance = null;

        public static MonoBehaviourEventListener Instance
        {
            get
            {
#if UNITY_EDITOR
                if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode == false)
                    return null;
#endif

                if (m_Instance == null)
                {
                    var obj = new GameObject("MonoBehaviourEventListener");
                    m_Instance = obj.AddComponent<MonoBehaviourEventListener>();
                }
                return m_Instance;
            }
        }

        public System.Action OnUpdateEvent;
        public System.Action OnLateUpdateEvent;


        private void Update()
        {
            OnUpdateEvent?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdateEvent?.Invoke();
        }
    }
}
