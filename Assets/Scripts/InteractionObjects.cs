using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjects : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    private bool onAir;

    void Start()
    {
        rb = GameObject.FindObjectOfType<PlayerController>().rb;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        onAir = FindObjectOfType<FuelManagement>().onAir;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Red"))
            {
                anim.SetTrigger("CollisionRed");
            }
            if (gameObject.CompareTag("Blue"))
            {
                anim.SetTrigger("CollisionBlue");
            }
            if (gameObject.CompareTag("Yellow"))
            {
                anim.SetTrigger("CollisionYellow");
            }
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (onAir)
            {
                rb.AddForce(Vector3.up * 15, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(-Vector3.up * 15, ForceMode.VelocityChange);
            }
        }
    }
}
