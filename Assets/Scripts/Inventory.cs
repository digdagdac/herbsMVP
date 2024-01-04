using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
 
    public List<SlotData> slots = new List<SlotData>();
    private int MaxSlot = 3;
    public GameObject slotPrefab;
    private void Start()
    {
        GameObject slotPanel = GameObject.Find("Panel");

        for (int i = 0; i < MaxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot " + i;
            SlotData slot = new SlotData();
            slot.isEmpty = true;   
            slot.slotObj = go;
            slots.Add(slot);
        }
    }
}
