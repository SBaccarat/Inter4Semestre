using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

public class HitAreas : MonoBehaviour
{
    [SerializeField] private float _time;


    private void Awake()
    {
        Invoke("ChangePosition", 2);
    }

    private void ChangePosition()
    {
        var rnd = new System.Random((gameObject.name + Time.time).GetHashCode());

        var randTime = (float) rnd.NextDouble() * 1.5f;
        var randSide = rnd.Next(0, 100);
        var randonyposi = (float) rnd.Next(-340, 125) / 100f;

        if (randSide > 50)
        {
            var randonXposi = (float) rnd.Next(-750, -350) / 100f;
            transform.position = new Vector2(randonXposi, randonyposi);
        }
        else
        {
            var randonXposi = (float) rnd.Next(350, 750) / 100f;
            transform.position = new Vector2(randonXposi, randonyposi);
        }

        transform.GetComponent<SpriteRenderer>().DOFade(1, 0);

        var anima = transform.GetComponent<SpriteRenderer>().DOFade(0, _time);
        anima.SetDelay(randTime);
        anima.OnComplete(ChangePosition);
    }

    void Update()
    {
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                hit.collider.transform.localPosition = Vector2.right * 100;
                Debug.Log(hit.collider.name);
                MiniGameManeger.Instace.CheckColor(hit.collider.name);
            }
        }
    }
}