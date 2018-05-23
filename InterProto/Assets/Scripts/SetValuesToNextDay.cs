using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValuesToNextDay : MonoBehaviour {
	void Start () {
        
        DialogSystem.FirstDialog = true;
        Persistence.SceneQuartoStatus = 3;
        Persistence.toalhaStatus = 2;
        MiniGameInteract.Piked = true;
	}
}
