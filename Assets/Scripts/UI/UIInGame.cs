using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [Header("ü�¹�")]
    public Image hpBar;
    public Text hpText;

    [Header("���̺� ���൵")]
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

        skillGageCountText.text = ((int)curGage).ToString();
    }
}
