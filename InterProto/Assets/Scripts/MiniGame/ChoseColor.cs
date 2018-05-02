using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseColor : MonoBehaviour
{
	private static GameObject[] _cores;
	private void Awake()
	{
		ActiveColor();
	}

	public static GameObject[] GetChildren(GameObject parent)
	{
		List<GameObject> items = new List<GameObject>();
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			items.Add(parent.transform.GetChild(i).gameObject);

		}
		return items.ToArray();
	}

	public void ActiveColor()
	{
		var cores = GetChildren(this.gameObject);
		var index= Random.Range(0, cores.Length); 
		cores[index].gameObject.SetActive(true);
		_cores = cores;
	}

	protected static void CheckHit(string colorClicked)
	{
		switch (colorClicked)
		{
				case "bola amarela":
					if (_cores[0].activeSelf)
						_cores[0].gameObject.SetActive(false);
					else
					return;
					break;
				case "bola azul":
					if (_cores[1].activeSelf)
						_cores[1].gameObject.SetActive(false);
					else
						return;
					break;
				case "bola branca":
					if (_cores[2].activeSelf)
						_cores[2].gameObject.SetActive(false);
					else
						return;
					break;
				case "bola vermelha":
					if (_cores[3].activeSelf)
						_cores[3].gameObject.SetActive(false);
					else
						return;
					break;
				case "bola verde":
					if (_cores[4].activeSelf)
						_cores[4].gameObject.SetActive(false);
					else
						return;
					break;
					
		}
	}
}
