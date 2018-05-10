using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour {

    public string NextCene; //Nome da cena onde a porta vai levar 
    public Vector2 setPos; //posiçao em que o personagem vai aparecer na prox cena
    protected bool interactTime = false; // indica quando o item esta interativo
    public bool IsStair=false;

    private void OnMouseDown()
    {
        if (!IsStair)
        {
            interactTime = true;
            StartCoroutine("InteractableDoor");
        }
        else
        {
            StartCoroutine(DoorTransition());
        }
    }

    //chechagem de colisao, para executar a funçao 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && interactTime)
        { StartCoroutine("DoorTransition"); }
    }
   
    IEnumerator InteractableDoor()
    {
        yield return new WaitForSeconds(5);
        interactTime = false;
    }

    //funçao pra abrir a porta
    IEnumerator DoorTransition()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(NextCene);
        Persistence.NewPos = setPos;
    }

}
