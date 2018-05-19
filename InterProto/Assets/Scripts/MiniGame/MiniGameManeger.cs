using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManeger : MonoBehaviour
{
    public Animator anim;
	public List<GameObject> Senha;
	public GameObject Tutorial;
	public static MiniGameManeger Instace;
	public GameObject Florclicada;
	public AudioSource _acertoAudio;
	private bool _once= false;
	
	void Start ()
	{

		
		Instace = this;
		Senha=new List<GameObject>();
		var list = FindObjectsOfType<ChoseColor>().ToList().OrderBy((a)=> a.name);
		foreach (var choseColor in list)
		{
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
		
		if (Senha.Count<1&&_once==false)
		{
			_once = true;

            //colocar aq para tocar a animação da baliarina dançando
            anim.SetBool("ativado", true);
            var animTime = 4; //mude o valor para o tempo q quiser q a bailarina fique dançando;
			Invoke("ExitLevel",animTime);
		}
		
	}

	void ExitLevel()
	{
        SceneManager.LoadScene("EndAlfaScene");
    }

	public void CheckColor(string colorClicked)
	{
		var array = Senha.ToArray();
		if (array[0].name.Equals(colorClicked))
		{
			_acertoAudio.Play();
			Florclicada.transform.DOLocalRotate(Vector3.back*3600, 1f)
				.OnComplete(() => Florclicada.transform.localPosition = Vector2.right * 100);
			array[0].transform.parent.gameObject.SetActive(false);
			Senha.RemoveAt(0);	
		}
	}
}
