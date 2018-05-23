using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManeger : MonoBehaviour
{
	public GameObject FlorPretaPrefab;
	private GameObject[] _florPreta;
	private int _contagem;
    public Animator Anim;
	public List<GameObject> Senha;
	public GameObject Tutorial;
	public static MiniGameManeger Instace;
	public GameObject Florclicada;
	public AudioSource AcertoAudio;
	private bool _once= false;
	
	void Start ()
	{
		_contagem = PlayerPrefs.GetInt("MinigameCount");
		
		Instace = this;
		Senha=new List<GameObject>();
		var list = FindObjectsOfType<ChoseColor>().ToList().OrderBy((a)=> a.name);
		foreach (var choseColor in list)
		{
			Senha.Add(choseColor.GetCores());
		}

		if (_contagem!=0)
		{
			Tutorial.SetActive(false);
			_florPreta = new GameObject[_contagem];
			for (int i = 0; i < _florPreta.Length; i++)
				_florPreta[i] = (GameObject) Instantiate(FlorPretaPrefab);
			return;
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
			var flores = FindObjectsOfType<HitAreas>();
			PlayerPrefs.SetFloat("MinigameCount",_contagem+1);
			foreach (var colliders in flores)
			{
				colliders.gameObject.SetActive(false);
			}
            //colocar aq para tocar a animação da baliarina dançando
            Anim.SetBool("fim", true);
            var animTime = 4; //mude o valor para o tempo q quiser q a bailarina fique dançando;
			Invoke("ExitLevel",animTime);
		}
		
	}

	public void ExitLevel()
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
			Anim.SetBool("click",true);
			Florclicada.GetComponent<Collider2D>().enabled = false;
			AcertoAudio.Play();
			Florclicada.transform.DOLocalRotate(Vector3.back*1080, 1f)
				.OnComplete(() => Florclicada.transform.localPosition = Vector2.right * 100)
				.OnComplete(()=>Florclicada.GetComponent<Collider2D>().enabled = true)
				.OnComplete(()=>Anim.SetBool("click",false));
			array[0].transform.parent.gameObject.SetActive(false);
			Senha.RemoveAt(0);	
		}
	}
}
