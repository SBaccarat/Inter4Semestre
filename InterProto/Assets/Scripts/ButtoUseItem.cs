using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtoUseItem : MonoBehaviour {

    public ObjectToInteract objectToInteractScript;

    public enum Buttons { Ver, UsarItem }
    public Buttons WhatButton;

    private void OnMouseDown()
    {
        switch (WhatButton)
        {
            case Buttons.Ver:
                objectToInteractScript.BottonVer();
                break;
            case Buttons.UsarItem:
                objectToInteractScript.ButtonUsar();
                break;
        }
    }
}
