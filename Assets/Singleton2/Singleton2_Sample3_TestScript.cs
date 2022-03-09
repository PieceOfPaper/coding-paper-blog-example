using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton2_Sample3_TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        new GameObject("I Like Singleton!");
    }
}
