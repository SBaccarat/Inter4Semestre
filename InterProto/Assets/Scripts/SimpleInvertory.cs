using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInvertory : MonoBehaviour {

    public GameObject RedBoxIcon; //icone do feedback por ter pego o item
    public GameObject GreenBoxIcon; //icone do feedback por ter pego o item
    public GameObject cigarroIcon; // icone do cigarro
    public GameObject toalhaIcon;
    public GameObject BonecaIcon;
    public GameObject MONEYBITCH;
    void Update () {

        

        // checa se o item esta pego ou n. se em uma cena exite um item que ja foi pego, ele é destruido
        if (Persistence.redBoxStatus == 1)
        {
            RedBoxIcon.SetActive(true);
        } else
        {
            RedBoxIcon.SetActive(false);
        }

        if (Persistence.greenBoxStatus == 1)
        {
            GreenBoxIcon.SetActive(true);
        }else
        {
            GreenBoxIcon.SetActive(false);
        }

        if (QuestLog.MainQuestStaus == 10)
        {
            cigarroIcon.SetActive(true);
        }
        else
        {
           cigarroIcon.SetActive(false);
        }
        if (Persistence.toalhaStatus == 1)
        {
            toalhaIcon.SetActive(true);
        }
        else
        {
            toalhaIcon.SetActive(false);
        }

        if (MiniGameInteract.Piked)
        {
            BonecaIcon.SetActive (true);
        }
        else
        {
            BonecaIcon.SetActive(false);
        }
        if (QuestLog.MainQuestStaus == 9)
        {
            MONEYBITCH.SetActive(true);
        }
        else
        {
            MONEYBITCH.SetActive(false);
        }
    }
}
