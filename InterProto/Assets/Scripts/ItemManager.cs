using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    bool PodePegar = false;

    public GameObject Icone;

    private void OnTriggerEnter2D(Collider2D collision)
    {  if (collision.CompareTag("Player")) { PodePegar = true; } }

    private void OnTriggerExit2D(Collider2D collision)
    {  if (collision.CompareTag("Player")) { PodePegar = false;} }


    public void PegaItem()
    {
        if(PodePegar)
        {
            Icone.SetActive(true);
            Destroy(gameObject);
        }
    }

}
