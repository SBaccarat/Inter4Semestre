using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseColor : MonoBehaviour
{
	private GameObject[] _cores;
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
		var index= (int) Random.Range(0, 4);
		cores[index].gameObject.SetActive(true);
	}
}
