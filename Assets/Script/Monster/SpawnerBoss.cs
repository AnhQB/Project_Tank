using Assets.Script.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    protected float timeSpawn = 0f;
    protected float timeDlay = 300f;
    public GameObject bossPrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.timeSpawn += Time.deltaTime;
        if (this.timeSpawn < this.timeDlay) return;
        else
        {
            this.timeSpawn = 0;
            GameObject minion = Instantiate(bossPrefab);
            minion.transform.position = transform.position;
        }

    }
}
