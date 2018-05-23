using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {

    public Text MainText;
    static public string[] sentences;
    static public int Index;
    public float typingSpeed;
    public GameObject NextButton;
    public GameObject Character;
    public GameObject Mae;
    public GameObject Stte;
    public GameObject Irmao;
    public GameObject Irmã;
    public GameObject RandomNpc1;
    public GameObject RandomNpc2;
    public GameObject OtherPerson;
    public GameObject Everything;
    bool callOneTime;
    static public bool FirstDialog = true;
    static public bool StartType;

    private void Update()
    {
        if (FirstDialog)
        {
            Everything.SetActive(true);
            InteractableBase.ClickOnObject = true;         
            Index = 0;

            if (Persistence.Scene == 1)
            {
                if (Persistence.SceneQuartoStatus == 1)
                {
                    Character = Stte;
                    OtherPerson = Mae;
                    sentences = new string[3];
                    sentences[0] = "Eu nao vou mais falar ou você levanta ou vai ficar sem pão hoje!";
                    sentences[1] = "Hmmm... Eu ainda to com sono mãe...";
                    sentences[2] = "Levanta logo menina, seu irmao ja foi até buscar agua, e você dormindo!! Come logo seu pao, e nao reclama!";

                }
                else
                if (Persistence.SceneQuartoStatus == 2)
                {
                    Character = Irmao;
                    OtherPerson = Mae;
                    sentences = new string[8];
                    sentences[0] = "Porque demorou tanto em menino?";
                    sentences[1] = "Nem começa, tenho culpa não, os homi tava tocando o povo da rua, não dava para passar! Achou q demorei vai voce!";
                    sentences[2] = "E deixar você cuidando do mauricio? Nem ferrando, seu moleque!";
                    sentences[3] = "Eu não sou moleque não !!";
                    sentences[4] = "Ta ta ta, não enche as minhas ventas! Pega a sua irmã e leva pra tomar banho.";
                    sentences[5] = "Calma, eu tenho que fazer uma fita antes, é o tempo dela pegar a toalha e me encontrar na fila...";
                    sentences[6] = "Oxi!! fazer o que moleque?? Ce sabe que tem que levar ela ";
                    sentences[7] = "Nao sou moleque!! E ela tbm n é mais criança. o caminho é facil, só decer a escada e ir pra esquerda até o patio!";
                }else
                if (Persistence.SceneQuartoStatus == 3)
                {
                    Character = Irmao;
                    OtherPerson = Irmã;
                    sentences = new string[7];
                    sentences[0] = "Tem como voce me ajudar Everson?ou eu cozinho ou cuido do Mauricio";
                    sentences[1] = "Ele não para de chorar eu já cansei";
                    sentences[2] = "Para de ser idiota menino, pega ele no colo!! AONDE VOCÊ PENSA QUE VAI???";
                    sentences[3] = "Eu vou sair pra fumar se vira ai...";
                    sentences[4] = "Como assim? não, Everson!! EVERSON!! Você vai ver só quando a mãe voltar.";
                    sentences[5] = "Nem to te ouvindo mais.. (voz de lonje)";
                    sentences[6] = "Stteffany me ajuda aqui menina, mexe a panela pra n queimar o almoço! Anda rapido!";
                    QuestLog.MainQuestStaus = 6;
                }
            }
            if (Persistence.Scene == 4 && QuestLog.MainQuestStaus == 5)
            {
                    Character = Stte;
                    OtherPerson = Irmao;
                    sentences = new string[2];
                    sentences[0] = "Vem Logo Stte!!! É a sua vez... Se nao Andar logo vai perder. ";
                    sentences[1] = "To indo...";      
            }
            OtherPerson.SetActive(true);
            StartCoroutine(Type());
            FirstDialog = false;
        }

        if (StartType)
        {
            StartCoroutine(Type());
            StartType = false;
        }
        NextButton.SetActive(true);

    }

    public IEnumerator Type()
    {
        foreach(char letter in sentences[Index].ToCharArray())
        {
            MainText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        //NextButton.SetActive(false);
        if (Index < sentences.Length - 1)
        {
            Character.SetActive(!Character.activeSelf);
            OtherPerson.SetActive(!OtherPerson.activeSelf);
            Index++;
            MainText.text = "";
            StopAllCoroutines();
            StartCoroutine(Type());
        } else
        {
            Character.SetActive(false);
            OtherPerson.SetActive(false);
            MainText.text = "";
            NextButton.SetActive(false);
            Everything.SetActive(false);
            callOneTime = true;
            StopAllCoroutines();
            Character = Stte;
            StartCoroutine(InteractableBase.ReturToMove());

        }
    }

}
