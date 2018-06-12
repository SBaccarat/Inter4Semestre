using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectLoadTrigger : MonoBehaviour {

    public void DirectLoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
