using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUseItem : MonoBehaviour {

    public ObjectToInteract ObjectScript; //Variavel que salva o script que controla a interaçao com os Npcs

    public enum Buttons { Ver, Usar} // Enum que salva as funçoes do botao
    public Buttons WhatButton; //variavel que puxa uma das funçoes 

    private void OnMouseDown() //é chamado quando um click/tap acontece no objeto(botao)
    {
        switch (WhatButton)
        {
            case Buttons.Ver: // se o botao tiver a funçao de ver 
                ObjectScript.ButtonVer(); //chama a funçao de ver de dentro do item
                break;
            case Buttons.Usar://se o botao tiver a funçao de pegar 
                ObjectScript.ButtonUsar();//chama a funçao de pegar dentro do script do item
                break;
        }
    }
}
