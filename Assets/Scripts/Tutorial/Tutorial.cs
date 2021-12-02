using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    public int Order;

    [TextArea(1, 10)]
    public string Explanation;

    void Awake()
    {
        TutorialManager.Instance.Tutorials.Add(this);
    }

    public virtual void CheckIfHappening() { }
}
