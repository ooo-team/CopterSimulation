using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Cam_zone : MonoBehaviour {
    public Transform target;
    
    void Start () 
    {
    }

    void Update ()
    {
        transform.rotation = target.rotation;
        transform.position = target.position + target.up - target.forward * 3;
        
    }
}