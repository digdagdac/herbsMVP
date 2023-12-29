using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Herbs : MonoBehaviour
{
    
    public GameObject herbsPrefab;
    public float spawnProbability;
    public float speed = 5f;

    private Vector2 targetPosition;
    public void SetTargetPosition(Vector2 target)
    {
        targetPosition = target;
    }
    void Update()
    {
     
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
    }
}
