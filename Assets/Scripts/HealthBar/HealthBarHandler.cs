using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthBarHandler : MonoBehaviour
{

    public float decay_time;
    private float current_size;

    public GameObject droneObject;
    private static Image knobComponent;
    public TextMeshProUGUI precentage_counter;
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
        drone.Drone_controller controller = droneObject.GetComponent<drone.Drone_controller>();
        if (controller.IsLanded > 0.01)
        {
            current_size -= 1;
            if (current_size <= 0)
            {
                precentage_counter.text = "ПУСТАЯ БАТАРЕЯ";
                precentage_counter.color = new Color(255, 0, 0, 255);
                controller.HasPower = false;
                CancelInvoke("decreaseTime");
            }
            knobComponent.fillAmount = current_size / decay_time;
            precentage_counter.text = String.Format("{0:P2}", current_size / decay_time);
        }
    }
}
