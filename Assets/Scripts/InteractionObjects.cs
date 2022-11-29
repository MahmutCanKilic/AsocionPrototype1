using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjects : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindObjectOfType<PlayerController>().rb;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Red"))
        {
            anim.SetTrigger("CollisionRed");
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Blue"))
        {
            anim.SetTrigger("CollisionBlue");
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Yellow"))
        {
            anim.SetTrigger("CollisionYellow");
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
