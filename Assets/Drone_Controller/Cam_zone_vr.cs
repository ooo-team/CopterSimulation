using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Cam_zone_vr : MonoBehaviour
{
    public Transform target;
    public Transform player;
    private float power;

    private void OnPowerEngines(InputValue value)
    {
        power = Mathf.Abs(power - 1);
    }

    void Start()
    {
    }

    void Update()
    {
        if (power == 1)
        {
            transform.rotation = target.rotation;
            transform.position = target.position + target.up * 0.2f;// + target.up - target.forward * 3;
        }
        else
        {
            transform.rotation = player.rotation;
            transform.position = player.position + Vector3.up;// + target.up - target.forward * 3;
        }


    }
}