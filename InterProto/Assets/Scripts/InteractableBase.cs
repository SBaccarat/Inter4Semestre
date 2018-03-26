using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour {

   protected bool interactTime; // indica quando o item esta interativo

    // funçao que checa o clique no objeto
    private void OnMouseDown()
    {
        StartCoroutine("CheckPlayer");
    }

    // funçao que mantem o item interativel por serto tempo
    IEnumerator CheckPlayer()
    {
        interactTime = true;
        yield return new WaitForSeconds(5);
        interactTime = false;
    }

}
