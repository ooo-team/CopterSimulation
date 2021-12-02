using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTutorial : Tutorial
{
    public List<string> Keys = new List<string>();
    // Start is called before the first frame update
    public override void CheckIfHappening()
    {
        foreach (string key in Keys)
        {
            if (Input.inputString.Contains(key))
            {
                Keys.Remove(key);
                break;
            }
        }

        if (Keys.Count == 0)
        {
            TutorialManager.Instance.CompletedTutorial();
        }

    }
}
