using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotitem;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (Move.LeftClick)
            {
                Inventory inven = collision.GetComponent<Inventory>();
                Move player = collision.GetComponent<Move>();
                for (int i = 0; i < inven.slots.Count; i++)
                {
                    if (inven.slots[i].isEmpty)
                    {

                        Instantiate(slotitem, inven.slots[i].slotObj.transform, false);
                        inven.slots[i].isEmpty = false;
                        //Move.curindex++;
                        //Destroy(this.gameObject);
                        Move.LeftClick = false;
                        break;




                    }
                }
            }
            
            
        }
    }
}
