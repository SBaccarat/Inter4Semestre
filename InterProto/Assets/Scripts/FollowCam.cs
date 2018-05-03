using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	public GameObject target;
    int poscan;

    

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {


        if (!target)return;

        Vector3 newpos = new Vector3(
            target.transform.position.x ,
            target.transform.position.y + 3.5f,
			transform.position.z);

		transform.position = Vector3.Lerp(
			transform.position,newpos,Time.deltaTime*2);
	}
}
