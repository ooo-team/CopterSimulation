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
        [SerializeField] private float yawPower = 0.1f;
        [SerializeField] private float pitchSpeed = 0.2f;
        [SerializeField] private float rollSpeed = 0.2f;
        [SerializeField] private float yawSpeed = 1f;
        private float yaw = 0
        ;
        private float finalPitch;
        private float finalRoll;
        private float finalYaw;
        private Drone_inputs input;

        private float isLanded = 0;
        private List<Engine_interface> engines = new List<Engine_interface>();

        private List<Propeller_rotate> propellers = new List<Propeller_rotate>();

        public float IsLanded { get => isLanded; set => isLanded = value; }

        // Start is called before the first frame update
        void Start()
        {
            input = GetComponent<Drone_inputs>();
            engines = GetComponentsInChildren<Engine_interface>().ToList<Engine_interface>();
            propellers = GetComponentsInChildren<Propeller_rotate>().ToList<Propeller_rotate>();
        }

        protected override void HandlePhysics()
        {
            IsLanded = Mathf.Lerp(IsLanded, input.Power, Time.deltaTime);
            foreach(Propeller_rotate propeller in propellers) {
                propeller.isLanded = IsLanded;
            }
            HandleEngine();
            if (IsLanded > 0.2f) {
                HandleControl();
            }
        }

        protected virtual void HandleEngine() {
            foreach(Engine_interface engine in engines) {
                engine.UpdateEngine(rb, input, IsLanded);
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