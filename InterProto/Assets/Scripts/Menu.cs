using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    string SceneToLoad;
    public GameObject Fade;

    private void Start()
    {
        Persistence.LoadData();
    }

    public void NewGame()
    {
        Persistence.ReturnValues();
        SceneToLoad = "IntroFamilha";
        Invoke("LoadNewCene", 0.7f);
        Instantiate(Fade);
        InteractableBase.ClickOnObject = false;
    }

    public void LoadGame()
    {
        if (!Persistence.HaveASave)
            SceneToLoad = "CenaInterna";
        else
        {
            if (Persistence.Scene == 1)
                SceneToLoad = "CenaInterna";
            else if (Persistence.Scene == 2)
                SceneToLoad = "Prot";
            else if (Persistence.Scene == 3)
                SceneToLoad = "Terreo";
            else if (Persistence.Scene == 4)
                SceneToLoad = "exterior_cortico";
            else if (Persistence.Scene == 5)
                SceneToLoad = "Banheiro";
            else if (Persistence.Scene == 6)
                SceneToLoad = "Laje";
            Persistence.LoadData();
        }
        Invoke("LoadNewCene", 0.7f);
        Instantiate(Fade);
    }

    void LoadNewCene()
    {
        Destroy(Fade);
        MyLoad.Loading(SceneToLoad);
    }

    public void sair() {

        Application.Quit();
        
    }
}
