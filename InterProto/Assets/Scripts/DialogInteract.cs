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
                SeeText = "Minha mãe parece brava, melhor eu fazer o que ela mandou...";
                StartCoroutine(Type(SeeText));
                }
                else if(QuestLog.MainQuestStaus == 2)
            {
                SeeText = "Agora ela parece estar mais calma.";
                StartCoroutine(Type(SeeText));
                }
                else {
                SeeText = "Ela ta ocupada, cuidando do meu irmãozinho.";
                StartCoroutine(Type(SeeText));
            }
            }
        else if (WhatNpc == NPC.Irmao)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            if (QuestLog.MainQuestStaus == 3)
            {
                SeeText = "Meu irmão ... Ele ta me esperando, parece que ele acabou de chegar.";
                StartCoroutine(Type(SeeText));
            }else
            {
                SeeText = "Meu irmão ... Ele ta me esperando...";
                StartCoroutine(Type(SeeText));
            }
        }
        else if (WhatNpc == NPC.Irma)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            if (QuestLog.MainQuestStaus == 6)
            {
                SeeText = "Ela segura o Mauricio em uma mão enquanto com a outra aponta deseesperada para o fogão...";
                StartCoroutine(Type(SeeText));
            }
            else
            {
                SeeText = "Ela parece cansada, triste e impaciente. Melhor pegar o botijão logo... ";
                StartCoroutine(Type(SeeText));
            }
        }
        else if (WhatNpc == NPC.EstranhosFila)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "Sao duas pessoas que moram aqui conversando, acho que se eu chegar mais perto eu consigo ouvir...";
            StartCoroutine(Type(SeeText));
        }
        else if (WhatNpc == NPC.Fogao)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "Um fogão velho e caindo aos pedaços. É todo improvidado e sempre quebra!!";
            StartCoroutine(Type(SeeText));
        }
        else if (WhatNpc == NPC.Cota)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "Um Senhor japonês, ele fuma um cigarro, e olha pro céu com um olhar estranho...";
            StartCoroutine(Type(SeeText));
        }
        else if (WhatNpc == NPC.Vendedor)//se a quest for x, checa se a missao foi concluida e muda o dialogo
        {
            SeeText = "É um homem bigodudo, bem diferente de como eu imaginava. Não parece tao assustador, mas tem um olhar suspeito...";
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
                    InteractionSentences[0] = "Tá cega menina? pega seu pão e come, e não me enche mais a paciência!";
                    InteractionSentences[1] = "Tá bom..";
                }
                else if (Persistence.paoStatus == 2)
                {
                    CharacterFirst = true;
                    InteractionSentences = new string[3];
                    InteractionSentences[0] = "Pronto mãe.";
                    InteractionSentences[1] = "Ótimo! Agora brinca quietinha aí que seu irmão já está voltando, dai ele leva você pro banho.";
                    InteractionSentences[2] = "Tá! Vou brincar, minha bela bailarina me aguarda!";
                    QuestLog.MainQuestStaus = 2;
                }
            }
            else if (QuestLog.MainQuestStaus == 2)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Me ouviu não menina?! Vai brincar, e some da minha frente!!";
            }
            else if (QuestLog.MainQuestStaus > 2)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "To ocupada menina, vai arranjar o que fazer!!";
            }
        }
        else if (WhatNpc == NPC.Irmao)
        {

            if (QuestLog.MainQuestStaus <= 3)
            {
                if (Persistence.toalhaStatus == 1)
                {
                    CharacterFirst = false;
                    InteractionSentences = new string[7];
                    InteractionSentences[0] = "E ai Stte, cê chegou rapido até.";
                    InteractionSentences[1] = "Brigado.. A fila vai demorar muito?";
                    InteractionSentences[2] = "Vai sim.. Sempre demora..";
                    InteractionSentences[3] = "Eu posso brincar pra passar o tempo?";
                    InteractionSentences[4] = "Você por acaso trouxe a boneca?";
                    InteractionSentences[5] = "Não..";
                    InteractionSentences[6] = "Vai ter que ir buscar então.. Se você perder a fila eu te dou um soco!";
                    QuestLog.MainQuestStaus = 4;
                }
                else
                {
                    CharacterFirst = true;
                    InteractionSentences = new string[4];
                    InteractionSentences[0] = "Cheguei..";
                    InteractionSentences[1] = "E a toalha?";
                    InteractionSentences[2] = "Esqueci..";
                    InteractionSentences[3] = "Que vontade de te dar um soco.. Vai lá pegar logo!";

                }
            }
            else if (QuestLog.MainQuestStaus == 4)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Brinca ai no chão então.. Nossa vez ainda vai demorar..";
            }
            else if (QuestLog.MainQuestStaus >= 5)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Anda logo, cê vai perder a vez.. To falando..";
            }
            else 
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Sa daqui minina burra, c ta no logar errado do jogo!";
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
                InteractionSentences[0] = "Teu irmão tinha um quarto duas quadras pra lá né? Cimentaram tudo não foi?";
                InteractionSentences[1] = "Foi sim, os pm tiraram todo mundo de dentro e já tinha um cara colocando os tijolos na porta!";
                InteractionSentences[2] = "Nossa!";
                InteractionSentences[3] = "Deu tempo nem do junior tirar o fogão que ele tinha arrumado.";
                InteractionSentences[4] = "É foda viu, não deixarem a gente tirar o pouco que temos, ficou sabendo da criança que ficou presa?";
                InteractionSentences[5] = "Isso é mentira, conheço a peste, o moleque tinha saído mais cedo pra arrumar pedra.";
                InteractionSentences[6] = "Esses noia é foda..";
                InteractionSentences[7] = "A mãe não conseguiu achar o traste, depois do tumulto saiu falando que tinham cimentado o filho lá.";
                InteractionSentences[8] = "Onde já se viu isso gente..";
            }
            else if (QuestLog.MainQuestStaus > 6)
            {
                CharacterFirst = true;
                InteractionSentences = new string[9];
                InteractionSentences[0] = "Cê chegou a passar um tempo lá naquele prédio que caiu né?";
                InteractionSentences[1] = "Sim, fiquei quase um ano, sai de lá por que não dava não, quando cheguei lá tinha água até o sexto andar, tinha jeito não.";
                InteractionSentences[2] = "Caraca, tinha conhecido lá?";
                InteractionSentences[3] = "Uma prima tava lá, mas ela já me procurou, ela não tava lá na hora do fogo tava trabalhando.";
                InteractionSentences[4] = "Ao menos ela não se machucou, né??";
                InteractionSentences[5] = "É, mas ela perdeu tudinho, sobrou nem os documentos dela, mas pelo que ela falou a prefeitura tá ajudando.";
                InteractionSentences[6] = "Ajudando com o que?";
                InteractionSentences[7] = "Ajudando a piorar a desgraça..";
                InteractionSentences[8] = "Só Jesus na causa mesmo..";
            }
        }
        else if (WhatNpc == NPC.Irma)
        {

            if (QuestLog.MainQuestStaus == 6)
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Anda logo mana! Eu sou uma só!";

            }
            else if (QuestLog.MainQuestStaus == 7)
            {
                CharacterFirst = false;
                InteractionSentences = new string[2];
                InteractionSentences[0] = "Ta esperando o que menina? Vai logo arrumar esse gás!";
                InteractionSentences[1] = "To indo mana, calma..";
            }
            else if (QuestLog.MainQuestStaus == 8)
            {
                CharacterFirst = true;
                InteractionSentences = new string[10];
                InteractionSentences[0] = "Mana o senhor Cota disse que pra ele ajudar com o gás ele quer um maço de cigarro..";
                InteractionSentences[1] = "Um maço de cigarro? Maldito vicio em, acho que tem um maço da tia do lado da tv..";
                InteractionSentences[2] = "To vendo não mana.";
                InteractionSentences[3] = "A esqueçe o Evenson levou a porcaria do cigarro, ai que raiva desse menino.. Você vai ter que ir comprar mais.";
                InteractionSentences[4] = "Tá bom... Como eu faço isso?";
                InteractionSentences[5] = "Ó presta atenção, cê vai lá em baixo no terréo.";
                InteractionSentences[6] = "E depois..??";
                InteractionSentences[7] = "Tem um cara mal encarado, mas ele é bem de boas, só você falar que o maço de cigarro é pra tia Nalda que ele vai te vender..";
                InteractionSentences[8] = "Tá tá entendi";
                InteractionSentences[9] = "Toma o dinheiro, vê se não perde.";
                QuestLog.MainQuestStaus = 9;
            }
            else 
            {
                CharacterFirst = false;
                InteractionSentences = new string[1];
                InteractionSentences[0] = "Anda logo maninha!!";

            }

        }
        else if (WhatNpc == NPC.Fogao)
        {
            if (QuestLog.MainQuestStaus == 6)
            {
                CharacterFirst = true;
                InteractionSentences = new string[8];
                InteractionSentences[0] = "Mana. O fogo sumiu!";
                InteractionSentences[1] = "O gás deve ter acabado. Vou ficar olhando o Mauricio aqui e você vai atras do gás pra terminarmos a comida!";
                InteractionSentences[2] = "Onde que eu pego o gás mana?";
                InteractionSentences[3] = "Sabe aquele senhor Cota? Aquele japonês que vive reclamando e falando com as paredes..";
                InteractionSentences[4] = "Sei.. Ele tem cara de bravo..";
                InteractionSentences[5] = "Ele vai emprestar o gás, ele sempre empresta, ele deve estar no terraço fumando.";
                InteractionSentences[6] = "Onde é o terraço mesmo mana?";
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
                InteractionSentences[0] = "Senhor Cota?";
                InteractionSentences[1] = "Diga jovem, ta dando pé ai?";
                InteractionSentences[2] = "Ham??!!";
                InteractionSentences[3] = "Tá precisando de algo menina?";
                InteractionSentences[4] = "O gás da minha casa acabou… minha irmã disse que voce podia ajudar.";
                InteractionSentences[5] = "Ajudar até posso, mas se tem q me ajudar primeiro.";
                InteractionSentences[6] = "O que você quer senhor?";
                InteractionSentences[7] = "Este foi meu ultimo cigarro pode arrumar um maço para mim?";
                InteractionSentences[8] = "Acho que tem um maço lá em casa, já volto.";
                QuestLog.MainQuestStaus = 8;
            }
            else if (QuestLog.MainQuestStaus == 10)
            {
                CharacterFirst = false;
                InteractionSentences = new string[5];
                InteractionSentences[0] = "Então o que temos aqui jovem?";
                InteractionSentences[1] = "Tá aqui o seu cigarro senhor..";
                InteractionSentences[2] = "Muito obrigado minha pequena, eu já sabia que você ia voltar e pedi para um rapaz levar o botijao até a sua casa.";
                InteractionSentences[3] = "Obrigada senhor Cota.";
                InteractionSentences[4] = "Agora vocês podem terminar o almoço.";
                QuestLog.MainQuestStaus = 11;
            }
            else
            {
                CharacterFirst = false;
                InteractionSentences = new string[3];
                InteractionSentences[0] = "Tá dando pé ai?";
                InteractionSentences[1] = "Ainda não entendi o que isso significa...";
                InteractionSentences[2] = "Hehehe... Esquece jovem.";
            }
        }
        else if (WhatNpc == NPC.Vendedor)
        {
            if (QuestLog.MainQuestStaus == 9)
            {
                CharacterFirst = false;
                InteractionSentences = new string[6];
                InteractionSentences[0] = "Que que se quer garota?";
                InteractionSentences[1] = "Cigarro pra titia Nilda.";
                InteractionSentences[2] = "Cigarro pra Nilda.. Cadê o dinheiro?";
                InteractionSentences[3] = "Tá aqui.";
                InteractionSentences[4] = "Belê belê, tá aqui o cigarro.";
                InteractionSentences[5] = "Obrigado senhor.";
                QuestLog.MainQuestStaus = 10;
            }
            else
            {
                CharacterFirst = false;
                InteractionSentences = new string[3];
                InteractionSentences[0] = "E ai garota, querendo alguma coisa ?";
                InteractionSentences[1] = "Não, nada por agora.";
                InteractionSentences[2] = "Precisando eu to aqui...";
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
