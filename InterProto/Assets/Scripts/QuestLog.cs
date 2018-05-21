using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour {

    public static bool Quest01 = true, Quest02, Quest03,Quest04,Quest05;
    private string Quest01String, Quest02String,Quest03String,Quest04String,Quest05String;

    public Text QuestLogText;

    void Update()
    {
        if (Quest01)
            Quest01String = "- Tome seu café da manha. \n\n";
        else
            Quest01String = "";

        if (Quest02)
            Quest02String = "- Brinque com a sua Boneca, até seu irmao chegar \n\n";
        else
            Quest02String = "";

        if (Quest03)
            Quest03String = "- Pegue sua toalha e emcontre seu irmao na fila do banheiro, na parte externa do cortiço \n\n";
        else
            Quest03String = "";

        if (Quest04)
            Quest04String = "- Pegue sua boneca no quarto e brinque na fila pra passar o tempo \n\n";
        else
            Quest04String = "";

        if (Quest05)
            Quest05String = "- Entre no Banheiro \n\n";
        else
            Quest05String = "";

        QuestLogText.text = "Coisas pra Fazer \n\n\n" +
            Quest01String +
            Quest02String +
            Quest03String +
            Quest04String +
            Quest05String ;
    }
}
