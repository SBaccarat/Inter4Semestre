using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour {

    public static int MainQuestStaus;
    private string MainQuestString;

    public Text QuestLogText;

    void Update()
    {
        if (MainQuestStaus == 1)
            MainQuestString = "- Tome seu café da manhã. \n\n";

       else if (MainQuestStaus == 2)
            MainQuestString = "- Brinque com sua boneca, até seu irmão chegar. \n\n";
   
       else if (MainQuestStaus == 3)
            MainQuestString = "- Pegue sua toalha e encontre seu irmão na fila do banheiro, na parte externa do cortiço \n\n";

       else if (MainQuestStaus == 4)
            MainQuestString = "- Pegue sua boneca no quarto e brinque na fila pra passar o tempo \n\n";

       else if (MainQuestStaus == 5)
            MainQuestString = "- Entre no banheiro \n\n";

       else if (MainQuestStaus == 6)
            MainQuestString = "- Mecha o Almoço... \n\n";

       else if (MainQuestStaus == 7)
            MainQuestString = "- Va até o teraço pedir gás ao senhor Cota  \n\n";

       else if (MainQuestStaus == 8)
            MainQuestString = "- Pergunte para sua irmã, onde pode conseguir cigarro \n\n";

        else if (MainQuestStaus == 9)
            MainQuestString = "- Compre cigarros com o homem no térrio \n\n";

        else if (MainQuestStaus == 10)
            MainQuestString = "- Entregue o cigarro para o senhor Cota \n\n";

        else if (MainQuestStaus == 11)
            MainQuestString = "- Volte para casa \n\n";

        else
            MainQuestString = "";

        QuestLogText.text = "Coisas para Fazer \n\n" +
            MainQuestString;
    }
}
