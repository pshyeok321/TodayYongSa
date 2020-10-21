using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTagSystem : MonoBehaviour
{
    public CubeLevel cb = null;

    public List<MeshRenderer> _mr = new List<MeshRenderer>();


    Vector3 mOffset;
    float mZCoord;
    public bool IsMouseUp = false;

    void Start()
    {
        _mr.Clear();

        cb = GetComponent<CubeLevel>();

        _mr.AddRange(gameObject.GetComponentsInChildren<MeshRenderer>());


        for(int i=0; i<_mr.Count; i++)
            _mr[i].enabled = false; // 메시랜더러 다 끈 상태로


        for(int i=0; i<(int)CubeLevel.CubeLv.Count; i++) // 자녀의 갯수만큼 for 돌리면서 해당 오브젝트의 해등 레벨꺼만 킴.
            if(i == (int)cb.cubeLv)
                _mr[i].enabled = true;                

    }



    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;


        mOffset = gameObject.transform.position - GetMouseWorldPos();


        IsMouseUp = false;
    }
    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;

    }
    private void OnMouseUp()
    {
        IsMouseUp = true;
        transform.position = GetMouseWorldPos() + mOffset;



    }

    private void OnTriggerStay(Collider other)
    {
        if (IsMouseUp && other.gameObject.tag == "Cube")
        {
            //int otherCube = (int)other.gameObject.GetComponent<CubeLevel>().cubeLv;

            CubeLevel.CubeLv _cbLv = other.gameObject.GetComponent<CubeLevel>().cubeLv;
            if(_cbLv == cb.cubeLv) // 부딪힌 두 큐브가 같은 큐브면
            {
                IsMouseUp = false; // bool장난놀이
                other.gameObject.SetActive(false); // 부딪혀진 애 꺼줌.

                for(int i=0; i<(int)CubeLevel.CubeLv.Count; i++)
                {
                    if ((int)cb.cubeLv == i)
                    {
                        _mr[i].enabled = false;
                        _mr[i + 1].enabled = true;
                        return;
                    }
                }
                return;
                #region joo

                /* for(int j=0; j<(int)CubeLevel.CubeLv.Count; j++)
                           if (j == (int)cb.cubeLv)
                               _mr[j].enabled = true; */
                //    if (cb.cubeLv == CubeLevel.CubeLv.Lv1) // 
                //    {
                //        for (int i = 0; i < _mr.Count; i++)
                //            _mr[i].enabled = false;

                //        for (int i = 0; i < (int)CubeLevel.CubeLv.Count; i++)
                //            if (i == (int)cb.cubeLv)
                //                _mr[i].enabled = true;
                //        return;
                //    }
                //}
                //if (otherCube == (int)cb.cubeLv)
                //{
                //  //  IsCombine = true;
                //    IsMouseUp = false;
                //    other.gameObject.SetActive(false);

                //    if ((int)cb.cubeLv == 0)
                //    {
                //        cb.cubeLv = CubeLevel.CubeLv.Lv2;
                //        for (int i = 0; i < _mr.Count; i++)
                //            _mr[i].enabled = false;

                //        for (int i = 0; i < (int)CubeLevel.CubeLv.Count; i++)
                //            if (i == (int)cb.cubeLv)
                //                _mr[i].enabled = true;
                //        return;
                //    }
                //    if ((int)cb.cubeLv == 1)
                //    {
                //        cb.cubeLv = CubeLevel.CubeLv.Lv3;
                //        for (int i = 0; i < _mr.Count; i++)
                //        {
                //            _mr[i].enabled = false;
                //        }

                //        for (int i = 0; i < (int)CubeLevel.CubeLv.Count; i++)
                //        {
                //            if (i == (int)cb.cubeLv)
                //            {
                //                _mr[i].enabled = true;
                //            }
                //        }
                //        return;
                //    }
                //    if ((int)cb.cubeLv == 2)
                //    {
                //        cb.cubeLv = CubeLevel.CubeLv.Lv4;
                //        for (int i = 0; i < _mr.Count; i++)
                //        {
                //            _mr[i].enabled = false;
                //        }

                //        for (int i = 0; i < (int)CubeLevel.CubeLv.Count; i++)
                //        {
                //            if (i == (int)cb.cubeLv)
                //            {
                //                _mr[i].enabled = true;
                //            }
                //        }
                //        return;
                //    }
                //    else
                //        return;
                #endregion
            }
        }
    }
    void Update()
    {
        if (_mr[0].enabled)
            cb.cubeLv = CubeLevel.CubeLv.Lv1;
        if (_mr[1].enabled)
            cb.cubeLv = CubeLevel.CubeLv.Lv2;
        if (_mr[2].enabled)
            cb.cubeLv = CubeLevel.CubeLv.Lv3;
        if (_mr[3].enabled)
            cb.cubeLv = CubeLevel.CubeLv.Lv4;
        if (_mr[4].enabled)
            cb.cubeLv = CubeLevel.CubeLv.Count;
    }


}
