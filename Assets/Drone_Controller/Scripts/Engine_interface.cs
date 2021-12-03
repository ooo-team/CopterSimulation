using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace drone{
    public interface Engine_interface
    {
        void InitEngine();
        void UpdateEngine(Rigidbody rb, Drone_inputs input, float isLanded);
    }
}
