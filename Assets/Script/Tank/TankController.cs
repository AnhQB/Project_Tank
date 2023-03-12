using Assets.Script.Enum;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public HealthBarBehaviourTank healthBar;
    // Start is called before the first frame update

    void Start()
    {
        //healthBar.SetHealth(Movie.GetInstance().Max_Health, Movie.GetInstance().Max_Health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float expTank = Movie.GetInstance().exp;
        GameObject collisionObj = collision.gameObject;
        if (expTank <= 320)
        {
            GetDameFromEnermy(collisionObj, 0);
        }
        else if(expTank <= 1280)
        {
            GetDameFromEnermy(collisionObj, 1);
        }
        else
        {
            GetDameFromEnermy(collisionObj, 2);
        }

        if(Movie.GetInstance().Current_Health <= 0)
        {
            //detroy -> game over
        }
    }

    private void GetDameFromEnermy(GameObject collisionObj, int expLevel)
    {
        // far
        switch (LayerMask.LayerToName(collisionObj.layer))
        {
            case "bulletMonster":

                if (collisionObj.CompareTag(BulletMonsterTag.BulletM1.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M1, expLevel);

                }
                else if (collisionObj.CompareTag(BulletMonsterTag.BulletM2.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M2, expLevel);
                }
                else if (collisionObj.CompareTag(BulletMonsterTag.BulletM3.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M3, expLevel);
                }
                else if (collisionObj.CompareTag(BulletMonsterTag.BulletBOSS.ToString()))
                {
                       Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.BOSS, expLevel);
                }

                break;
           case "Monster":
                if (collisionObj.CompareTag(MonsterTag.M1.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M1, expLevel);
                    healthBar.SetHealth(Movie.GetInstance().Current_Health, Movie.GetInstance().Max_Health);
                }
                else if (collisionObj.CompareTag(MonsterTag.M2.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M2, expLevel);
                    healthBar.SetHealth(Movie.GetInstance().Current_Health, Movie.GetInstance().Max_Health);
                }
                else if (collisionObj.CompareTag(MonsterTag.M3.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M3, expLevel);
                    healthBar.SetHealth(Movie.GetInstance().Current_Health, Movie.GetInstance().Max_Health);
                }
                else if (collisionObj.CompareTag(MonsterTag.M4.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M4, expLevel);
                    healthBar.SetHealth(Movie.GetInstance().Current_Health, Movie.GetInstance().Max_Health);
                }
                else if (collisionObj.CompareTag(MonsterTag.M5.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M5, expLevel);
                    healthBar.SetHealth(Movie.GetInstance().Current_Health, Movie.GetInstance().Max_Health);
                }
                else if (collisionObj.CompareTag(MonsterTag.M6.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.M6, expLevel);
                    healthBar.SetHealth(Movie.GetInstance().Current_Health, Movie.GetInstance().Max_Health);
                }
                else if (collisionObj.CompareTag(MonsterTag.BOSS.ToString()))
                {
                    Movie.GetInstance().Current_Health -= DameMonster.GetDameMonsterByType((int)MonsterTag.BOSS, expLevel);
                    healthBar.SetHealth(Movie.GetInstance().Current_Health, Movie.GetInstance().Max_Health);
                }
                break;
       }

    }
}
