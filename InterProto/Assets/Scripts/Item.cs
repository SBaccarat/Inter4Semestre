using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableBase {


    public GameObject ItemIcon; //icone do feedback por ter pego o item
    public GameObject Player;
    bool PlayerInComeToPick;

    private void Update()
    { 
        // checa se o item esta pego ou n. se em uma cena exite um item que ja foi pego, ele é destruido
        if (!Persistence.itemAvailable)
        {
            ItemIcon.SetActive(true);
            Destroy(gameObject);
        }

        if (PlayerInComeToPick)
        {
            if (Player.transform.position.x < transform.position.x)
            { CliclToMove.Direçao = 1; }

            if (Player.transform.position.x > transform.position.x)
            { CliclToMove.Direçao = -1; }

            if (Player.transform.position.x > transform.position.x - .8f && Player.transform.position.x < transform.position.x + .8f)
            {
                Interaction();
                CliclToMove.Direçao = 0;
                PlayerInComeToPick = false;
            }
        }
    }


    void Interaction()
    {
        // muda o status do item para pego
        Persistence.itemAvailable = false;
    }

   public void BottonVer()
    {
        Debug.Log("É uma caixa vermelha");
        ClickOnObject = false;
        PanelInteraction.SetActive(false);
    }

    public void ButtonPegar()
    {
        PlayerInComeToPick = true;
        ClickOnObject = false;
        PanelInteraction.SetActive(false);
    }

}
