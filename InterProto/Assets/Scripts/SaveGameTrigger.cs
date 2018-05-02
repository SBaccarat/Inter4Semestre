using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTrigger : MonoBehaviour {
	public void SaveGame()
    {
        Persistence.SaveData();
    }
}
