using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace drone{
    [RequireComponent(typeof(Drone_inputs))]
    public class Drone_controller : Base_Rigidbody
    {
        [SerializeField] private float minMaxPutch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 4f;
        [SerializeField] private float pitchSpeed = 2f;
        [SerializeField] private float rollSpeed = 2f;
        [SerializeField] private float yawSpeed = 2f;
        private float yaw = 0;
        private float finalPitch;
        private float finalRoll;
        private float finalYaw;
        private Drone_inputs input;
        private List<Engine_interface> engines = new List<Engine_interface>();
        // Start is called before the first frame update
        void Start()
        {
            input = GetComponent<Drone_inputs>();
            engines = GetComponentsInChildren<Engine_interface>().ToList<Engine_interface>();
        }

        protected override void HandlePhysics()
        {
            HandleEngine();
            HandleControl();
        }

        protected virtual void HandleEngine() {
            foreach(Engine_interface engine in engines) {
                engine.UpdateEngine(rb, input);
            }
        }

        protected virtual void HandleControl() {
            float pitch = input.Cyclic.y * minMaxPutch;
            float roll = -input.Cyclic.x * minMaxRoll;
            yaw += input.Padals * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, pitchSpeed * Time.deltaTime);
            finalRoll = Mathf.Lerp(finalRoll, roll, rollSpeed * Time.deltaTime);
            finalYaw = Mathf.Lerp(finalYaw, yaw, yawSpeed * Time.deltaTime);
            rb.MoveRotation(Quaternion.Euler(finalPitch, finalYaw, finalRoll));
        }
        // Update is called once per frame
    }
}