using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : Tutorial
{
    private bool isCurrentTutorial = false;

    public Transform HitTransform;


    public override void CheckIfHappening()
    {
        if (!isCurrentTutorial)
        {
            // Debug.Log("Showing mesh renderer");
            MeshRenderer rend = GetComponent<MeshRenderer>();
            if (rend)
            {
                rend.enabled = true;
            }
        }
        isCurrentTutorial = true;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isCurrentTutorial)
            return;

        if (other.transform == HitTransform)
        {
            Debug.Log("Hiding mesh renderer");
            MeshRenderer rend = GetComponent<MeshRenderer>();
            if (rend)
            {
                rend.enabled = false;
            }
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }
    }
}
