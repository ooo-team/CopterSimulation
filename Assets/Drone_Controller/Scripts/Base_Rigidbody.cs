using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace drone{
    [RequireComponent(typeof(Rigidbody))]
    public class Base_Rigidbody : MonoBehaviour
    {
        [SerializeField] private float weigth = 6.5f;
        protected Rigidbody rb;
        protected float startDrag;
        protected float startAngelar;

        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb) {
                rb.mass = weigth;
                startDrag = rb.drag;
                startAngelar = rb.angularDrag;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!rb) { return; }
            HandlePhysics();
        }

        protected virtual void HandlePhysics() {

        }
    }
}
