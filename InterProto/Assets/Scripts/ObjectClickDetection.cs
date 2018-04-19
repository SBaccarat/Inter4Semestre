using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickDetection : MonoBehaviour {

    public enum Objects {Nothing,Door,Item}
    public static Objects ActualObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up, 0);
            if (hit)
            {
                Debug.Log(ActualObject);
            }
            if(hit.collider.gameObject.tag == "Item")
            {
                ActualObject = Objects.Item;
            }
            if (hit.collider.gameObject.tag == "Door")
            {
                ActualObject = Objects.Door;
            }
            if (!hit)
            {
                ActualObject = Objects.Nothing;
            }
        }
	}
}
