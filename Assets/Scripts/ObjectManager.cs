using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Slot[] slots;
    public WaitingArea initialWaitingArea;
    public WaitingArea finalWaitingArea;

    public void MoveObjectToSlot(GameObject obj)
    {
        foreach (Slot slot in slots)
        {
            if (!slot.isFilled)
            {
                obj.transform.position = slot.transform.position;
                slot.FillSlot();
                return;
            }
        }
        finalWaitingArea.AddObject(obj);
    }

    public void MoveObjectToInitialWaitingArea(GameObject obj)
    {
        initialWaitingArea.AddObject(obj);
    }
}
