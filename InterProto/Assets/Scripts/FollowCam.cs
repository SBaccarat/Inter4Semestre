using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	public GameObject target;
    

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Persistence.NewPos.x, Persistence.NewPos.y,-20);
    }
	
	// Update is called once per frame
	void Update () {


        if (!target)return;

        Vector3 newpos = new Vector3(
            target.transform.position.x ,
            target.transform.position.y + 2.65f,
			transform.position.z);

		transform.position = Vector3.Lerp(
			transform.position,newpos,Time.deltaTime*2);
	}
}
