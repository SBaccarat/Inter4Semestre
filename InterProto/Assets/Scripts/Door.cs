using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : InteractableBase {

    public string NextCene; //Nome da cena onde a porta vai levar 

    public Vector2 setPos; //posiçao em que o personagem vai aparecer na prox cena

    //chechagem de colisao, para executar a funçao 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && interactTime)
        { StartCoroutine("DoorTransition"); }
    }

    //funçao pra abrir a porta
    IEnumerator DoorTransition()
    {
      yield return new WaitForSeconds(1);
      SceneManager.LoadScene(NextCene);
      Persistence.NewPos = setPos;
    }
}
