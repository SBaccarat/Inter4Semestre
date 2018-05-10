using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : InteractableBase {


    
    public enum Items { RedBox, GreenBox,cigarro,Toalha,pao}
    public Items WhatIten;
    enum States {Avaliable,Piked,Used}
    States ItemState;

    public GameObject Player;
    bool PlayerInComeToPick;

    public string SeeText;
    float typingSpeed = 0.04f;
    public GameObject PanelSee;
    public GameObject ButtonSee;
    public Text MainText;

    private void Start()
    {
      if(WhatIten == Items.RedBox)
      {
            if (Persistence.redBoxStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.redBoxStatus == 1)
                ItemState = States.Piked;
            if (Persistence.redBoxStatus == 2)
                ItemState = States.Used;
      }else
      if (WhatIten == Items.GreenBox)
      {
            if (Persistence.greenBoxStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.greenBoxStatus == 1)
                ItemState = States.Piked;
            if (Persistence.greenBoxStatus == 2)
                ItemState = States.Used;
      } else 
       if(WhatIten == Items.cigarro)
       {
            if (Persistence.cigarroStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.cigarroStatus == 1)
                ItemState = States.Piked;
            if (Persistence.cigarroStatus == 2)
                ItemState = States.Used;
       }else
       if(WhatIten == Items.Toalha)
       {
            if (Persistence.toalhaStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.toalhaStatus == 1)
                ItemState = States.Piked;
            if (Persistence.toalhaStatus == 2)
                ItemState = States.Used;
        }
        else
       if (WhatIten == Items.pao)
        {
            if (Persistence.paoStatus == 0)
                ItemState = States.Avaliable;
            if (Persistence.paoStatus == 2)
                ItemState = States.Used;
        }

    }

    private void Update()
    {

        if (MainText.text == SeeText)
        {
            ButtonSee.SetActive(true);
        }

        switch (WhatIten)
        {
            case Items.RedBox:
                switch (ItemState)
                {
                    case States.Avaliable:
                        Persistence.redBoxStatus = 0;
                        break;
                    case States.Piked:
                        Persistence.redBoxStatus = 1;
                        break;
                }
                break;
            case Items.GreenBox:
                switch (ItemState)
                {
                    case States.Avaliable:
                        Persistence.greenBoxStatus = 0;
                        break;
                    case States.Piked:
                        Persistence.greenBoxStatus = 1;
                        break;
                }
                break;
            case Items.cigarro:
                switch (ItemState)
                {
                    case States.Avaliable:
                        Persistence.cigarroStatus = 0;
                        break;
                    case States.Piked:
                        Persistence.cigarroStatus = 1;
                        break;
                }
                break;
            case Items.Toalha:
                switch (ItemState)
                {
                    case States.Avaliable:
                        Persistence.toalhaStatus = 0;
                        break;
                    case States.Piked:
                        Persistence.toalhaStatus = 1;
                        break;
                }
                break;
            case Items.pao:
                switch (ItemState)
                {
                    case States.Avaliable:
                        Persistence.paoStatus = 0;
                        break;
                    case States.Used:
                        Persistence.paoStatus = 2;
                        break;
                }
                break;
        }

        // checa se o item esta pego ou n. se em uma cena exite um item que ja foi pego, ele é destruido
        if (ItemState != States.Avaliable)
        {
            Destroy(gameObject);
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


    void Interaction()
    {
        // muda o status do item para pego
        if (WhatIten == Items.pao)
            ItemState = States.Used;
        else
            ItemState = States.Piked;
    }

    public void BottonVer()
    {
        StartCoroutine(Type());
        PanelSee.SetActive(true);
        PanelInteraction.SetActive(false);
    }

    public void ButtonPegar()
    {
        PlayerInComeToPick = true;
        PanelInteraction.SetActive(false);
        ClickOnObject = false;
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
