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

	private bool _left;
	// Use this for initialization
	private void Awake()
	{
		transform.DOScale(4f, 5 - _time);
	}

	private void ChangePosition()
	{
		var randonXposi = Random.Range(-2, 2);
		var randonyposi = Random.Range(-2.3f, 2.3f);
		if(!_left)
		transform.position = _posiLeft + new Vector2(randonXposi,randonyposi);
		else
		transform.position = _posiRight + new Vector2(randonXposi,randonyposi);		
		transform.DOScale(15,0);
		transform.DOScale(4f, 5 - _time);
	}

	// Update is called once per frame
	void Update () {
		if(transform.localScale==_limitScale)
		{
			ChangePosition();
			_time += 0.2f;
			_left=!_left;
		}
	}
}
