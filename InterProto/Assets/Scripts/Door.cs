﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public string NextCene; //Nome da cena onde a porta vai levar 
    public Vector2 setPos; //posiçao em que o personagem vai aparecer na prox cena
    public bool IsStair=false;
    public Transform PlayerTrasnform;
    public SpriteRenderer IconDoor;
    public GameObject FadeExit;

    private void OnMouseDown()
    {
        if (IconDoor.enabled)
        {
            InteractableBase.ClickOnObject = false;
            CliclToMove.Direçao = 0;
            DoorTransition();
        }
    }

    private void Update()
    {

        float dist;
        dist = Vector2.Distance(transform.position, PlayerTrasnform.position);
        if (dist > -4f && dist < 4f)
        {
            IconDoor.enabled = true;
        }
        else
        {
            IconDoor.enabled = false;
        }

    }
    public void DoorTransition()
    {
        Invoke("LoadNewScene",0.7f);
        Instantiate(FadeExit);
    }
    void LoadNewScene()
    {
        FadeExit.SetActive(false);
        SceneManager.LoadScene(NextCene);
        Persistence.NewPos = setPos;
    }
}
