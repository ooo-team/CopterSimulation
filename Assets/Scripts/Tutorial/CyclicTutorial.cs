using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CyclicTutorial : Tutorial
{
    private bool isCurrentTutorial = false;

    private bool up = false;
    private bool down = false;
    private bool left = false;
    private bool right = false;

    public override void CheckIfHappening()
    {
        isCurrentTutorial = true;
    }

    private void OnCyclic(InputValue value)
    {
        if (!isCurrentTutorial)
            return;

        Vector2 vec = value.Get<Vector2>();

        if (vec.x < 0)
        {
            up = true;
        }
        else if (vec.x > 0)
        {
            down = true;
        }

        if (vec.y < 0)
        {
            left = true;
        }
        else if (vec.y > 0)
        {
            right = true;
        }

        if (up & down & left & right)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }
}
