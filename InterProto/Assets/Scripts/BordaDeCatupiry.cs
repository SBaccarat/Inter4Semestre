using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordaDeCatupiry : MonoBehaviour {

    public Transform PlayerTrasnform;
    public GameObject SpriteBorda;
    public float Range = 3.5f;
    [HideInInspector] public bool CanInteract; 

    private void Update()
    {
        float dist;
        dist = Vector2.Distance(transform.position, PlayerTrasnform.position);

        if (dist > -Range && dist < Range)
        {
            SpriteBorda.SetActive(true);
            CanInteract = true;
        } else
        {
            SpriteBorda.SetActive(false);
            CanInteract = false;
        }
        
    }

}
