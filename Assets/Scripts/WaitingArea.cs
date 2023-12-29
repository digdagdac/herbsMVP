using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingArea : MonoBehaviour
{
    public List<GameObject> waitingObjects = new List<GameObject>();

    public void AddObject(GameObject obj)
    {
        waitingObjects.Add(obj);
    }

    public GameObject GetObject()
    {
        if (waitingObjects.Count > 0)
        {
            GameObject obj = waitingObjects[0];
            waitingObjects.RemoveAt(0);
            return obj;
        }
        return null;
    }
}
