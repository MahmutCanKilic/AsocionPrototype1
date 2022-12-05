using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnLine;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject pickable;
    public int countFuel;
    float maxFuel = 10;
    GameObject startPlane;
    public Animator animPlayer;
    void Start()
    {
        startPlane = GameObject.FindGameObjectWithTag("StartPlane");
        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        SpawnPickable();
        Debug.Log(countFuel);
        countFuel = GameObject.FindGameObjectsWithTag("Pickable").Length;
    }
    private void SpawnPickable()
    {
        if (countFuel <= maxFuel)
        {
            
            int spawnLineNumber = Random.Range(0, spawnLine.Length);
            int spawnNumber = Random.Range(0, spawnPoints.Length);
            GameObject pickable = Instantiate(spawnPoints[spawnNumber], spawnLine[spawnLineNumber].transform.position, Quaternion.identity);
            pickable.transform.SetParent(startPlane.transform);
            
        }



    }
}
