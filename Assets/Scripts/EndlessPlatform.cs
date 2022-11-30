using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPlatform : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
            transform.position += new Vector3(0, 0, GetComponent<MeshRenderer>().bounds.size.z * 4);
       
    }
}
