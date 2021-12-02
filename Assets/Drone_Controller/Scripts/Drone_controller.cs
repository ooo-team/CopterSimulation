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
            
        }
        // Update is called once per frame
    }
}