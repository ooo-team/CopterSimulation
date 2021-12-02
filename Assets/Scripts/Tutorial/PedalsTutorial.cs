using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PedalsTutorial : Tutorial
{
    private bool isCurrentTutorial = false;

    private bool left = false;
    private bool right = false;

    public override void CheckIfHappening()
    {
        isCurrentTutorial = true;
    }

    private void OnPedals(InputValue value)
    {
        if (!isCurrentTutorial)
            return;


        if(value.Get<float>() < 0){
            left = true;
        } else if(value.Get<float>() > 0) {
            right = true;
        }

        if (left && right)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }
}
