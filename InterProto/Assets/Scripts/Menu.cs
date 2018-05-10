using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            SceneToLoad = "CenaInterna";
        MyLoad.Loading(SceneToLoad);
        InteractableBase.ClickOnObject = false;
    }

    public void LoadGame()
    {
        if (Persistence.Scene == 2)
            SceneToLoad = "Prot";
        else if (Persistence.Scene == 1)
            SceneToLoad = "CenaInterna";
        MyLoad.Loading(SceneToLoad);
        InteractableBase.ClickOnObject = false;
    }
}
