using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{

    public Item itemScript;
    public DialogInteract dialogScript;

    public enum Buttons {Ver,Pegar,conversar,VerNpc}
    public Buttons WhatButton;

    private void OnMouseDown()
    {
        switch (WhatButton)
        {
            case Buttons.Ver:
                itemScript.BottonVer(); 
                break;
            case Buttons.Pegar:
                itemScript.ButtonPegar();
                break;
            case Buttons.VerNpc:
                dialogScript.BottonVer();
                break;
            case Buttons.conversar:
                dialogScript.ButtonConversar();
                break;
        }
    }
}
