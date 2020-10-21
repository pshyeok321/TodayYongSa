using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLevel : MonoBehaviour
{
    public enum CubeLv
    {
        Lv1,
        Lv2,
        Lv3,
        Lv4,
        Count,
    }
    public CubeLv cubeLv;
    public static CubeLevel Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        //(int)cubeLv = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
