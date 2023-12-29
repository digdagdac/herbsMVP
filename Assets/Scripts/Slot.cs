using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isFilled;

    public void FillSlot()
    {
        isFilled = true;
    }

    public void EmptySlot()
    {
        isFilled = false;
    }
}
