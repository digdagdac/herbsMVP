using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Slot : MonoBehaviour
{
    public int num;
    Inventory inventory;
     void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        string numString = gameObject.name.Replace("Slot ", ""); ;

        bool isParseSuccessful= int.TryParse(numString, out num);
        
        if (isParseSuccessful)
        {
            Debug.Log("Parse successful, num: " + num);
        }
        else
        {
            Debug.Log("Parse failed, numString: " + numString);
        }

    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.slots[num].isEmpty = true;
        }
    }
}
