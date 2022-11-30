using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjects : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
   
    //[SerializeField] private GameObject red, yellow, blue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindObjectOfType<PlayerController>().rb;
        anim = GetComponent<Animator>();
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
            rb.AddForce(Vector3.up * 15, ForceMode.VelocityChange);
        }
    }
}
