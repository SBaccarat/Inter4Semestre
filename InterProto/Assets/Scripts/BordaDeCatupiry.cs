using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordaDeCatupiry : MonoBehaviour {

    public Transform PlayerTrasnform;
    public SpriteRenderer SpriteBorda;
    public float Range = 4.5f;
    [HideInInspector] public bool CanInteract; 

    private void Update()
    {
        float dist;
        dist = Vector2.Distance(transform.position, PlayerTrasnform.position);

        if (dist > -Range && dist < Range)
        {
            SpriteBorda.enabled = true;
            CanInteract = true;
        } else
        {
            SpriteBorda.enabled = false;
            CanInteract = false;
        }
        
    }

}
