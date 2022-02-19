using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton1.Sample1
{
    public class Item
    {
        public int ItemID;
        public string ItemName;

    }

    public class ItemInventory
    {
        static ItemInventory m_Instance = null;
        public static ItemInventory Instance
        {
            get
            {
                if (m_Instance == null) m_Instance = new ItemInventory();
                return m_Instance;
            }
        }

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

    public class PlayerBehaviour : MonoBehaviour
    {
        private void Start()
        {
            var item = ItemInventory.Instance.GetItem(1000);
            Debug.Log(item.ItemName);
        }
    }
}
