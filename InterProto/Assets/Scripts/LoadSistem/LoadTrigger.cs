using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour {

    public GameObject Fade;

    public void LoadScene(string Scene)
    {
        Instantiate(Fade);
        StartCoroutine(Load(Scene));
    }
   IEnumerator Load(string Level)
    {
        Destroy(Fade);
        yield return new WaitForSeconds(0.7f);
        MyLoad.Loading(Level);
    }
}

