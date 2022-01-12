using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGGame : MonoBehaviour
{
    List<CONEntity> heroConList = new List<CONEntity>();

    void Awake()
    {
        GameSceneClass.gMGGame = this;

        GameObject.Instantiate(Global.prefabsDic[ePrefabs.MainCamera]);

        GameObject castle = GameObject.Instantiate(Global.prefabsDic[ePrefabs.Castle]);
        castle.transform.position = new Vector3(-15f, 0f, 0f);

        GameObject.Instantiate(Global.prefabsDic[ePrefabs.BG]);

        heroConList.Clear();
    }

    void OnEnable()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CONEntity heroCon = GameSceneClass.gMGPool.CreateObj(ePrefabs.HeroGirl, Random.insideUnitCircle);
            heroConList.Add(heroCon);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (heroConList.Count > 0)
            {
                heroConList[heroConList.Count - 1].SetActive(false);
                heroConList.RemoveAt(heroConList.Count - 1);
            }

        }



        // if (Global._gameStat == eGameStatus.Playing)
        // {
        //     if (Global._gameMode == eGameMode.Collect)
        //     {
        //         _gStageManager.UpdateCollect();
        //         _gMinionManager.UpdateCollect();
        //     }
        //     else if(Global._gameMode == eGameMode.Adventure)
        //     {
        //         _gStageManager.UpdateAdventure();
        //         _gMinionManager.UpdateAdventure();
        //         _gHeroManager.UpdateAdventure();
        //     }
        // }
    }

    void LateUpdate()
    {
        // GameSceneClass._gColManager.LateUpdate();
    }
}
