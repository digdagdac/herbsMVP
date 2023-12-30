using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HerbArrayReset : MonoBehaviour
{
    public HerbArray[] targetPoints;  // 인스펙터에서 설정하세요.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetPoints[0].DebugHerbArray();
            targetPoints[0].DestroyAllHerbs();
            targetPoints[0].InitializeHerbArray();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetPoints[1].DebugHerbArray();
            targetPoints[1].DestroyAllHerbs();
            targetPoints[1].InitializeHerbArray();
            

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetPoints[2].DebugHerbArray();
            targetPoints[2].DestroyAllHerbs();
            targetPoints[2].InitializeHerbArray();
           

        }

    }
    //void DestroyObject(int index)
    //{
    //    Destroy(targetPoints[index].gameObject);
    //}
}
