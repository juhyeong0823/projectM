using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    public static UIInGame Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameObject.hideFlags = HideFlags.HideAndDontSave;
    }

    [Header("ü�¹�")]
    public Image hpBar;
    public Text hpText;

    [Header("���̺� ���൵")]
    public Image wavePrograssBar;
    public Text waveNumberText;

    public Button[] skillBtns; 

    public Image skillGage;
    public Text skillGageCount;

    public Button gameSpeedControllBtn;

}
