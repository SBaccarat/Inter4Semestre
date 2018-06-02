using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseScript : MonoBehaviour {

    public GameObject PanelPause;

    public void ActiveMenuPause()
    {
        PanelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void DesactiveMenuPause()
    {
        PanelPause.SetActive(false);
        Time.timeScale = 1;
    }

	public void SaveGame()
    {
        Persistence.SaveData();
    }
}
