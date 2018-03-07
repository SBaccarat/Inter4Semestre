using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movment : MonoBehaviour {

    public Rigidbody2D Rgb;
    public float velocidade;

 
    float Direçao;

    void Update()
    {
        print(Direçao);
        Direçao = CrossPlatformInputManager.GetAxis("Horizontal");

        Rgb.velocity = new Vector2(Direçao * velocidade, 0);
    }
}
