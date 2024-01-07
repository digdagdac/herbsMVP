using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Drop : MonoBehaviour
{
    public static int curindex=-1;
    Inventory inventory;
    public Herbs[] herbs;
    private Vector2 ReSpown;
    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            string HerbName = inventory.slots[curindex].slotObj.transform.GetChild(0).name;
            Debug.Log(HerbName);
            ReSpown = new Vector2(this.transform.position.x + 1, this.transform.position.y);
            
            switch (HerbName)
            {
                case "Herb1Img(Clone)":
                    Instantiate(herbs[0], ReSpown, Quaternion.identity);
                    break;
                case "Herb2Img(Clone)":
                    Instantiate(herbs[1], ReSpown, Quaternion.identity);
                    break;
                case "Herb3Img(Clone)":
                    Instantiate(herbs[2], ReSpown, Quaternion.identity);
                    break;
                case "Herb4Img(Clone)":
                    Instantiate(herbs[3], ReSpown, Quaternion.identity);
                    break;
                case "Herb5Img(Clone)":
                    Instantiate(herbs[4], ReSpown, Quaternion.identity);
                    break;
                default:
                    break;
            }
            Destroy(inventory.slots[curindex].slotObj.transform.GetChild(0).gameObject);
            curindex--;
            if(curindex >= inventory.slots.Count)
            {
                curindex = 0;
            }


            //약초 소환
            //Destroy(this.gameObject);
        }
    }
}
