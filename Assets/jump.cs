using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class jump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

        
    bool isGrounded = false;
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground") {
          rb.AddForce(new Vector3(0, 10, 0), ForceMode.VelocityChange);
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "ground")
            isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
