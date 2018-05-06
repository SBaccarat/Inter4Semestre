using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteract : InteractableBase {

    public GameObject Player;
    public GameObject DialogCanvas;
    public DialogSystem ScriptDialogo;
    [HideInInspector] public ObjectToInteract objectToInteractScript;
    public string[] préInteractionSentences;
    public string[] pósInteractionSentences;
    public enum Wish { NeedAItem, NeedAQuest, NeedNothing }
    public Wish WhatWish;
    public enum Quest {TurnBlueTheRock,Nothing}
    public Quest quest;
    bool PlayerInCome;
    public bool CharacterFirst;

    private void Start()
    {
        objectToInteractScript = GetComponent<ObjectToInteract>();

    }

    private void Update()
    {

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
    }
    void Interaction()
    {
        DialogCanvas.SetActive(true);
        StartCoroutine(ScriptDialogo.Type());
        ClickOnObject = true;
    }

    public void BottonVer()
    {
        Debug.Log("É um velho japones parado fumando um cigarro");
        ClickOnObject = false;
        PanelInteraction.SetActive(false);
    }

    public void ButtonConversar()
    {
        Setsentences();
        PlayerInCome = true;
        ClickOnObject = false;
        PanelInteraction.SetActive(false);
        if (CharacterFirst)
        {
            ScriptDialogo.Character.SetActive(true);
            ScriptDialogo.OtherPerson.SetActive(false);
        } else
        {
            ScriptDialogo.Character.SetActive(false);
            ScriptDialogo.OtherPerson.SetActive(true);
        }
    }

    public void Setsentences()
    {
        if (WhatWish == Wish.NeedAItem)
        {
            if (objectToInteractScript.ItemState != ObjectToInteract.States.Used)
            {
                ScriptDialogo.sentences = préInteractionSentences;
            } else
            if (objectToInteractScript.ItemState == ObjectToInteract.States.Used)
            {
                ScriptDialogo.sentences = pósInteractionSentences;
            }
        } else
        if (WhatWish == Wish.NeedAQuest)
        {
            if(quest == Quest.TurnBlueTheRock)
            {
                if(Persistence.redBoxStatus != 2 || Persistence.greenBoxStatus != 2)
                {
                    ScriptDialogo.sentences = préInteractionSentences;
                }
                else
                {
                    ScriptDialogo.sentences = pósInteractionSentences;
                }
            }
        }
  
        ScriptDialogo.Index = 0;
    }

}
