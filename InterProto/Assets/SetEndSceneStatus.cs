using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEndSceneStatus : MonoBehaviour {

    public GameObject BgCasa;
    public GameObject BgParque;

    public GameObject FadePanel;

    static public bool CallOneTime =false;

    private void Update()
    {
        if (Persistence.Scene == 7)
        {
            BgCasa.SetActive(true);
            BgParque.SetActive(false);
        }
        else
        {
            BgCasa.SetActive(false);
            BgParque.SetActive(true);
        }

        if (CallOneTime)
        {
            FadePanel.SetActive(true);
            CallOneTime = false;
        }
    }

}
