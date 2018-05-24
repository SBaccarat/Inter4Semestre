using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNpcsInCene : MonoBehaviour {

    public GameObject MaeNpc;
    public GameObject IrmaNpc;

    public GameObject NpcsTerraço;

    public GameObject Cigarro;

    private void Update()
    {
        if(Persistence.SceneQuartoStatus <= 2)
        {
            MaeNpc.SetActive(true);
            IrmaNpc.SetActive(false);
            Cigarro.SetActive(true);
        }
        else if(Persistence.SceneQuartoStatus == 3)
        {
            MaeNpc.SetActive(false);
            IrmaNpc.SetActive(true);
            Cigarro.SetActive(false);
        }

        if (QuestLog.MainQuestStaus >= 9)
        {
            NpcsTerraço.SetActive(true);
        } else
        {
            NpcsTerraço.SetActive(false);
        }
    }
}
