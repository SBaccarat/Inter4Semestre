using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class MiniGameManeger : MonoBehaviour
{
	public GameObject FlorPretaPrefab;
	private GameObject[] _florPreta;
	private int _contagem;
    public Animator Anim;
	public GameObject StteOk, StteRuim;
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

		if (_contagem<=2)
		{
			if (_contagem>=2)
			{
				Tutorial.SetActive(false);
				StteOk.SetActive(false);
				StteRuim.SetActive(true);
			}
			if (_contagem < 4)
			{
				_florPreta = new GameObject[_contagem + 2];
				for (int i = 0; i < _florPreta.Length; i++)
					_florPreta[i] = (GameObject) Instantiate(FlorPretaPrefab);
			}
			Invoke("SomeTutorial",10);
		}
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
			PlayerPrefs.SetInt("MinigameCount",_contagem+2);
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
        if (Persistence.Scene == 1 && QuestLog.MainQuestStaus == 2)
        {
            MyLoad.Loading("CenaInterna");
            Persistence.SceneQuartoStatus = 2;
            DialogSystem.FirstDialog = true;
            QuestLog.MainQuestStaus = 3;
        }else
        if (Persistence.Scene == 4 && QuestLog.MainQuestStaus == 4)
        {
            DialogSystem.FirstDialog = true;
            MyLoad.Loading("exterior_cortico");
            QuestLog.MainQuestStaus = 5;
        }else
        if(Persistence.Scene == 9)
        {
            MyLoad.Loading("EndAlfaScene");
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
