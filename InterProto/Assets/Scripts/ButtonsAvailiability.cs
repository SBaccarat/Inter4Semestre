using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAvailiability : MonoBehaviour {

    public GameObject PegarToalha;
    public GameObject ComversarMae;
    public GameObject BrincarBoneca;
    public GameObject PegarBoneca;
    public GameObject BrincarBonecaPega;
    public GameObject Door;
    public GameObject DoorBanheiro;

	// Update is called once per frame
	void Update ()
    {

        if (!QuestLog.Quest01 && !QuestLog.Quest02)
            Door.SetActive(true);
        else Door.SetActive(false);

        if (QuestLog.Quest01 || QuestLog.Quest02)
           ComversarMae.SetActive(true);
        else ComversarMae.SetActive(false);

        if (QuestLog.Quest02 )
            BrincarBoneca.SetActive(true);
        else BrincarBoneca.SetActive(false);

        if (QuestLog.Quest03)
            PegarToalha.SetActive(true);
       

        if (QuestLog.Quest04)
            PegarBoneca.SetActive(true);
        else PegarBoneca.SetActive(false);

        if (Persistence.Scene == 4 && QuestLog.Quest04)
            BrincarBonecaPega.SetActive(true);
        else BrincarBonecaPega.SetActive(false);

        if(QuestLog.Quest05)
            DoorBanheiro.SetActive(true);
        else DoorBanheiro.SetActive(false);

    }
}
