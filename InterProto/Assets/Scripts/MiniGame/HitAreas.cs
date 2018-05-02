using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

public class HitAreas : MonoBehaviour
{
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
		
		var anima =transform.GetComponent<SpriteRenderer>().DOFade(0, _time);
		anima.SetDelay(randTime);
		anima.OnComplete (ChangePosition);
	}

	// Update is called once per frame
	void Update()
	{
		//If the left mouse button is clicked.
		if (Input.GetMouseButtonDown(0))
		{
			//Get the mouse position on the screen and send a raycast into the game world from that position.
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

			//If something was hit, the RaycastHit2D.collider will not be null.
			if (hit.collider != null)
			{
				hit.collider.transform.localPosition = Vector2.right*100;
				Debug.Log(hit.collider.name);
			}
		}
	}
}
