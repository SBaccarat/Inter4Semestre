using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{

    public Item itemScript;

    public enum Buttons {Ver,Pegar}
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
        }
    }
}
