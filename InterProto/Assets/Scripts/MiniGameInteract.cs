using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameInteract : InteractableBase {

    public GameObject Player;
    bool PlayerInComeToPick;

    public string SeeText;
    float typingSpeed = 0.04f;
    public GameObject PanelSee;
    public GameObject ButtonSee;
    public GameObject Fade;
    public Text MainText;
    static public bool CanPlay = false;
    static public bool Piked = false;
    public bool IsIcon;

	
	// Update is called once per frame
	void Update () {

        if (Piked && !IsIcon)
        {
            gameObject.SetActive(false);
        }

        if (MainText.text == SeeText)
        {
            ButtonSee.SetActive(true);
        }

        if (PlayerInComeToPick)
        {
            if (Player.transform.position.x < transform.position.x)
            { CliclToMove.Direçao = 1; }

            if (Player.transform.position.x > transform.position.x)
            { CliclToMove.Direçao = -1; }

            if (Player.transform.position.x > transform.position.x - .8f && Player.transform.position.x < transform.position.x + .8f)
            {
                Interaction();
                CliclToMove.Direçao = 0;
                PlayerInComeToPick = false;
            }
        }

    }

    public void Interaction()
    {
        if (QuestLog.MainQuestStaus == 4 && !Piked)
            Piked = true;
        else
        {
            Instantiate(Fade);
            Invoke("LoadBailarina", 0.7f);
        }
    }
    void LoadBailarina()
    {
        MyLoad.Loading("Bailarina");
        Fade.SetActive(false);
    }

    public void BottonVer()
    {
        StartCoroutine(Type());
        PanelSee.SetActive(true);
        PanelInteraction.SetActive(false);
    }

    public void ButtonLoadBalarina()
    {
        PlayerInComeToPick = true;
        PanelInteraction.SetActive(false);
        ClickOnObject = false;
    }

    public void ButtonPegar()
    {
        PlayerInComeToPick = true;
        PanelInteraction.SetActive(false);
        ClickOnObject = false;
    }

    public void ButtonQuit()
    {
        StartCoroutine(InteractableBase.ReturToMove());
        PanelInteraction.SetActive(false);
    }

    public IEnumerator Type()
    {
        foreach (char letter in SeeText.ToCharArray())
        {
            MainText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void SeeClose()
    {
        MainText.text = "";
        PanelSee.SetActive(false);
        StartCoroutine(ReturToMove());
    }
}
