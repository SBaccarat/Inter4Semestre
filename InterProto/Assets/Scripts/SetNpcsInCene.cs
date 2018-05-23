using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNpcsInCene : MonoBehaviour {

    public GameObject MaeNpc;
    public GameObject IrmaNpc;

    public GameObject NpcsTerraço;

    private void Update()
    {
        if(Persistence.SceneQuartoStatus <= 2)
        {
            MaeNpc.SetActive(true);
            IrmaNpc.SetActive(false);
        }else if(Persistence.SceneQuartoStatus == 3)
        {
            MaeNpc.SetActive(false);
            IrmaNpc.SetActive(true);
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
