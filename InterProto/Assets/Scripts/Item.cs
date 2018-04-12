using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableBase {


    public GameObject ItemIcon; //icone do feedback por ter pego o item

    private void Update()
    { 
        // checa se o item esta pego ou n. se em uma cena exite um item que ja foi pego, ele é destruido
        if (!Persistence.itemAvailable)
        {   ItemIcon.SetActive(true);
            Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //chechagem de colisao, para executar a funçao 
        if (collision.CompareTag("Player") && interactTime)
        { Interaction(); }
    }

    void Interaction()
    {
        // muda o status do item para pego
        Persistence.itemAvailable = false;
    }
}
