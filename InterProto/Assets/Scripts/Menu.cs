using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    string SceneToLoad;

    private void Start()
    {
        Persistence.LoadData();
    }

    public void NewGame()
    {
        Persistence.ReturnValues();
        if (Persistence.Scene == 1)
            SceneToLoad = "Prot";
        else if (Persistence.Scene == 2)
            SceneToLoad = "CenaInterna";
        SceneManager.LoadScene(SceneToLoad);
    }

    public void LoadGame()
    {
        if (Persistence.Scene == 1)
            SceneToLoad = "Prot";
        else if (Persistence.Scene == 2)
            SceneToLoad = "CenaInterna";
        SceneManager.LoadScene(SceneToLoad);
    }
}
