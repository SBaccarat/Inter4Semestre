using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseSequence : MonoBehaviour
{

	public Image[] BolinhasPrefbs;

	private Image[] _bolinhasOrder;
	// Use this for initialization
	void Start ()
	{
		_bolinhasOrder = new Image[5];
		
		EscolheSequencia();
	}

	private void EscolheSequencia()
	{
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
