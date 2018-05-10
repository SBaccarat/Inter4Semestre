using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteract : InteractableBase

//mesmo o nome sendo bizarro esse é o script que controla a inteçaraço com npcs 

{

    public GameObject Player;//salva o objeto do player 
    public GameObject DialogCanvas;//salva o objeto do canvas responsavel por conter as UIs do dialogo 
    public DialogSystem ScriptDialogo;//salva o script responsavel pelos dialogos 
    public GameObject ThisPerson;
    public GameObject Stair;
    [HideInInspector] public ObjectToInteract objectToInteractScript;//savla o game script do objeto interativel(que tbm pode estar em um npc)
    public string[] préInteractionSentences;//dialogos que ele tem antes de vc fazer o q ele quer 
    public string[] pósInteractionSentences;//dialogos dps que vc ja fez o que ele quer 
    public enum Wish { NeedAItem, NeedAQuest, NeedNothing }//o que o npc espera do player       
    public Wish WhatWish;
    public enum Quest {ToalhaEPao,Nothing}//caso seja uma quest, qual quest    
    public Quest quest;
    bool PlayerInCome;//player se movendo   
    public bool CharacterFirst;// é true quando o personagem comessa falando em um dialogo 

    public string preSeeText;//texto da primeira fala do npc
    public string posSeeText;//texto da segunda fala do npc
    float typingSpeed = 0.04f; //velocidade de digitaçao
    public GameObject PanelSee;//painel da opçao ver 
    public GameObject ButtonExitSee;//botao pra pular de texto
    public Text MainText;

    private void Start()
    {
        //pra efeitos de gambiarra puxa o object interact do pnc caso tenha 
        objectToInteractScript = GetComponent<ObjectToInteract>();
    }

    private void Update()
    {
        //verifica se os itens foram escritos para ativar o botao de passar a frase 
        if (MainText.text == posSeeText || MainText.text == preSeeText)
        {
            ButtonExitSee.SetActive(true);
        }
       

    }

    private void FixedUpdate()
    {
        //caso true executa a funçao do player se mover até o objeto e executa a interaçao
        if (PlayerInCome)
        {
            if (Player.transform.position.x < transform.position.x)
            { CliclToMove.Direçao = 1; }
            if (Player.transform.position.x > transform.position.x)
            { CliclToMove.Direçao = -1; }
            if (Player.transform.position.x > transform.position.x - 1.8f && Player.transform.position.x < transform.position.x + 1.8f)
            {   Interaction();
                CliclToMove.Direçao = 0;
                PlayerInCome = false;
            }
        }
    }
    void Interaction()//funçao que chama a interaçao 
    {
        DialogCanvas.SetActive(true);
        StartCoroutine(ScriptDialogo.Type());
    }

    public void BottonVer()//Funçao que deve ser chamada caso o botao ver desse item seja pressionado 
    {
        if (WhatWish == Wish.NeedAItem)//se o sejedo do npc foi um item, checa se o item foi ou nao pego, e muda o dialogo do npc 
        {
            if (objectToInteractScript.ItemState != ObjectToInteract.States.Used)
            {  StartCoroutine(Type(preSeeText)); }
            else if (objectToInteractScript.ItemState == ObjectToInteract.States.Used)
            { StartCoroutine(Type(posSeeText)); }
        }
        else
       if (WhatWish == Wish.NeedAQuest)//se o sejedo do npc foi uma quest, checa se o item foi ou nao pego, e muda o dialogo do npc 
        {
            if (quest == Quest.ToalhaEPao)//se a quest for x, checa se a missao foi concluida e muda o dialogo
            {
                if (Persistence.paoStatus != 2 || Persistence.toalhaStatus != 1)
                { StartCoroutine(Type(preSeeText)); }
                else{ StartCoroutine(Type(posSeeText)); }
            }
        }

        PanelSee.SetActive(true); //painel de texto fica true 
        PanelInteraction.SetActive(false);//painel de botoes desliga 
    }

    public void ButtonConversar() //é chamado quando quando o botao de conversar do npc e apertado
    {
        Setsentences();//checa as sentenças 
        PlayerInCome = true;//player se mexe
        PanelInteraction.SetActive(false);
        DialogSystem.OtherPerson = ThisPerson;
        //checa quem vai falar primeiro 
        if (CharacterFirst)
        {
            ScriptDialogo.Character.SetActive(true);
            DialogSystem.OtherPerson.SetActive(false);
        } else
        {
            ScriptDialogo.Character.SetActive(false);
            DialogSystem.OtherPerson.SetActive(true);
        }
    }

    public void Setsentences()//funçao que checa as sentensas 
    {
        if (WhatWish == Wish.NeedAItem)
        {
            if (objectToInteractScript.ItemState != ObjectToInteract.States.Used)
            { ScriptDialogo.sentences = préInteractionSentences;}
            else if (objectToInteractScript.ItemState == ObjectToInteract.States.Used)
            { ScriptDialogo.sentences = pósInteractionSentences;}
        }
        else if (WhatWish == Wish.NeedAQuest)
        {
            if(quest == Quest.ToalhaEPao)
            {
                if(Persistence.paoStatus != 2 || Persistence.toalhaStatus != 1)
                { ScriptDialogo.sentences = préInteractionSentences;}
                else { ScriptDialogo.sentences = pósInteractionSentences;
                    //Stair.SetActive(true);
                    MiniGameInteract.CanPlay = true;
                }
            }
        }  
        ScriptDialogo.Index = 0;
    }

    public IEnumerator Type(string text)//funçao que escreve o texto letra por letra 
    {
        foreach (char letter in text.ToCharArray()){
            MainText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void SeeClose()//funçao que desliga o texto da observaçao 
    {   MainText.text = "";
        PanelSee.SetActive(false);
        StartCoroutine(ReturToMove());
    }
}
