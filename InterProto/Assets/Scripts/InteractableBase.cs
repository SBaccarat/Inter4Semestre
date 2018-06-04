using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour {

   protected bool interactTime; // indica quando o item esta interativo
   static public bool ClickOnObject;
   public BordaDeCatupiry BordaScript;

   public GameObject PanelInteraction;

    // funçao que checa o clique no objeto
    private void OnMouseDown()
    {
        if(!ClickOnObject && BordaScript.CanInteract)
        {
            ClickOnObject = true;
            PanelInteraction.SetActive(true);
        }
        //StartCoroutine(OpenInteractUI());
    }

    public void CallButton()
    {
        if (!ClickOnObject )
        {
            ClickOnObject = true;
            PanelInteraction.SetActive(true);
        }
    }

    static public IEnumerator ReturToMove()
    {
        yield return new WaitForSeconds(0.04f);
        ClickOnObject = false;
    }

}
