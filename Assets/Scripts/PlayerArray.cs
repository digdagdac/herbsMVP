using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArray : MonoBehaviour
{
    public Herbs[] playerArray = new Herbs[3];
    public void playerAddHerb(Herbs herb)
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i] == null)
            {
                playerArray[i] = herb;
                herb.isMoving = false;
                switch (i)
                {
                    case 0:
                        herb.transform.position = new Vector2(16, 0);
                        break;
                    case 1:
                        herb.transform.position = new Vector2(16, -1);
                        break;
                    case 2:
                        herb.transform.position = new Vector2(16, -2);
                        break;
                    default:
                        break;
                }


                return;
            }
        }
    }
    public void RemoveHerbs(int PlayerherbNum, int spawnNum)//배열에서 특정 약초만제거
    {
        playerArray[PlayerherbNum].transform.position = new Vector2(transform.position.x + spawnNum, transform.position.y) ;
        playerArray[PlayerherbNum].isMoving = true;
        playerArray[PlayerherbNum].SetTargetPosition(new Vector2(transform.position.x + spawnNum, transform.position.y), null);
        playerArray[PlayerherbNum] = null;
        
    }
}
