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
    //public GameObject Stair;
    [HideInInspector] public ObjectToInteract objectToInteractScript;//savla o game script do objeto interativel(que tbm pode estar em um npc)
    string[] InteractionSentences;//dialogos que ele tem antes de vc fazer o q ele quer 
    public enum NPC {Mae,Irmao,EstranhosFila}//caso seja uma quest, qual quest    
    public NPC WhatNpc;
    bool PlayerInCome;//player se movendo   
    bool CharacterFirst;// é true quando o personagem comessa falando em um dialogo 

    string SeeText;//texto da primeira fala do npc
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
        if (MainText.text == SeeText)
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
        //checa quem vai falar primeiro 
        if (CharacterFirst)
        {
            ScriptDialogo.Character.SetActive(true);
            ScriptDialogo.OtherPerson.SetActive(false);
        }
        else
        {
            ScriptDialogo.Character.SetActive(false);
            ScriptDialogo.OtherPerson.SetActive(true);
        }

        DialogCanvas.SetActive(true);
        DialogSystem.StartType = true;

    }

    public void ButtonQuit()
    {
        StartCoroutine(InteractableBase.ReturToMove());
        PanelInteraction.SetActive(false);
    }

    public void BottonVer()//Funçao que deve ser chamada caso o botao ver desse item seja pressionado 
    {
             if (WhatNpc == NPC.Mae)//se a quest for x, checa se a missao foi concluida e muda o dialogo
            {
                if (QuestLog.MainQuestStaus == 1)
                {
                SeeText = "Minha mae. Ela ja ta me olhando brava...";
                StartCoroutine(Type(SeeText));
                }
                else if(QuestLog.MainQuestStaus == 2)
            {
                SeeText = "Agora ela ta mais calma.";
                StartCoroutine(Type(SeeText));
                }
                else {
                SeeText = "Ela ta ocupada, cuidando do meu Irmaozinho.";
                StartCoroutine(Type(SeeText));
            }
            }
        else if (WhatNpc == NPC.Irmao)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            if (QuestLog.MainQuestStaus == 3)
            {
                SeeText = "Meu irmao ... Ele ta me esperando, parece que ele acabou de chegar.";
                StartCoroutine(Type(SeeText));
            }else
            {
                SeeText = "Meu irmao ... Ele ta me esperando...";
                StartCoroutine(Type(SeeText));
            }
        }
        else if (WhatNpc == NPC.EstranhosFila)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "Sao duas pessoas que moram aqui conversando, acho q se eu chegar mais perto eu consigo ouvir ...";
            StartCoroutine(Type(SeeText));
        }

        PanelSee.SetActive(true); //painel de texto fica true 
        PanelInteraction.SetActive(false);//painel de botoes desliga 
    }

    public void ButtonConversar() //é chamado quando quando o botao de conversar do npc e apertado
    {
        Setsentences();//checa as sentenças 
        PlayerInCome = true;//player se mexe
        PanelInteraction.SetActive(false);
        ScriptDialogo.OtherPerson = ThisPerson;
        
    }

    public void Setsentences()//funçao que checa as sentensas 
    {
 
       if(WhatNpc == NPC.Mae)
        {
            if (QuestLog.MainQuestStaus == 1)
            {
                if (Persistence.paoStatus != 2)
                {
                    CharacterFirst = false;
                    InteractionSentences = new string[2];
                    InteractionSentences[0] = "Tá cega menina? pega seu pao e come, e não me enche mais a paciência !!";
                    InteractionSentences[1] = "Ta bom ....";
                }
                else if (Persistence.paoStatus == 2)
                {
                    CharacterFirst = true;
                    InteractionSentences = new string[3];
                    InteractionSentences[0] = "Pronto Mae";
                    InteractionSentences[1] = "Isso!! Agora brinca quietinha aí que seu irmão já volta para você ir tomar banho.";
                    InteractionSentences[2] = "Oba! Isso sim!! Minha Bailarina me aguarda!";
                    QuestLog.MainQuestStaus = 2;
                }
            }
            else if (QuestLog.MainQuestStaus == 2)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Me ouviu nao menina ?! Vai brincar!!";
            }
        }
        else if (WhatNpc == NPC.Irmao)
        {

            if (QuestLog.MainQuestStaus == 3)
            {
                if (Persistence.toalhaStatus == 1)
                {
                    CharacterFirst = false;
                    InteractionSentences = new string[7];
                    InteractionSentences[0] = "E ai Stte, ce chegou rapido até.";
                    InteractionSentences[1] = "Brigado hehe... A fila vai demorar muito?";
                    InteractionSentences[2] = "Vai sim... Sempre demora...";
                    InteractionSentences[3] = "Eu posso brincar ?";
                    InteractionSentences[4] = "Você trouxe a boneca ??";
                    InteractionSentences[5] = "Nao ... :(";
                    InteractionSentences[6] = "Vai ter que ir buscar entao... Se vc perder a fila eu te dou um soco!!!";
                    QuestLog.MainQuestStaus = 4;
                }
                else
                {
                    CharacterFirst = true;
                    InteractionSentences = new string[4];
                    InteractionSentences[0] = "Cheguei...";
                    InteractionSentences[1] = "E a toalha ?? ";
                    InteractionSentences[2] = "Esqueci....";
                    InteractionSentences[3] = "Que vontade de te dar um soco... Vai la pegar logo!!!";
              
                }
            }
            else if(QuestLog.MainQuestStaus == 4)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Brinca ai no xao entao... Nossa vez ainda vai demorar...";
            }
            else if (QuestLog.MainQuestStaus == 5)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Anda logo, cê vai perder a vez... to falando... ";
            }
        }
        else if (WhatNpc == NPC.EstranhosFila)
        {
            ScriptDialogo.Character = ScriptDialogo.RandomNpc1;
            ScriptDialogo.OtherPerson = ScriptDialogo.RandomNpc2;

            CharacterFirst = false;
            InteractionSentences = new string[9];
            InteractionSentences[0] = "Teu irmão tinha um quarto duas quadras pra lá né? cimentaram tudo não foi?";
            InteractionSentences[1] = "Foi sim, os PM tiraram todo mundo de dentro e já tinha um cara colocando os tijolos na porta! ";
            InteractionSentences[2] = "Nossa!!.";
            InteractionSentences[3] = "Deu tempo nem do junior tirar o fogão que ele tinha arrumado";
            InteractionSentences[4] = "É foda viu, não deixarem a gente tirar o pouco que temos, ficou sabendo da criança que ficou presa?";
            InteractionSentences[5] = "Isso é mentira, conheço a peste, o moleque tinha saído mais cedo pra arrumar pedra";
            InteractionSentences[6] = "Esses noia é foda ...";
            InteractionSentences[7] = "a mãe não conseguiu achar o traste depois do tumulto saiu falando que tinham cimentado o filho la";
            InteractionSentences[8] = "Onde já se viu isso gente...";
        }

        DialogSystem.sentences = InteractionSentences;
        DialogSystem.Index = 0;

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
