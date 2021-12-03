using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EngineTutorial : Tutorial
{
    private bool isCurrentTutorial = false;

    public override void CheckIfHappening()
    {
        // Debug.Log("new current tutorial");
        isCurrentTutorial = true;
    }

    private void OnPowerEngines(InputValue value)
    {
        Debug.Log(isCurrentTutorial);
        if (!isCurrentTutorial)
            return;

        Debug.Log(value.Get<float>());
        if (value.Get<float>() > 0)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }
}
