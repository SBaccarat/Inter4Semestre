using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManeger : MonoBehaviour
{
    public Animator anim;
	public List<GameObject> Senha;
	public GameObject Tutorial;
	public static MiniGameManeger Instace;
	private bool once= false;
	
	void Start ()
	{

		
		Instace = this;
		Senha=new List<GameObject>();
		var list = FindObjectsOfType<ChoseColor>().ToList().OrderBy((a)=> a.name);
		foreach (var choseColor in list)
		{
			Debug.Log(choseColor.name);
			Senha.Add(choseColor.GetCores());
		}
		Invoke("SomeTutorial",4);
	}

	private void SomeTutorial()
	{
		Tutorial.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (Senha.Count<1&&once==false)
		{
			Debug.Log("sai");
			once = true;

            //colocar aq para tocar a animação da baliarina dançando
            anim.SetBool("ativado", true);
            var animTime = 4; //mude o valor para o tempo q quiser q a bailarina fique dançando;
			Invoke("ExitLevel",animTime);
		}
		
	}

	void ExitLevel()
	{
        if (Persistence.Scene == 1 && QuestLog.Quest02)
        {
            MyLoad.Loading("CenaInterna");
            Persistence.SceneQuartoStatus = 2;
            DialogSystem.FirstDialog = true;
            QuestLog.Quest02 = false;
            QuestLog.Quest03 = true;
        }

        if (Persistence.Scene == 4 && QuestLog.Quest04)
        {
            DialogSystem.FirstDialog = true;
            MyLoad.Loading("exterior_cortico");
            QuestLog.Quest04 = false;
            QuestLog.Quest05 = true;
        }
        
   
    }

	public void CheckColor(string colorClicked)
	{
		var array = Senha.ToArray();
		if (array[0].name.Equals(colorClicked))
		{
			array[0].transform.parent.gameObject.SetActive(false);
			Senha.RemoveAt(0);	
		}	
	}
}
