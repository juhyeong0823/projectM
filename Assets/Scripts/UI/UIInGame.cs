using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [Header("체력바")]
    public Image hpBar;
    public Text hpText;

    [Header("웨이브 진행도")]
    public Image wavePrograssBar;
    public Text waveNumberText;


    public Transform skillParent;

    public Image skillGage;
    public Text skillGageCountText;

    public Button gameSpeedControllBtn;
    public Text gameSpeedText;

    public CanvasGroup cg;

    private void Awake()
    {
        GameSceneClass.gUIIngame = this;
    }

    private void Start()
    {
        GameSceneClass.gMGCastle.onChangeHP += SetHpBar;

        gameSpeedControllBtn.onClick.AddListener(() => GameSceneClass.gMGGame.OnChangedGameSpeed());
    }

    public void SetHpBar(float maxHp, float curHp)
    {
        float value = curHp / maxHp;
        hpBar.fillAmount = value;

        hpText.text = ((int)curHp).ToString();
    }

    public void SetGameOver(bool set)
    {
        cg.alpha = set ? 1 : 0;
        cg.blocksRaycasts = set;
        cg.interactable = set;
    }

    public void SetWaveInfo(int curWaveIndex, float curPrograss, float maxPrograss)
    {
        waveNumberText.text = $"WAVE {curWaveIndex}"; 

        float value = curPrograss / maxPrograss;
        wavePrograssBar.fillAmount = value;
    }

    public void SetSkillGage(float curGage, float maxGage)
    {
        float value = curGage / maxGage;
        skillGage.fillAmount = value;

        if(value <= 10)
        {
            skillGageCountText.text = ((int)curGage).ToString();
        }
    }
}
