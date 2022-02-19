using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton1.Sample2
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

    public class Item
    {
        public int ItemID { get; }
        public string ItemName { get; }

    }

    public class ItemInventory : SingletonTemplate<ItemInventory>
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
