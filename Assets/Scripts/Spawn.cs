using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //public GameObject targetPointsObject;
    public Herbs[] herbs;
    public Transform[] targetPoints; //뺑뻉이 돌리려면 static선언
    public float SMINT = 2f;
    public float SMAXT = 5f;

    public Transform spawnPoints;
    //void Awake()
    //{
    //    targetPoints = targetPointsObject.GetComponentsInChildren<Transform>();
    //}


    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(SMINT, SMAXT));
            SpawnHerbs();
        }
    }

    void SpawnHerbs()
    {
        float totalProbability = 0;


        foreach (Herbs herb in herbs)
        {
            totalProbability += herb.spawnProbability;
        }


        float randomValue = Random.Range(0, totalProbability);


        foreach (Herbs herb in herbs)
        {
            if (randomValue < herb.spawnProbability)
            {
                GameObject spawnedHerb = Instantiate(herb.herbsPrefab, spawnPoints.position, Quaternion.identity);

                Transform targetPointTransform = targetPoints[Random.Range(0, targetPoints.Length)];
                HerbArray targetPoint = targetPointTransform.GetComponent<HerbArray>();

                Herbs Herbs = spawnedHerb.GetComponent<Herbs>();
                if (Herbs != null)
                {
                    Herbs.SetTargetPosition(targetPointTransform.position, targetPoint);
                }

                return;
            }
            randomValue -= herb.spawnProbability;
        }
    }
}
