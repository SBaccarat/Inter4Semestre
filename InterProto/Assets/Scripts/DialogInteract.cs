using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteract : InteractableBase{

    public GameObject Player;
    public GameObject DialogCanvas;
    public DialogSystem ScriptDialogo;
    public string[] thisSentences;
    bool PlayerInCome;
    

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
    }

    public void Setsentences()
    {
        ScriptDialogo.sentences = thisSentences;
        ScriptDialogo.Index = 0;
    }

}
