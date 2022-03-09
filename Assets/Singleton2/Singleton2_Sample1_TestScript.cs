using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton2.Sample1
{
    public class TestScript : MonoBehaviour
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("TestMenu/Singleton2/GetMapDat_10205")]
        public static void GetMapData_10205()
        {
            TableDataManager.Instance.GetMapData(10205);
        }
#endif

        private void Start()
        {
            TableDataManager.Instance.GetMapData(10205);
        }
    }
}
