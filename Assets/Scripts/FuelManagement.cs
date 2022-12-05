using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManagement : MonoBehaviour
{
    public Image fuelBar;
    public bool onAir;
    void Start()
    {
        fuelBar.fillAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bool isAir = FindObjectOfType<PlayerController>().isAir;
        if (fuelBar.fillAmount > 0)
        {
            onAir = true;           
        }

        
        if (fuelBar.fillAmount == 0)
        {
            onAir = false;
            
        }
        if (isAir)
        {
            fuelBar.fillAmount -= 0.1f * Time.deltaTime;
        }
        else
        {
            fuelBar.fillAmount += 0.01f * Time.deltaTime;
        }
    }
}
