using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManeger : MonoBehaviour
{

	private List<GameObject> _senha;
	// Use this for initialization
	public static MiniGameManeger Instace;
	void Start ()
	{
		Instace = this;
		_senha=new List<GameObject>();
		foreach (var choseColor in FindObjectsOfType<ChoseColor>())
		{
			_senha.Add(choseColor.GetCores());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckColor(string colorClicked)
	{
		var array = _senha.ToArray();
		if (array[0].name.Equals(colorClicked))
		{
			array[0].transform.parent.gameObject.SetActive(false);	
			_senha.RemoveAt(0);
		}
		
	}
}
