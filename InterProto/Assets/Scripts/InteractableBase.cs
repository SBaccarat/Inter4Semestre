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
        ClickOnObject = true;
        PanelInteraction.SetActive(true);
    }

  

}
