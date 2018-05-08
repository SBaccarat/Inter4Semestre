using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItemENpc : MonoBehaviour

    //Esse script serve pra setar as açoes dos botoes de interaçao com itens e Npcs
    //Tive que fazer esse script pq o UI dessas coisa é um GameObject

{
    public Item itemScript; //Variavel que armasena o script do item pra puxar as funçoes de la
    public DialogInteract dialogScript; //Variavel que salva o script que controla a interaçao com os Npcs

    public enum Buttons {Ver,Pegar,conversar,VerNpc} // Enum que salva as funçoes do botao
    public Buttons WhatButton; //variavel que puxa uma das funçoes 

    private void OnMouseDown() //é chamado quando um click/tap acontece no objeto(botao)
    {
        switch (WhatButton)
        {
            case Buttons.Ver: // se o botao tiver a funçao de ver 
                itemScript.BottonVer(); //chama a funçao de ver de dentro do item
                break;
            case Buttons.Pegar://se o botao tiver a funçao de pegar 
                itemScript.ButtonPegar();//chama a funçao de pegar dentro do script do item
                break;
            case Buttons.VerNpc://se o botao for ver, e se tratar de um npc 
                dialogScript.BottonVer();//chama de dentro do script do npc a funçao de ver 
                break;
            case Buttons.conversar:// se o botao for converçar
                dialogScript.ButtonConversar();//chama a funçao de conversar de dentro do npc
                break;
        }
    }
}
