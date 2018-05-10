using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManeger : MonoBehaviour
{

	private List<GameObject> _senha;
	// Use this for initialization
	public static MiniGameManeger Instace;
	private bool once= false;
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
	void Update ()
	{
		
		var array = _senha.ToArray();
		if (_senha.Count<1&&once==false)
		{
			Debug.Log("sai");
			once = true;
			//colocar aq para tocar a animação da baliarina dançando
			var animTime = 300; //mude o valor para o tempo q quiser q a bailarina fique dançando;
			Invoke("ExitLevel",animTime);
		}
		
	}

	void ExitLevel()
	{
		//coloca aq para carregar a cena
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
