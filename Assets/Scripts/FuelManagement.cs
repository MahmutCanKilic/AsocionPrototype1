using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManagement : MonoBehaviour
{
    public Image fuelBar;
    void Start()
    {
        fuelBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            fuelBar.fillAmount -= 0.1f;
        }
    }
}
