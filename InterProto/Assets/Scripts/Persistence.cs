using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Persistence {

    // salva o status do item, pego ou n
    //greenBox
    public static int greenBoxStatus=0;
    //redBox
    public static int redBoxStatus=0;

    //valor da prox faze para o loading 
    public static string NextLevel;

    //salva o estado da cena atual
    public static int Scene = 1;

    //salva a posiçao em que o player vai aparecer
    public static Vector2 NewPos = new Vector2(0, -3);


    //comando para dar SaveGame
    public static void SaveData()
    {
        PlayerPrefs.SetInt("Scene", Scene);
        PlayerPrefs.SetInt("greenBoxStatus", greenBoxStatus);
        PlayerPrefs.SetInt("redBoxStatus", redBoxStatus);
        PlayerPrefsX.SetVector2("newPos", NewPos);
        PlayerPrefs.Save();
        Debug.Log("Caraio");
    }

    //comando para dar LoadGame
    public static void LoadData()
    {
        Scene = PlayerPrefs.GetInt("Scene");
        NewPos = PlayerPrefsX.GetVector2("newPos", NewPos);
        redBoxStatus = PlayerPrefs.GetInt("redBoxStatus");
        greenBoxStatus = PlayerPrefs.GetInt("greenBoxStatus");
    }

    public static void ReturnValues()
    {
        PlayerPrefs.DeleteAll();
        Scene = 1;
        NewPos = new Vector2(0, -3);
        greenBoxStatus = 0;
        redBoxStatus = 0;
    }

}
