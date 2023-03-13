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

    private GameObject positionCave1;
    private GameObject positionCave2;
    private GameObject positionCave3;
    private GameObject positionCave4;
    private GameObject positionCaveStart;
    private void Awake()
    {
        positionCave1 = GameObject.FindWithTag("Cave1");
        positionCave2 = GameObject.FindWithTag("Cave2");
        positionCave3 = GameObject.FindWithTag("Cave3");
        positionCave4 = GameObject.FindWithTag("Cave4");
        positionCaveStart = GameObject.FindWithTag("CaveStart");
    }

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
                if (Movie.GetInstance().exp <= 320)
                {
                    if (UnityEngine.Random.value <= 0.5f)
                    {
                        SpawnEnemy(m5Prefab, 2);
                    }
                }else if (Movie.GetInstance().exp <= 1280)
                {
                    if (UnityEngine.Random.value <= 0.6f)
                    {
                        SpawnEnemy(m5Prefab, 2);
                    }
                }
                else
                {
                    if (UnityEngine.Random.value <= 0.8f)
                    {
                        SpawnEnemy(m5Prefab, 2);
                    }
                }
                break;
            case 6:
                if (Movie.GetInstance().exp <= 320)
                {
                    if (UnityEngine.Random.value <= 0.15f)
                    {
                        SpawnEnemy(m6Prefab, 1);
                    }
                }
                else if (Movie.GetInstance().exp <= 1280)
                {
                    if (UnityEngine.Random.value <= 0.2f)
                    {
                        SpawnEnemy(m6Prefab, 1);
                    }
                }
                else
                {
                    if (UnityEngine.Random.value <= 0.3f)
                    {
                        SpawnEnemy(m6Prefab, 1);
                    }
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
        float positionSpawnX = 0f;
        float positionSpawnY = 0f;
        //Debug.Log("Time : " + timer.GetTotalSeconds());
        if (timer.GetTotalSeconds() <= 20)
        {
            positionSpawnX = positionCaveStart.transform.position.x;
            positionSpawnY = UnityEngine.Random.Range(positionCaveStart.transform.position.y, 0f);
        } else if (timer.GetTotalSeconds() >= 10) {
       
            if (UnityEngine.Random.value <= 0.2f)
            {
                positionSpawnX = positionCave1.transform.position.x;
                positionSpawnY = UnityEngine.Random.Range(positionCave1.transform.position.y, 0f);
            }
            if (UnityEngine.Random.value <= 0.5f)
            {
                positionSpawnX = positionCave2.transform.position.x;
                positionSpawnY = UnityEngine.Random.Range(positionCave2.transform.position.y, 0f);
            }
            if (UnityEngine.Random.value <= 0.7f)
            {
                positionSpawnX = positionCave3.transform.position.x;
                positionSpawnY = UnityEngine.Random.Range(positionCave3.transform.position.y, 0f);
            }
            if (UnityEngine.Random.value <= 1f)
            {
                positionSpawnX = positionCave4.transform.position.x;
                positionSpawnY = UnityEngine.Random.Range(positionCave4.transform.position.y, 0f);
            }
            
        }
        for (int i = 0; i <= amount; i++)
        {
           /* float mapTopY = 5f; 
            float randomY = Random.Range(-mapTopY, mapTopY);*/
            GameObject newPrefab = Instantiate(prefabToSpawn, 
                new Vector3(positionSpawnX - startX + i * gap, positionSpawnY, 0f), Quaternion.identity);
        }
    }
}
