using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton3.Sample1
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

        public IEnumerable<ItemData> GetItemList() => m_DicItems.Values;

        public void AddItem(ItemData item)
        {
            if (m_DicItems.ContainsKey(item.UID) == true)
                return;

            m_DicItems.Add(item.UID, item);

            UIManager.Instance.GetUI<UIItemInventory>().UpdateList();
            EffectManager.Instance.PlayEffect("GetItem_01", PlayerManager.Instance.Position);
            PlayerManager.Instance.UpdatePlayerSkin();
        }

        public void RemoveItem(ItemData item)
        {
            if (m_DicItems.ContainsKey(item.UID) == false)
                return;

            m_DicItems.Remove(item.UID);

            UIManager.Instance.GetUI<UIItemInventory>().UpdateList();
            EffectManager.Instance.PlayEffect("DelItem_01", PlayerManager.Instance.Position);
            PlayerManager.Instance.UpdatePlayerSkin();
        }
    }

    public class PlayerManager : SingletonTemplate<PlayerManager>
    {
        public Vector3 Position => Vector3.zero;
        public int SkinID => 0;

        public void UpdatePlayerSkin()
        {
            var skinData = SkinManager.Instance.GetSkinData(SkinID);
            if (skinData == null)
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
        public void UpdateList() { }
    }

    public class SkinData { }
    public class SkinManager : SingletonTemplate<SkinManager>
    {
        public SkinData GetSkinData(int skinID) { return default; }
    }
}