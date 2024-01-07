using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    Inventory inventory;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //약초 소환
            Destroy(this.gameObject);
        }
    }
}
