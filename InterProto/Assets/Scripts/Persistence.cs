using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Persistence {

    public static int SceneQuartoStatus = 1;

    // salva o status do item, pego ou n
    //greenBox
    public static int greenBoxStatus=0;
    //redBox
    public static int redBoxStatus=0;
    //cigarro
    public static int cigarroStatus = 0;
    //Toalha
    public static int toalhaStatus = 0;
    //Pao
    public static int paoStatus = 0;

    //valor da prox faze para o loading 
    public static string NextLevel;

    //salva o estado da cena atual
    public static int Scene = 1;

    //salva a posiçao em que o player vai aparecer
    public static Vector2 NewPos = new Vector2(-189, -3.2f);

    static public bool HaveASave;

    public static int MinigameCount=0;


    //comando para dar SaveGame
    public static void SaveData()
    {
        HaveASave = true;
        PlayerPrefsX.SetBool("HaveASave", HaveASave);
        PlayerPrefs.SetInt("Scene", Scene);
        PlayerPrefs.SetInt("greenBoxStatus", greenBoxStatus);
        PlayerPrefs.SetInt("redBoxStatus", redBoxStatus);
        PlayerPrefs.SetInt("cigarroStatus", cigarroStatus);
        PlayerPrefs.SetInt("toalhaStatus", toalhaStatus);
        PlayerPrefs.SetInt("paoStatus", paoStatus);
        PlayerPrefsX.SetVector2("newPos", NewPos);
        PlayerPrefsX.SetBool("FirstDialog", DialogSystem.FirstDialog);
        PlayerPrefsX.SetBool("canPlay", MiniGameInteract.CanPlay);
        PlayerPrefs.SetInt("MainQuestStaus", QuestLog.MainQuestStaus);
        PlayerPrefs.SetInt("SceneQuartoStatus", SceneQuartoStatus);
        PlayerPrefsX.SetBool("Piked", MiniGameInteract.Piked);
        PlayerPrefs.SetInt("MinigameCount", MinigameCount);
        PlayerPrefs.Save();
        Debug.Log("Caraio");
    }

    //comando para dar LoadGame
    public static void LoadData()
    {
        HaveASave = PlayerPrefsX.GetBool("HaveASave");
        Scene = PlayerPrefs.GetInt("Scene");
        NewPos = PlayerPrefsX.GetVector2("newPos", NewPos);
        redBoxStatus = PlayerPrefs.GetInt("redBoxStatus");
        greenBoxStatus = PlayerPrefs.GetInt("greenBoxStatus");
        cigarroStatus = PlayerPrefs.GetInt("cigarroStatus");
        toalhaStatus = PlayerPrefs.GetInt("toalhaStatus");
        paoStatus = PlayerPrefs.GetInt("paoStatus");
        MiniGameInteract.CanPlay = PlayerPrefsX.GetBool("canPlay");
        DialogSystem.FirstDialog = PlayerPrefsX.GetBool("FirstDialog");
        QuestLog.MainQuestStaus = PlayerPrefs.GetInt("MainQuestStaus");
        MiniGameInteract.Piked = PlayerPrefsX.GetBool("Piked");
        SceneQuartoStatus = PlayerPrefs.GetInt("SceneQuartoStatus");
        MinigameCount = PlayerPrefs.GetInt("MinigameCount");
    }

    public static void ReturnValues()
    {
        PlayerPrefs.DeleteAll();
        Scene = 1;
        NewPos = new Vector2(-189, -3.2f);
        greenBoxStatus = 0;
        redBoxStatus = 0;
        cigarroStatus = 0;
        toalhaStatus = 0;
        paoStatus = 0;
        DialogSystem.FirstDialog = true;
        MiniGameInteract.CanPlay = false;
        QuestLog.MainQuestStaus = 1;
        MiniGameInteract.Piked = false;
        HaveASave = false;
        SceneQuartoStatus = 1;
        MinigameCount = 0;
    }

}
