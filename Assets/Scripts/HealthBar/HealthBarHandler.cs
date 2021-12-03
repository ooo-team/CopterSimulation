using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{

    public float decay_time;
    private float current_size;

    private static Image knobComponent;
    // Start is called before the first frame update
    void Start()
    {
        current_size = decay_time;
        knobComponent = GetComponent<Image>();
        // Debug.Log("i have image component!");
        InvokeRepeating("decreaseTime", 1.0f, 1.0f);
    }

    void decreaseTime()
    {
        current_size -= 1;
        if (current_size == 0)
        {
            //exit here
        }
        knobComponent.fillAmount = current_size / decay_time;
    }
}
