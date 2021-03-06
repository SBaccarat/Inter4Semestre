﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliclToMove : MonoBehaviour {

    private Vector3 newPos; // salva a posiçao do click quando acontece
    private bool inComing; // salva o status do personagem se movendo
    public Rigidbody2D rgb; // fisicas do corpo do personagem
    public float Speed = 5; // velocidade de movimentaçao
    public static int Direçao;   // direçao em que o personagem esta andando
    public Animator Anim;
    public SpriteRenderer Sprite;
    private bool _movedFinguer;
    public AudioSource tosse;
    public AudioSource walk;

    private void Start()
    {
        // determina a posiçao do player no inicio da cena 
        transform.position = Persistence.NewPos;
        Direçao = 0;
    }

    private void Update()
    {

        
        // aplica as forças vetorias no objeto
        rgb.velocity = new Vector2(Speed * Direçao, rgb.velocity.y);

        Anim.SetInteger("Speed", Direçao);
        if (Direçao >= 0) { Sprite.flipX = false; }
        if (Direçao < 0) { Sprite.flipX = true; }


        // checa o input para realizar a movimentaçao e salva a posiçao do click
        if (Input.GetMouseButton(0)&&!InteractableBase.ClickOnObject)
        {
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            inComing = true;
            
        }
        if (Input.GetMouseButtonUp(0)&&!InteractableBase.ClickOnObject)
        {
            inComing = false;
            Direçao = 0;
        }

        // realiza o movimento baseado na posiçao do click

        if (inComing)
        {
            if (transform.position.x < newPos.x)
            { Direçao = 1; }

            if (transform.position.x > newPos.x)
            { Direçao =-1;  }

            if (transform.position.x > newPos.x - .8f && transform.position.x < newPos.x + .8f)
            {
                Direçao = 0;
            }
        }

    }

    public void tosseSom() {
           tosse.Play();            
    }

    public void walkSom()
    {
        walk.Play();

    }

}
