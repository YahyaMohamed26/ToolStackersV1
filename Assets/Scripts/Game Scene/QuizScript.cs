using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScript : MonoBehaviour
{
    public bool isCorrect;
    public static bool yes = false;
    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        Debug.Log(gameObject.transform.GetChild(0).GetComponent<Text>().text);

        if (isCorrect)
        {
            PlayerDeck.isCorrect = true;

            if (PlayerDeck.isPerform)
            {
                PlayerDeck.canCall2 = true;
                PlayerDeck.canCall = false;
            }
            else
            {
                PlayerDeck.canCall = true;
                PlayerDeck.canCall2 = false;
            }
            
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer!");
        }
        else
        {
            PlayerDeck.isCorrect = false;

            if (PlayerDeck.isPerform)
            {
                PlayerDeck.canCall2 = true;
                PlayerDeck.canCall = false;
            }
            else
            {
                PlayerDeck.canCall = true;
                PlayerDeck.canCall2 = false;
            }

            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer!");
        }
    }


}
