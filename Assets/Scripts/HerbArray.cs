using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbArray : MonoBehaviour
{
    public Herbs[] herbArray = new Herbs[5];

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
                herb.isMoving = false;
                switch (i)
                {
                    case 0:
                        herb.transform.position = new Vector2(transform.position.x - 1f, transform.position.y+2f);
                        herb.GetComponent<BoxCollider2D>().enabled = false;
                        break;
                    case 1:
                        herb.transform.position = new Vector2(transform.position.x, transform.position.y+2f);
                        herb.GetComponent<BoxCollider2D>().enabled = false;
                        break;
                    case 2:
                        herb.transform.position = new Vector2(transform.position.x + 1f, transform.position.y + 2f);
                        herb.GetComponent<BoxCollider2D>().enabled = false;
                        break;
                    default:
                        break;
                }
                  

                return;
            }
        }
    }

   
    public void InitializeHerbArray()
    {
        for (int i = 0; i < herbArray.Length; i++)
        {
            herbArray[i] = null;
        }
    }
    public void DebugHerbArray()
    {
        for (int i = 0; i < herbArray.Length; i++)
        {
            Debug.Log(herbArray[i] != null ? herbArray[i].ToString() : "null");
        }
    }
    public void RemoveHerbs(Herbs herb)//배열에서 특정 약초만제거
    {
        for (int i = 0; i < herbArray.Length; i++)
        {
           if (herbArray[i] == herb)
            {
                herbArray[i] = null;
                return;
            }
        }
    }
    
    public void DestroyAllHerbs()//다 파괴다 파괴 히히
    {
        for (int i = 0; i < herbArray.Length; i++)
        {
            if (herbArray[i] != null)
            {
                Destroy(herbArray[i].gameObject);
                herbArray[i] = null;
            }
        }
    }
}
