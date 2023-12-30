using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbArray : MonoBehaviour
{
    public Herbs[] herbArray = new Herbs[3];

    public bool IsFull()
    {
        for (int i = 0; i < herbArray.Length; i++)
        {
            if (herbArray[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void AddHerb(Herbs herb)
    {
        for (int i = 0; i < herbArray.Length; i++)
        {
            if (herbArray[i] == null)
            {
                herbArray[i] = herb;
                return;
            }
        }
    }
}
