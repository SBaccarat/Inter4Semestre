using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableBase {


    public GameObject Player;
    public enum Items { RedBox, GreenBox }
    public Items WhatIten;
    enum States {Avaliable,Piked,Used}
    States ItemState;
    bool PlayerInComeToPick;

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
        }
    }

    private void Update()
    {
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
        ItemState = States.Piked;
    }

   public void BottonVer()
    {
        Debug.Log("É uma caixa vermelha");
        ClickOnObject = false;
        PanelInteraction.SetActive(false);
    }

    public void ButtonPegar()
    {
        PlayerInComeToPick = true;
        ClickOnObject = false;
        PanelInteraction.SetActive(false);
    }

}
