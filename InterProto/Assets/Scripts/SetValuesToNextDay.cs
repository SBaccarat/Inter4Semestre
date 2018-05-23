using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValuesToNextDay : MonoBehaviour {
	void Start () {
        Persistence.NewPos = new Vector2(-189, -3.2f);
        DialogSystem.FirstDialog = true;
        Persistence.SceneQuartoStatus = 3;
        Persistence.toalhaStatus = 2;
        MiniGameInteract.Piked = true;
	}
}
