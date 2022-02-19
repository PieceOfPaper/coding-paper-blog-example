using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton1.Sample3
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
    }

    public class Item
    {
        public int ItemID { get; }
        public string ItemName { get; }

    }

    public class ItemInventory : MonoBehaviourSingletonTemplate<ItemInventory>
    {
        public Item GetItem(int itemID)
        {
            //TODO
            return default;
        }

        public bool AddItem(Item item)
        {
            //TODO
            return default;
        }
    }
}
