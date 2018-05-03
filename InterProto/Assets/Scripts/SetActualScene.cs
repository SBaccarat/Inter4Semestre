using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActualScene : MonoBehaviour {

    public int thisScene;

	// Use this for initialization
	void Start () {
        Persistence.Scene = thisScene;
	}
}
