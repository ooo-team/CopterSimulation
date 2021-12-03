using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OpeningTutorial : Tutorial
{
    private bool isCurrentTutorial = false;

    public RawImage outline;

    public override void CheckIfHappening()
    {
        if (!isCurrentTutorial)
        {
            RawImage red_rect = outline.GetComponent<RawImage>();
            red_rect.enabled = true;
        }
        isCurrentTutorial = true;
    }

    private void OnSkippingTutorial(InputValue value)
    {
        if (!isCurrentTutorial)
            return;

        Debug.Log(value.Get<float>());
        if (value.Get<float>() > 0)
        {
            RawImage red_rect = outline.GetComponent<RawImage>();
            red_rect.enabled = false;
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }
}

