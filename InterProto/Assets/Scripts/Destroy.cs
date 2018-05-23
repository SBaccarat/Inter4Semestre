using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {

    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }
    public void LoadFimDia1()
    {
        SceneManager.LoadScene("CeneEndDia1");
    }
    public void LoadFimDia2()
    {
        SceneManager.LoadScene("EndGameScene");
    }
}
