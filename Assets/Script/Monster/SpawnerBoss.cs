using Assets.Script.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    public GameObject bossPrefab;
    

    private float m1Timer = 0f;
   

    private void Update()
    {
        m1Timer += Time.deltaTime;
        

        if (m1Timer >= (float)SpawnTimeEnum.m1SpawnTime)
        {
            SpawnEnemy(1);
            m1Timer -= (float)SpawnTimeEnum.m1SpawnTime;
        }

        
    }

    private void SpawnEnemy(int enemyType)
    {

        switch (enemyType)
        {
            case 1:
                SpawnEnemy(bossPrefab, 1);
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

        else if (timer.GetTotalSeconds() == 15)
        {
            positionSpawn = ScreenUtils.ScreenTop;
        }
        else
        {

        }


        for (int i = 0; i <= amount; i++)
        {
            
            float randomY = UnityEngine.Random.Range(-ScreenUtils.ScreenTop, 0f);
            GameObject newPrefab = Instantiate(prefabToSpawn, new Vector3(ScreenUtils.ScreenLeft - startX + i * gap, randomY, 0f), Quaternion.identity);
        }
    }
}
