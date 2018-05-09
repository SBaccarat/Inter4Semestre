using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToInteract : InteractableBase {

    public GameObject UseItemButton;
    public GameObject Player;
    private SpriteRenderer sprite;
    bool PlayerInCome;
    public enum Items { RedBox, GreenBox,cigarro}
    public Items WhatIten;

    public string preSeeText;
    public string posSeeText;
    float typingSpeed = 0.04f;
    public GameObject PanelSee;
    public GameObject ButtonSee;
    public Text MainText;

    [HideInInspector] public enum States { Avaliable, Piked, Used }
    [HideInInspector] public States ItemState;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (WhatIten == Items.RedBox)
        {
            if (Persistence.redBoxStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.redBoxStatus == 1)
                ItemState = States.Piked;
            if (Persistence.redBoxStatus == 2)
                ItemState = States.Used;
        }
        else
        if (WhatIten == Items.GreenBox)
        {
            if (Persistence.greenBoxStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.greenBoxStatus == 1)
                ItemState = States.Piked;
            if (Persistence.greenBoxStatus == 2)
                ItemState = States.Used;
        }
        else
        if (WhatIten == Items.cigarro)
        {
            if (Persistence.cigarroStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.cigarroStatus == 1)
                ItemState = States.Piked;
            if (Persistence.cigarroStatus == 2)
                ItemState = States.Used;
        }
    }

    void Update()
    {
        if (MainText.text == posSeeText || MainText.text == preSeeText)
        {
           ButtonSee.SetActive(true);
        }
        switch (WhatIten)
        {
            case Items.RedBox:
                switch (ItemState) {
                    case States.Used:
                        Persistence.redBoxStatus = 2;
                        break;
                }
                break;
            case Items.GreenBox:
                switch (ItemState)
                {
                    case States.Used:
                        Persistence.greenBoxStatus = 2;
                        break;
                }
                break;
            case Items.cigarro:
                switch (ItemState)
                {
                    case States.Used:
                        Persistence.cigarroStatus = 2;
                        break;
                }
                break;
        }

        if (ItemState == States.Piked){
            UseItemButton.SetActive(true);
        }else {
            UseItemButton.SetActive(false);
        }


        if (PlayerInCome)
        {
            if (Player.transform.position.x < transform.position.x)
            { CliclToMove.Direçao = 1; }

            if (Player.transform.position.x > transform.position.x)
            { CliclToMove.Direçao = -1; }

            if (Player.transform.position.x > transform.position.x - 1.8f && Player.transform.position.x < transform.position.x + 1.8f)
            {
                Interaction();
                CliclToMove.Direçao = 0;
                PlayerInCome = false;
            }
        }
        if (ItemState == States.Used)
        {
            sprite.color = Color.blue;
        }
    }

    void Interaction()
    {
        ItemState = States.Used;
    }

    public void ButtonVer()
    {
        if (ItemState != States.Used){
            StartCoroutine(Type(preSeeText));
        }else
        if(ItemState == States.Used) {
            StartCoroutine(Type(posSeeText));
        }

        PanelSee.SetActive(true);
        PanelInteraction.SetActive(false);
    }

    public void ButtonUsar()
    {
        PlayerInCome = true;
        PanelInteraction.SetActive(false);
        ClickOnObject = false;
    }

    public IEnumerator Type(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            MainText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void SeeClose()
    {
        MainText.text = "";
        PanelSee.SetActive (false);
        StartCoroutine(ReturToMove());
    }
}
