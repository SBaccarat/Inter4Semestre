using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour {

    public void CenaBanheiro()
    {
        MyLoad.Loading("exterior_cortico");
        Persistence.NewPos = new Vector2(-63f,-3.2f);
        Persistence.SceneQuartoStatus = 1;
        QuestLog.MainQuestStaus = 4;
        DialogSystem.FirstDialog = false;
        InteractableBase.ClickOnObject = false;
        MiniGameInteract.Piked = true; 
        Persistence.cigarroStatus = 0;
        Persistence.paoStatus = 2;
        Persistence.toalhaStatus = 1;
    }

    public void CenaCota()
    {
        MyLoad.Loading("Laje");
        Persistence.NewPos = new Vector2(-92f, -3.2f);
        Persistence.SceneQuartoStatus = 2;
        QuestLog.MainQuestStaus = 7;
        DialogSystem.FirstDialog = false;
        InteractableBase.ClickOnObject = false;
        MiniGameInteract.Piked = true;
        Persistence.cigarroStatus = 0;
        Persistence.paoStatus = 2;
        Persistence.toalhaStatus = 2;
    }

    public void CenaCigarro()
    {
        MyLoad.Loading("Terreo");
        Persistence.NewPos = new Vector2(-61f, -4f);
        Persistence.SceneQuartoStatus = 2;
        QuestLog.MainQuestStaus = 9;
        DialogSystem.FirstDialog = false;
        InteractableBase.ClickOnObject = false;
        MiniGameInteract.Piked = true;
        Persistence.cigarroStatus = 0;
        Persistence.paoStatus = 2;
        Persistence.toalhaStatus = 2;
    }

    public void CenaFinal()
    {
        MyLoad.Loading("EndGameScene");
        DialogSystem.FirstDialog = true;
    }


}
