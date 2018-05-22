﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAvailiability : MonoBehaviour {

    public GameObject PegarToalha;
    public GameObject ComversarMae;
    public GameObject BrincarBoneca;
    public GameObject PegarBoneca;
    public GameObject BrincarBonecaPega;
    public GameObject Door;
    public GameObject Fila;

	// Update is called once per frame
	void Update ()
    {

        if (QuestLog.MainQuestStaus > 2)
            Door.SetActive(true);
        else Door.SetActive(false);

        if (QuestLog.MainQuestStaus < 2)
           ComversarMae.SetActive(true);
        else ComversarMae.SetActive(false);

        if (QuestLog.MainQuestStaus == 2 )
            BrincarBoneca.SetActive(true);
        else BrincarBoneca.SetActive(false);

        if (QuestLog.MainQuestStaus == 3)
            PegarToalha.SetActive(true);
       

        if (QuestLog.MainQuestStaus == 4)
            PegarBoneca.SetActive(true);
        else PegarBoneca.SetActive(false);

        if (Persistence.Scene == 4 && QuestLog.MainQuestStaus == 4)
            BrincarBonecaPega.SetActive(true);
        else BrincarBonecaPega.SetActive(false);

        if (QuestLog.MainQuestStaus < 5)
            Fila.SetActive(true);
        else Fila.SetActive(false);

    }
}
