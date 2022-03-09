using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton2.Sample4
{
    public class Singleton2_Sample4_TestScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            CameraManager.Instance.GetMainCamera();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
