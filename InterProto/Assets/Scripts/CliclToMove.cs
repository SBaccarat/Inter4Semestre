using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliclToMove : MonoBehaviour {

    private Vector3 newPos; // salva a posiçao do click quando acontece
    private bool inComing; // salva o status do personagem se movendo
    public Rigidbody2D rgb; // fisicas do corpo do personagem
    public float Speed = 5; // velocidade de movimentaçao
    private int Direçao;   // direçao em que o personagem esta andando
    

    private void Start()
    {
        // determina a posiçao do player no inicio da cena 
        transform.position = Persistence.NewPos;
    }

    private void Update()
    {
        // aplica as forças vetorias no objeto
        rgb.velocity = new Vector2(Speed * Direçao, rgb.velocity.y);

        // checa o input para realizar a movimentaçao e salva a posiçao do click
        if (Input.GetMouseButton(0))
        { newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          inComing = true; }

        // realiza o movimento baseado na posiçao do click
        if (inComing) {
            if (transform.position.x < newPos.x)
            { Direçao = 1; }

            if (transform.position.x > newPos.x)
            {  Direçao = -1; }

            if(transform.position.x > newPos.x-.8f && transform.position.x < newPos.x+.8f)
            {  Direçao = 0;
               inComing = false; }

        }

    }
   
}
