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
    private Vector2 originalPosition;
    private bool isMoving = true;
    private HerbArray targetPoint;

    public void SetTargetPosition(Vector2 target, HerbArray targetPoint)
    {
        originalPosition = transform.position;
        targetPosition = target;
        this.targetPoint = targetPoint;
    }

    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        if (isMoving && Vector2.Distance(currentPosition, targetPosition) < 0.01f)
        {
            isMoving = false;
            StartCoroutine(CheckStateAfterDelay(2f));
        }
    }

    IEnumerator CheckStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (targetPoint.IsFull())
        {

            SetTargetPosition(originalPosition, targetPoint);// 초기위치로 돌아오는거
            //Transform newTargetTransform = Spawn.targetPoints[Random.Range(0, Spawn.targetPoints.Length)]; //뺑뻉이 도는거 나중에 해야징 히히후미
            //HerbArray newTargetPoint = newTargetTransform.GetComponent<HerbArray>();
            //SetTargetPosition(newTargetTransform.position, newTargetPoint);
            isMoving = true;
        }
        else
        {
            targetPoint.AddHerb(this);
        }
    }
}
