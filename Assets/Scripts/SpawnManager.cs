using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnLine;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject pickable;
    float countFuel;
    float maxFuel = 5;
    void Start()
    {

    }

    void Update()
    {
        SpawnPickable();

    }
    private void SpawnPickable()
    {
       /* if (countFuel <= maxFuel)
        {
            int spawnLineNumber = Random.Range(0, spawnLine.Length);
            int spawnNumber = Random.Range(0, spawnPoints.Length);
            GameObject pickable = Instantiate(spawnPoints[0], spawnLine[spawnLineNumber].transform.position, Quaternion.identity);
            gameObject.transform.SetParent(pickable.transform);
            countFuel++;
        }*/



    }
}
