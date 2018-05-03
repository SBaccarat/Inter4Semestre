using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseColor : MonoBehaviour
{
	private GameObject _senha;
	private GameObject[] _cores;
	private void Awake()
	{
		ActiveColor();
	}

	private GameObject[] GetChildren(GameObject parent)
	{
		List<GameObject> items = new List<GameObject>();
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			items.Add(parent.transform.GetChild(i).gameObject);

		}
		return items.ToArray();
	}

	private void ActiveColor()
	{
		_cores = GetChildren(this.gameObject);
		var index= Random.Range(0, _cores.Length); 
		_cores[index].gameObject.SetActive(true);
		_senha = _cores[index];
	}

	public GameObject GetCores()
	{
		return _senha;
	}
/*
	private void CheckHit(string colorClicked)
	{
		
		switch (colorClicked)
		{
				case "bola amarela":
					if (_cores[0].activeSelf)
						_cores[0].transform.parent.gameObject.SetActive(false);
					else
					return;
					break;
				case "bola azul":
					if (_cores[1].activeSelf)
						_cores[1].transform.parent.gameObject.SetActive(false);
					else
						return;
					break;
				case "bola branca":
					if (_cores[2].activeSelf)
						_cores[2].transform.parent.gameObject.SetActive(false);
					else
						return;
					break;
				case "bola vermelha":
					if (_cores[3].activeSelf)
						_cores[3].transform.parent.gameObject.SetActive(false);
					else
						return;
					break;
				case "bola verde":
					if (_cores[4].activeSelf)
						_cores[4].transform.parent.gameObject.SetActive(false);
					else
						return;
					break;
					
		}
	}
	*/
}
