using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> Tutorials = new List<Tutorial>();

    public TextMeshProUGUI explanationText;

    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();

            if (instance == null)
                Debug.Log("There is no TutorialManager instance :(");

            return instance;
        }
    }

    private Tutorial currentTutorial;

    // Start is called before the first frame update
    void Start()
    {
        SetNextTutorial(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial)
        {
            currentTutorial.CheckIfHappening();
        }
    }

    public void CompletedTutorial()
    {
        // Debug.Log("Setting another tutorial");
        SetNextTutorial(currentTutorial.Order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTutorial = GetTutorialByOrder(currentOrder);
        if (!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }
        explanationText.text = currentTutorial.Explanation;
    }

    public void CompletedAllTutorials()
    {
        explanationText.text = "Поздравляем, вы успешно окончили ускоренный курс обучения";
        //loadNextScene()
    }

    public Tutorial GetTutorialByOrder(int Order)
    {
        foreach (Tutorial tutor in Tutorials)
        {
            if (tutor.Order == Order)
                return tutor;
        }
        return null;
    }


}
