using Assets.Script.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNormalMonsterController : MonoBehaviour
{
    public GameObject m1Prefab;
    public GameObject m2Prefab;
    public GameObject m3Prefab;
    public GameObject m4Prefab;
    public GameObject m5Prefab;
    public GameObject m6Prefab;

    private float m1Timer = 0f;
    private float m2Timer = 0f;
    private float m3Timer = 0f;
    private float m4Timer = 0f;
    private float m5Timer = 0f;
    private float m6Timer = 0f;

    private void Update()
    {
        m1Timer += Time.deltaTime;
        m2Timer += Time.deltaTime;
        m3Timer += Time.deltaTime;
        m4Timer += Time.deltaTime;
        m5Timer += Time.deltaTime;
        m6Timer += Time.deltaTime;

        if (m1Timer >= (float)SpawnTimeEnum.m1SpawnTime)
        {
            SpawnEnemy(1);
            m1Timer -= (float)SpawnTimeEnum.m1SpawnTime;
        }

        if (m2Timer >= (float)SpawnTimeEnum.m2SpawnTime)
        {
            SpawnEnemy(2);
            m2Timer -= (float)SpawnTimeEnum.m2SpawnTime;
        }

        if (m3Timer >= (float)SpawnTimeEnum.m3SpawnTime)
        {
            SpawnEnemy(3);
            m3Timer -= (float)SpawnTimeEnum.m3SpawnTime;
        }
        if (m4Timer >= (float)SpawnTimeEnum.m4SpawnTime)
        {
            SpawnEnemy(4);
            m4Timer -= (float)SpawnTimeEnum.m4SpawnTime;
        }
        if (m5Timer >= (float)SpawnTimeEnum.m5SpawnTime)
        {
            SpawnEnemy(5);
            m5Timer -= (float)SpawnTimeEnum.m5SpawnTime;
        }
        if (m6Timer >= (float)SpawnTimeEnum.m6SpawnTime)
        {
            SpawnEnemy(6);
            m6Timer -= (float)SpawnTimeEnum.m6SpawnTime;
        }
    }

    private void SpawnEnemy(int enemyType)
    {

        switch(enemyType) {
            case 1:
                SpawnEnemy(m1Prefab, 5);
                break;
            case 2:
                SpawnEnemy(m2Prefab, 4);
                break;
            case 3:
                SpawnEnemy(m3Prefab, 3);
                break;
            case 4:
                SpawnEnemy(m4Prefab, 2);
                break;
            case 5:
                if (UnityEngine.Random.value <= 0.6f)
                {
                    SpawnEnemy(m5Prefab, 2);
                }
                
                break;
            case 6:
                if (UnityEngine.Random.value <= 0.2f)
                {
                    SpawnEnemy(m6Prefab, 1);
                }
                break;
        }
    }

    private void SpawnEnemy(GameObject prefabToSpawn, int amount)
    {
        float prefabSize = prefabToSpawn.GetComponent<Renderer>().bounds.size.x;
        float startX = -prefabSize;
        float gap = prefabSize;
        Timer timer = Timer.GetInstance();

        float positionSpawn;
        if (timer.GetTotalSeconds() == 10)
        {
            positionSpawn = ScreenUtils.ScreenTop;
        }
        else if(timer.GetTotalSeconds() == 15)
        {
            positionSpawn = ScreenUtils.ScreenTop;
        }
        else
        {

        }

        for (int i = 0; i <= amount; i++)
        {
           /* float mapTopY = 5f; 
            float randomY = Random.Range(-mapTopY, mapTopY);*/
            float randomY = UnityEngine.Random.Range(-ScreenUtils.ScreenTop, 0f);
            GameObject newPrefab = Instantiate(prefabToSpawn, new Vector3(ScreenUtils.ScreenLeft - startX + i * gap, randomY, 0f), Quaternion.identity);
        }
    }
}
