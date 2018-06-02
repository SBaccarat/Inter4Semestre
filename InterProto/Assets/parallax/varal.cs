﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varal : MonoBehaviour {

    public float speed = 0;
    private Material mat;
    private GameObject pl;
    private float pos = 0;

	// Use this for initialization
	void Start () {

        mat = GetComponent<Renderer>().material;
        pl = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        var vel = pl.GetComponent<Rigidbody2D>().velocity.x;

        if (vel > 0f) {
            var side = pl.transform.localScale.x;
            pos += speed * side;

            mat.mainTextureOffset = new Vector2(pos, 0);

        }

        if (vel < 0f)
        {
            var side = pl.transform.localScale.x;
            pos -= speed * side;

            mat.mainTextureOffset = new Vector2(pos, 0);

        }
    }
}
