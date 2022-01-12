using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGWave : MonoBehaviour
{
    public List<CONMonster> monsterList = new List<CONMonster>();

    public int waveIdx = 1;

    private float waveWaitTime = 2f;
    private WaitForSeconds createWait = new WaitForSeconds(0.3f);

    private void Awake()
    {
        GameSceneClass.gMGWave = this;
    }

    private void Start()
    {
        StartCoroutine(WaveStart());
    }

    private void CreateMonster()
    {
        CONEntity monsterCon = GameSceneClass.gMGPool.CreateObj(ePrefabs.Monster, new Vector3(transform.position.x, Random.Range(-2f, 2f), 0f));
        GameSceneClass.gMGWave.monsterList.Add(monsterCon as CONMonster);
    }

    private IEnumerator WaveStart()
    {
        while (true)
        {
            float waveWait = 0f;

            while (waveWait < waveWaitTime)
            {
                yield return null;

                waveWait += Time.deltaTime;

                GameSceneClass.gUIIngame.SetWaveInfo(waveIdx, waveWait, waveWaitTime);
            }

            float totalTime = waveIdx * 0.3f;
            waveWait = totalTime;

            StartCoroutine(CreateWaveMonster());

            while (waveWait > 0f)
            {
                yield return null;

                waveWait -= Time.deltaTime;

                GameSceneClass.gUIIngame.SetWaveInfo(waveIdx, waveWait, totalTime);
            }

            yield return new WaitUntil(() => monsterList.Count == 0);

            waveIdx++;
        }
    }

    private IEnumerator CreateWaveMonster()
    {
        for (int i = 0; i < waveIdx; i++)
        {
            CreateMonster();
            yield return createWait;
        }
    }
}
