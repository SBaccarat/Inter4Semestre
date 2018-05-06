using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInvertory : MonoBehaviour {

    public GameObject RedBoxIcon; //icone do feedback por ter pego o item
    public GameObject GreenBoxIcon; //icone do feedback por ter pego o item
    public GameObject cigarroIcon; // icone do cigarro

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

        if (Persistence.cigarroStatus == 1)
        {
            cigarroIcon.SetActive(true);
        }
        else
        {
           cigarroIcon.SetActive(false);
        }
    }
}
