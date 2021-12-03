using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrottleTutorial : Tutorial
{
    private bool isCurrentTutorial = false;


    public override void CheckIfHappening()
    {
        
        isCurrentTutorial = true;
    }

    private void OnThrottle(InputValue value)
    {
        if (!isCurrentTutorial)
            return;
        if (value.Get<float>() < 0)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }
}
