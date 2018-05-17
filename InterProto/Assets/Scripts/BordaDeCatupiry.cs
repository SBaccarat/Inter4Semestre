using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordaDeCatupiry : MonoBehaviour {

    public Transform PlayerTrasnform;
    public SpriteRenderer SpriteBorda;
  

    private void Update()
    {
        float dist;
        dist = Vector2.Distance(transform.position, PlayerTrasnform.position);
        if (dist > -3 && dist < 3)
        {
            SpriteBorda.enabled = true;
        } else
        {
            SpriteBorda.enabled = false;
        }
        
    }

}
