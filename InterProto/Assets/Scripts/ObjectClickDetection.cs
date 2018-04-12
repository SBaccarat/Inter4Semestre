using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit, 100.0f))
        {
            if(hit.transform != null)
            {
                print("mizeravi");
            }
        }

	}
}
