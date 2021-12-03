using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace drone{
    [RequireComponent(typeof(BoxCollider))]
    public class Engine : MonoBehaviour, Engine_interface
    {
        private float maxPower = 1f;
        


        public void InitEngine()
        {
            
        }

        public void UpdateEngine(Rigidbody rb, Drone_inputs input, float isLanded)
        {
            Vector3 engine_force = Vector3.zero;
            engine_force = transform.up * (rb.mass * Physics.gravity.magnitude - input.Throttle * maxPower)/4 * isLanded;
            rb.AddForce(engine_force, ForceMode.Force);
        }
    }
}