using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberculoseScript : MonoBehaviour
{

	private float _timeToCofh;
	private float _countTime;
	public int TimeMini=10, TimeMaxi=15;

	public Animator Anima;
	// Use this for initialization
	void Start () {
		_timeToCofh = Random.Range(TimeMini, TimeMaxi);
	}
	
	// Update is called once per frame
	void Update ()
	{
		_countTime += Time.deltaTime;
		if (_timeToCofh < _countTime)
		{
			_countTime = 0;
			Anima.SetBool("Tosse", true);
			NewCothTime();
		}
	}

	private void NewCothTime()
	{
		_timeToCofh = Random.Range(TimeMini, TimeMaxi);
	}
}
