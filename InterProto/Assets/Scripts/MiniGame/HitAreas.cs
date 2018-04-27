using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

public class HitAreas : MonoBehaviour
{
	[SerializeField] private Vector2 _posiLeft, _posiRight;
	[SerializeField] private Vector3 _limitScale;
	[SerializeField] private float _time;


	// Use this for initialization
	private void Awake()
	{
		Invoke("ChangePosition",2);
	}

	private void ChangePosition()
	{
		var randTime = Random.Range(0, 1.5f);
		var randonXposi = Random.Range(-7.5f, 7.5f);
		var randonyposi = Random.Range(-2.3f, 3.5f);
		
		transform.position = new Vector2(randonXposi, randonyposi);
		
		transform.GetComponent<SpriteRenderer>().DOFade(1, 0);
		
		var anima =transform.GetComponent<SpriteRenderer>().DOFade(0, 3);
		anima.SetDelay(randTime);
		anima.OnComplete (ChangePosition);
	}

	// Update is called once per frame
	void Update()
	{
	}
}
