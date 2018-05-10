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

	public void ActiveColor()
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

}
