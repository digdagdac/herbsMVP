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
    public bool isMoving = true;

    public bool isCarried = false;

    public Transform[] targetPoints;


    private HerbArray targetPoint;
    

    public void SetTargetPosition(Vector2 target, HerbArray targetPoint)
    {
        originalPosition = transform.position;
        targetPosition = target;
        this.targetPoint = targetPoint;
    }
    
    void Update()
    {
       

        if (isMoving && isCarried ==false)
        {
            MoveTowardsTarget();
        }

    }
    void MoveTowardsTarget()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(currentPosition, targetPosition) < 0.01f)
        {
            isMoving = false;
            StartCoroutine(CheckStateAfterDelay(2f));

        }
    }
    IEnumerator CheckStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (targetPoint != null && targetPoint.IsFull())
        {

            SetTargetPosition(originalPosition, targetPoint);// 초기위치로 돌아오는거
            //Transform newTargetTransform = Spawn.targetPoints[Random.Range(0, Spawn.targetPoints.Length)]; //뺑뻉이 도는거 나중에 해야징 히히후미
            //HerbArray newTargetPoint = newTargetTransform.GetComponent<HerbArray>();
            //SetTargetPosition(newTargetTransform.position, newTargetPoint);
            isMoving = true;
        }
        else
        {
            Transform targetPointTransform = targetPoints[Random.Range(0, targetPoints.Length)];
            Vector2 newTargetPosition = new Vector2(targetPoint.transform.position.x, targetPoint.transform.position.y + 2);
            SetTargetPosition(newTargetPosition, targetPoint);
            isMoving = true;
            
            //targetPoint.AddHerb(this); //허브 넣기
        }
    }

    //public void PickUp()
    //{
    //    isCarried = true;
    //    GameObject player = GameObject.Find("Player");
    //    if (player != null)
    //    {
    //        Move playerScript = player.GetComponent<Move>();
           
              
    //        transform.SetParent(player.transform);

    //        isCarried = true;

    //        GetComponent<Collider2D>().enabled = false;

                

        
    //    }
    //}

    //public void DropHerb()
    //{


    //    if (isCarried)
    //    {
          
    //        transform.SetParent(null);

           
    //        isCarried = false;

          
    //        GetComponent<Collider2D>().enabled = true;

    //        Spawn spawn = FindObjectOfType<Spawn>();

    //        Transform randomTarget = spawn.targetPoints[Random.Range(0, spawn.targetPoints.Length)];


    //        SetTargetPosition(randomTarget.position, targetPoint);
    //        isMoving = true;
    //    }


    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "tang")
        {
            Debug.Log("제발");


            HerbArray collidedHerbArray = collision.gameObject.GetComponent<HerbArray>();
            if (collidedHerbArray != null)
            {
                targetPoint = collidedHerbArray;
                targetPoint.AddHerb(this);
               
                
                
            }
            else
            {
                Debug.Log("또 널값이야?");
            }

            isCarried = false;
        }
    }
  
}
