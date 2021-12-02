using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyTutorial : Tutorial
{
    public List<string> Keys = new List<string>();

    private bool isCurrentTutorial = false;

    public override void CheckIfHappening()
    {
        isCurrentTutorial = true;

    }

    private void OnNew(InputValue value)
    {
        if (isCurrentTutorial)
            return;

        
        if (Keys.Count == 0)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }


    }
}
