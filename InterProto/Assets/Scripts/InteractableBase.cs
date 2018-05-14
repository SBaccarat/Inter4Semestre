using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour {

   protected bool interactTime; // indica quando o item esta interativo
   static public bool ClickOnObject;


   public GameObject PanelInteraction;

    // funçao que checa o clique no objeto
    private void OnMouseDown()
    {
        if(!ClickOnObject)
        StartCoroutine(OpenInteractUI());
    }

    IEnumerator OpenInteractUI()
    {
        ClickOnObject = true;
        PanelInteraction.SetActive(true);
        yield return new WaitForSeconds(10);
        ClickOnObject = false;
        PanelInteraction.SetActive(false);
    }

    static public IEnumerator ReturToMove()
    {
        yield return new WaitForSeconds(0.04f);
        ClickOnObject = false;
    }

}
