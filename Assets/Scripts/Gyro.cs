using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    private Rigidbody rb;
    private SimpleSpinBlur ssb;
    [SerializeField] private float rotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ssb = GetComponent<SimpleSpinBlur>();
    }
    
    
    void Update()
    {
        bool isAir = FindObjectOfType<PlayerController>().isAir;
        if (isAir)
        {
            
            rotateSpeed = 2000;
            ssb.shutterSpeed = 37;
            ssb.Samples = 15;
        }
        else
        {
            rotateSpeed = 1000;
            ssb.shutterSpeed = 1;
            ssb.Samples = 2;
        }
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
