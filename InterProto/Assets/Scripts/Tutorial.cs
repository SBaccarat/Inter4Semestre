using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    static public bool ShowTutorial;

    public GameObject TutorialPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ShowTutorial)
        {
            TutorialPanel.SetActive(true);
            ShowTutorial = false;
        }
	}

    public void CloseTutorial()
    {
        TutorialPanel.SetActive(false);
        StartCoroutine(InteractableBase.ReturToMove());
    }

}
