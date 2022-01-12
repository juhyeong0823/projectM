using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGWave : MonoBehaviour
{
    public List<CONMonster> monsterList = new List<CONMonster>();

    private void Awake()
    {
        GameSceneClass.gMGWave = this;
    }

    private void Start()
    {
        CONEntity monsterCon = GameSceneClass.gMGPool.CreateObj(ePrefabs.Monster, new Vector3(transform.position.x, Random.Range(-2f, 2f), 0f));
    }
}
