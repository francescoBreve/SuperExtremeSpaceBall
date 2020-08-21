using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
      
        
        if (collision.collider.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 20 ,ForceMode.Impulse);
           
        }
    }
}
