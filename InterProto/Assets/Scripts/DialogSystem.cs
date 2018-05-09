using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {

    public Text MainText;
    public string[] sentences;
    public int Index;
    public float typingSpeed;
    public GameObject NextButton;
    public GameObject Character;
    public GameObject OtherPerson;
    public GameObject Everything;
    bool callOneTime;


    private void Update()
    { 

        if(MainText.text == sentences[Index])
        {
            NextButton.SetActive(true);        
        }

    }

    public IEnumerator Type()
    {
        foreach(char letter in sentences[Index].ToCharArray())
        {
            MainText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        Character.SetActive(!Character.activeSelf);
        OtherPerson.SetActive(!OtherPerson.activeSelf);
        NextButton.SetActive(false);
        if (Index < sentences.Length - 1)
        {
            Index++;
            MainText.text = "";
            StartCoroutine(Type());
        } else
        {
            MainText.text = "";
            StartCoroutine(InteractableBase.ReturToMove());
            NextButton.SetActive(false);
            Everything.SetActive(false);
            callOneTime = true;
        }
    }

}
