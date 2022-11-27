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
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
