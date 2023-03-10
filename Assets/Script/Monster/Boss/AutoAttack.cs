using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireInterval;
    public float detectionRange = 10000f;
    private float timer;

    BossCtrl bossCtrl;
    private void Start()
    {
        

        bossCtrl = GetComponent<BossCtrl>();
        fireInterval = bossCtrl.speedshooting;

    }
    void Update()
    {
        
        timer += Time.deltaTime;

       
        if (timer >= fireInterval)
        {
            
            GameObject closestEnemy = FindClosestEnemy();

           
            if (closestEnemy != null)
            {
                Vector3 targetDirection = closestEnemy.transform.position - transform.position;
                transform.right = targetDirection.normalized;

                
                Fire();
            }

            
            timer = 0f;
        }
    }

    GameObject FindClosestEnemy()
    {
        // Find all enemies within range
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("TankBody");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // Find the closest enemy
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= detectionRange)
            {
                closestEnemy = enemy;
                closestDistance = distance;
               // Debug.Log(enemy.transform.position.x + "," + enemy.transform.position.y);
            }
        }

        return closestEnemy;
    }

    void Fire()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);


        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * 1500f);
        
    }
}
