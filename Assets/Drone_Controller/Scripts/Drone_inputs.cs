using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace drone{
    [RequireComponent(typeof(PlayerInput))]
    public class Drone_inputs : MonoBehaviour
    {
        private Vector2 cyclic;
        private float padals;
        private float throttle;
        private float power;

        public Vector2 Cyclic { get => cyclic; }
        public float Padals { get => padals;  }
        public float Throttle { get => throttle;  }
        public float Power { get => power;  }
        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnCyclic(InputValue value) {
            cyclic = value.Get<Vector2>();
        }

        private void OnPedals(InputValue value) {
            padals = value.Get<float>();
        }

        private void OnThrottle(InputValue value) {
            throttle = value.Get<float>();
        }

        private void OnPowerEngines(InputValue value) {
            power = Mathf.Abs(power-1);
        }
    }
}
