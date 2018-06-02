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
    public enum NPC {Mae,Irmao,Irma,Cota,EstranhosFila,Fogao,Vendedor}//caso seja uma quest, qual quest    
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
        else if (WhatNpc == NPC.Irma)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            if (QuestLog.MainQuestStaus == 6)
            {
                SeeText = "Ela segura o Mauricio em uma mao enquanto com a outra aponta deseesperada para o foão...";
                StartCoroutine(Type(SeeText));
            }
            else
            {
                SeeText = "Ela parece cançada, triste e impaciente. Melhor pegar o botijao logo... ";
                StartCoroutine(Type(SeeText));
            }
        }
        else if (WhatNpc == NPC.EstranhosFila)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "Sao duas pessoas que moram aqui conversando, acho q se eu chegar mais perto eu consigo ouvir ...";
            StartCoroutine(Type(SeeText));
        }
        else if (WhatNpc == NPC.Fogao)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "Um fogao velho e caindo aos pedaços. É todo improvidado, e sempre da ruim!!";
            StartCoroutine(Type(SeeText));
        }
        else if (WhatNpc == NPC.Cota)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "Um Senhor japones, ele fuma um cigarro, e olha pro ceu com um olhar eestranho...";
            StartCoroutine(Type(SeeText));
        }
        else if (WhatNpc == NPC.Vendedor)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "É um homem bigodudo, bem diferente de como eu imaginava. Nao parece tao assustador, mas tem um olhar suspeito...";
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

        if (WhatNpc == NPC.Mae)
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
            else if (QuestLog.MainQuestStaus == 4)
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

            if (QuestLog.MainQuestStaus < 6)
            {
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
            else if (QuestLog.MainQuestStaus > 6)
            {
                CharacterFirst = true;
                InteractionSentences = new string[9];
                InteractionSentences[0] = "Tu chegou a passar um tempo lá naquele prédio que caiu né?";
                InteractionSentences[1] = "sim fiquei quase um ano, sai de lá pq não dava não, quando cheguei la tinha água até o 6 andar, tinha jeito n ";
                InteractionSentences[2] = "caraca, tinha conhecido lá?";
                InteractionSentences[3] = "uma prima tava lá, mas ela já me procurou, ela n tava lá na hora do fogo tava trabalhando";
                InteractionSentences[4] = "ao menos ela não se machucou né??";
                InteractionSentences[5] = "é mas ela perdeu tudinho, sobrou nem os documentos dela, mas pelo que ela falou a prefeitura ta ajudando";
                InteractionSentences[6] = "ajudando com oq.";
                InteractionSentences[7] = "judando a piorar a desgraça";
                InteractionSentences[8] = "só deus na causa mesmo, Jesus ajuda esse povo";
            }
        }
        else if (WhatNpc == NPC.Irma)
        {

            if (QuestLog.MainQuestStaus == 6)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Anda Logo Mana!! Eu sou uma Só!";

            }
            else if (QuestLog.MainQuestStaus == 7)
            {
                CharacterFirst = false;
                InteractionSentences = new string[2];
                InteractionSentences[0] = "Ta esperando o que menina? Vai logo arrumar esse gaz!!";
                InteractionSentences[1] = "To indo Mana, calma ...";
            }
            else if (QuestLog.MainQuestStaus == 8)
            {
                CharacterFirst = true;
                InteractionSentences = new string[10];
                InteractionSentences[0] = "Mana o senhor Cota disse que pra ele ajudar com o gás ele quer um maço";
                InteractionSentences[1] = "Um maço de cigarro? Maldito vicio em, acho que tem um maço da tia do lado da tv….";
                InteractionSentences[2] = "To vendo nao Mana";
                InteractionSentences[3] = "A esquece o Evenson levou a porcaria do cigarro, ai que raiva desse menino.... Vc vai ter que ir comprar mais";
                InteractionSentences[4] = "Ta bom... Como eu fasso?";
                InteractionSentences[5] = "ó presta atenção, se vai lá em baixo no terreo.";
                InteractionSentences[6] = "E dai ??";
                InteractionSentences[7] = "tem um cara com cara de mal, mas ele é bem de boas, só voce falar que os cigarros são pra tia Nalda que ele vai te dar";
                InteractionSentences[8] = "ta ta entendi";
                InteractionSentences[9] = "Toma o dinheiro";
                QuestLog.MainQuestStaus = 9;
            }

        }
        else if (WhatNpc == NPC.Fogao)
        {
            if (QuestLog.MainQuestStaus == 6)
            {
                CharacterFirst = true;
                InteractionSentences = new string[8];
                InteractionSentences[0] = "Mana............. O fogo sumiu !!";
                InteractionSentences[1] = "O gás deve ter acabado. Vou ficar olhando o mauricio aq e voce vai atras do gás pra terminarmos a comida!";
                InteractionSentences[2] = "Onde que eu pego o gaz mana ??";
                InteractionSentences[3] = "Sabe aquele senhor Cota? Um japonês que vive reclamando e falando com as paredes?";
                InteractionSentences[4] = "Sei.. Ele tem cara de bravo...";
                InteractionSentences[5] = "Ele vai emprestar o gás, ele sempre empresta, ele deve de estar no terraço fumando.";
                InteractionSentences[6] = "Onde é o terraço msm mana ?";
                InteractionSentences[7] = "No final desse corredor tem uma escada, dai é só subir. Corre Lá!";
                QuestLog.MainQuestStaus = 7;
            }
        }
        else if (WhatNpc == NPC.Cota)
        {
            if (QuestLog.MainQuestStaus == 7)
            {
                CharacterFirst = true;
                InteractionSentences = new string[9];
                InteractionSentences[0] = "senhor Cota?";
                InteractionSentences[1] = "Diga jovem, ta dando pé ai?";
                InteractionSentences[2] = "ham??!!";
                InteractionSentences[3] = "Ta precisando de algo menina?";
                InteractionSentences[4] = "O gás da minha casa acabou… minha irmã disse que voce podia ajudar";
                InteractionSentences[5] = "Ajudar até posso, mas se tem q me ajudar primeiro";
                InteractionSentences[6] = "O que voce quer senhor";
                InteractionSentences[7] = "Este foi meu ultimo cigarro pode arrumar um maço para mim?";
                InteractionSentences[8] = "Acho que tem um maço lá em casa, já volto";
                QuestLog.MainQuestStaus = 8;
            }
            if (QuestLog.MainQuestStaus == 10)
            {
                CharacterFirst = false;
                InteractionSentences = new string[5];
                InteractionSentences[0] = "então o que temos aqui jovem?";
                InteractionSentences[1] = "ta aqui o seu cigarro senhor";
                InteractionSentences[2] = "muito obrigado minha pequena, eu ja sabia que você ia voltar e pedi para um rapaz levar o botijao até a sua casa";
                InteractionSentences[3] = "obrigada senhor cota";
                InteractionSentences[4] = "Agora vocês podem terminar o almoço.";
                QuestLog.MainQuestStaus = 11;
            }
        }
        else if (WhatNpc == NPC.Vendedor)
        {
            if (QuestLog.MainQuestStaus == 9)
            {
                CharacterFirst = false;
                InteractionSentences = new string[6];
                InteractionSentences[0] = "que q se quer guria?";
                InteractionSentences[1] = "cigarro pra titia Nilda";
                InteractionSentences[2] = "cigarro pra Nilda, cadê o dinheiro?";
                InteractionSentences[3] = "eu tenho aqui os 3 reais";
                InteractionSentences[4] = "bele bele, ta aq o cigarro";
                InteractionSentences[5] = "obrigado moço";
                QuestLog.MainQuestStaus = 10;
            }
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
