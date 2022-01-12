using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGGame : MonoBehaviour
{
    List<CONEntity> heroConList = new List<CONEntity>();

    private Camera mainCam;

    private int gameSpeed = 1;
    private int maxGameSpeed = 5;

    public float CurSkillGage { get; set; }
    public float MaxSkillGage = 10f;
    
    public Action OnChangedGameSpeed;
    public Action PlusCurSkillGage;

    void Awake()
    {
        GameSceneClass.gMGGame = this;

        mainCam = GameObject.Instantiate(Global.prefabsDic[ePrefabs.MainCamera]).GetComponent<Camera>();

        GameObject castle = GameObject.Instantiate(Global.prefabsDic[ePrefabs.Castle]);
        castle.transform.position = new Vector3(-15f, 0f, 0f);

        GameObject mgWave = GameObject.Instantiate(Global.prefabsDic[ePrefabs.MGWave]);
        Vector2 maxScreenPoint = mainCam.ViewportToWorldPoint(Vector2.one);

        mgWave.transform.position = new Vector3(maxScreenPoint.x + 2f, 0f);

        GameObject.Instantiate(Global.prefabsDic[ePrefabs.BG]);

        heroConList.Clear();
    }


    private void Start()
    {
        OnChangedGameSpeed = SetGameSpeed;
        PlusCurSkillGage = () => CurSkillGage++;
    }
    void OnEnable()
    {
        
    }

    private void SetGameSpeed()
    {
        if (gameSpeed > maxGameSpeed) gameSpeed = 1;
        Time.timeScale = gameSpeed;
    }

    private void SetSkillGage()
    {
        GameSceneClass.gUIIngame.SetSkillGage(CurSkillGage, MaxSkillGage);
    }


    void Update()
    {
        if(CurSkillGage < MaxSkillGage)
        {
            CurSkillGage += Time.deltaTime;
        }
        SetSkillGage();




        /*
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
        */


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
