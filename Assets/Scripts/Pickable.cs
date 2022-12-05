using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickable : MonoBehaviour
{
    private Image ımg;
    int countFuel;
    private void Start()
    {
        ımg = FindObjectOfType<FuelManagement>().fuelBar;
    }
    private void Update()
    {
        countFuel = FindObjectOfType<SpawnManager>().countFuel;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ımg.fillAmount += 0.1f;
            
        }
    }
}
