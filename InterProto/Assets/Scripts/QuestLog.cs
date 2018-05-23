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
            MainQuestString = "- Tome seu café da manha. \n\n";

       else if (MainQuestStaus == 2)
            MainQuestString = "- Brinque com a sua Boneca, até seu irmao chegar \n\n";
   
       else if (MainQuestStaus == 3)
            MainQuestString = "- Pegue sua toalha e emcontre seu irmao na fila do banheiro, na parte externa do cortiço \n\n";

       else if (MainQuestStaus == 4)
            MainQuestString = "- Pegue sua boneca no quarto e brinque na fila pra passar o tempo \n\n";

       else if (MainQuestStaus == 5)
            MainQuestString = "- Entre no Banheiro \n\n";

       else if (MainQuestStaus == 6)
            MainQuestString = "- Mecha o Almoço... \n\n";

       else if (MainQuestStaus == 7)
            MainQuestString = "- Va até o teraço pedir ao senhor Cota por Gaz. \n\n";

       else if (MainQuestStaus == 8)
            MainQuestString = "- Pergunte para sua irma, se ela sabe onde conseguir cigarro \n\n";

        else if (MainQuestStaus == 9)
            MainQuestString = "- Compre cigarros com o Homem no teraço \n\n";

        else if (MainQuestStaus == 10)
            MainQuestString = "- Entregue o cigarro para o senhor Cota \n\n";

        else if (MainQuestStaus == 11)
            MainQuestString = "- Volte para casa \n\n";

        else
            MainQuestString = "";

        QuestLogText.text = "Coisas pra Fazer \n\n\n" +
            MainQuestString;
    }
}
