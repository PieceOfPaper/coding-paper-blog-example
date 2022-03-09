using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton3.Sample2
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

    public class MapData
    {
        //TODO
    }

    public class ItemData
    {
        public long UID;
        public int ID;
    }

    public class SkinData { }

    public class TableDataManager : SingletonTemplate<TableDataManager>
    {
        public MapData GetMapData(int mapID)
        {
            //TODO
            return default;
        }
    }

    public class ItemInventory : SingletonTemplate<ItemInventory>
    {
        Dictionary<long, ItemData> m_DicItems = new Dictionary<long, ItemData>();

        public System.Action OnAddItemEvent;
        public System.Action OnRemoveItemEvent;


        public IEnumerable<ItemData> GetItemList() => m_DicItems.Values;

        public void AddItem(ItemData item)
        {
            if (m_DicItems.ContainsKey(item.UID) == true)
                return;

            m_DicItems.Add(item.UID, item);
            OnAddItemEvent?.Invoke();
        }

        public void RemoveItem(ItemData item)
        {
            if (m_DicItems.ContainsKey(item.UID) == false)
                return;

            m_DicItems.Remove(item.UID);
            OnRemoveItemEvent?.Invoke();
        }
    }

    public class PlayerManager : SingletonTemplate<PlayerManager>
    {
        public Vector3 Position => Vector3.zero;
        public int EquippedSkinID => 0;

        public Dictionary<int, SkinData> m_DicSkins = new Dictionary<int, SkinData>();

        public void UpdatePlayerSkin()
        {
            SkinData skinData = null;
            if (m_DicSkins.TryGetValue(EquippedSkinID, out skinData) == false)
            {
                ItemInventory.Instance.AddItem(new ItemData() { UID = 1, ID = 2 });
            }
        }
    }

    public class UIManager : SingletonTemplate<UIManager>
    {
        public T GetUI<T>() { return default; }
    }

    public class EffectManager : SingletonTemplate<EffectManager>
    {
        public void PlayEffect(string effectName, Vector3 pos) { }
    }

    public class UIItemInventory : MonoBehaviour
    {
        private void OnEnable()
        {
            ItemInventory.Instance.OnAddItemEvent += OnAddItem;
            ItemInventory.Instance.OnAddItemEvent += OnRemoveItem;
            UpdateList();
        }

        private void OnDisable()
        {
            ItemInventory.Instance.OnAddItemEvent -= OnAddItem;
            ItemInventory.Instance.OnAddItemEvent -= OnRemoveItem;
        }

        void OnAddItem()
        {
            if (this == null) return;

            UpdateList();
        }

        void OnRemoveItem()
        {
            if (this == null) return;

            UpdateList();
        }

        public void UpdateList() { }
    }

    public class PlayerController : MonoBehaviour
    {
        private void OnEnable()
        {
            ItemInventory.Instance.OnAddItemEvent += OnAddItem;
            ItemInventory.Instance.OnAddItemEvent += OnRemoveItem;
            PlayerManager.Instance.UpdatePlayerSkin();
        }

        private void OnDisable()
        {
            ItemInventory.Instance.OnAddItemEvent -= OnAddItem;
            ItemInventory.Instance.OnAddItemEvent -= OnRemoveItem;
        }

        void OnAddItem()
        {
            if (this == null) return;

            EffectManager.Instance.PlayEffect("GetItem_01", transform.position);
            PlayerManager.Instance.UpdatePlayerSkin();
        }

        void OnRemoveItem()
        {
            if (this == null) return;

            EffectManager.Instance.PlayEffect("DelItem_01", transform.position);
            PlayerManager.Instance.UpdatePlayerSkin();
        }
    }
}