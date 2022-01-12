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

    public Button[] skillBtns; 

    public Image skillGage;
    public Text skillGageCountText;

    public Button gameSpeedControllBtn;

    private void Awake()
    {
        GameSceneClass.gUIIngame = this;
    }

    public void SetHpBar(float maxHp, float curHp)
    {
        float value = curHp / maxHp;
        hpBar.fillAmount = value;
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

        skillGageCountText.text = Mathf.Floor(value).ToString();
    }

    public void SetGameSpeed(int maxGameSpeed, int gameSpeed)
    {
        Time.timeScale = gameSpeed;
    }
}
