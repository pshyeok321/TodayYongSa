using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    
    

    public List<CubeLevel> cubes = new List<CubeLevel>();
    public List<CubeLevel> gCubes = new List<CubeLevel>();

    public List<Transform> transList = new List<Transform>();

    private void Awake()
    {
        cubes.Clear();
        gCubes.Clear();
        transList.Clear();

        
        cubes.AddRange(GameObject.Find("CubeManager").GetComponentsInChildren<CubeLevel>());
        gCubes.AddRange(GameObject.Find("CubeManager").GetComponentsInChildren<CubeLevel>());
        transList.AddRange(GameObject.Find("TransManager").GetComponentsInChildren<Transform>());
        transList.Remove(transList[0]);


        cubes.Sort(delegate (CubeLevel c1, CubeLevel c2) { return c1.cubeLv.CompareTo(c2.cubeLv); });
        cubes.Reverse();
    }


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<cubes.Count; ++i)
        {
            if (cubes[i].isActiveAndEnabled)
            {
                cubes.Clear();
                cubes.AddRange(GameObject.Find("CubeManager").GetComponentsInChildren<CubeLevel>());
                cubes.Sort(delegate (CubeLevel c1, CubeLevel c2) { return c1.cubeLv.CompareTo(c2.cubeLv); });
                cubes.Reverse();
            }

        }
    }
    public void SortButton()
    {
        for(int i=0; i<cubes.Count; ++i)
        {
            cubes[i].transform.position = transList[i].transform.position;
        }
    }
}
