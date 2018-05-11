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
    public GameObject Mae;
    static public GameObject OtherPerson;
    public GameObject Everything;
    bool callOneTime;
    static public bool FirstDialog = true;
    static public bool StartType;
    public Image ImageMae;
    public Image ImageIrmao;

    private void Start()
    {
        if (FirstDialog)
        {
            Everything.SetActive(true);
            OtherPerson = Mae;
            InteractableBase.ClickOnObject = true;
            StartCoroutine(Type());
            FirstDialog = false;
        } 
    }

    private void Update()
    {

        /*if(MainText.text == sentences[Index])
        {
            NextButton.SetActive(true);        
        }*/
        if (StartType)
        {
            StartCoroutine(Type());
            StartType = false;
        }
        NextButton.SetActive(true);

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
        //NextButton.SetActive(false);
        if (Index < sentences.Length - 1)
        {
            Character.SetActive(!Character.activeSelf);
            OtherPerson.SetActive(!OtherPerson.activeSelf);
            Index++;
            MainText.text = "";
            StopAllCoroutines();
            StartCoroutine(Type());
        } else
        {
            Character.SetActive(false);
            OtherPerson.SetActive(false);
            MainText.text = "";
            NextButton.SetActive(false);
            Everything.SetActive(false);
            callOneTime = true;
            StopAllCoroutines();
            StartCoroutine(InteractableBase.ReturToMove());

        }
    }

}
