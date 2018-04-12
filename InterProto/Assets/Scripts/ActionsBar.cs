using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsBar : MonoBehaviour
{
	public GameObject Bar;

	private Vector2 _holdPosition,_actualPosition;

	private Vector2 _relisePosition;
	private bool _moved;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
#if UNITY_EDITOR
		

		_actualPosition = Input.mousePosition;
		if (Input.GetMouseButtonDown(0))
		{
			_holdPosition = Input.mousePosition;

		}

		if (Input.GetMouseButtonUp(0))
		{

			Bar.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward;
			Bar.GetComponent<CanvasGroup>().alpha = 1;
		}
		if (_holdPosition != _actualPosition)
		{
			Bar.GetComponent<CanvasGroup>().alpha = 0;
		}
#endif
#if UNITY_ANDROID
		
		if (Input.touchCount == 1)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				_moved = false;
			}
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Bar.GetComponent<CanvasGroup>().alpha = 0;
				_moved = true;
			}
			
		}
		if (Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			if (!_moved)
			{
				Bar.transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) + Vector3.forward;
				Bar.GetComponent<CanvasGroup>().alpha = 1;
			}
		}
#endif
	}
}
