using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour {

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void LoadFimDia1()
    {
        SceneManager.LoadScene("CeneEndDia1");
    }
}
