using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilClass
{
    public static CONMonster GetNearbyEnemy(Transform startTrm, List<CONMonster> monsters)
    {
        float minX = Mathf.Infinity;
        int idx = 0;

        for (int i = 0; i < monsters.Count; i++)
        {
            float dist = Vector3.Distance(startTrm.position, monsters[i].transform.position);

            if (minX > dist)
            {
                minX = dist;
                idx = i;
            }
        }

        return monsters[idx];
    }
}
