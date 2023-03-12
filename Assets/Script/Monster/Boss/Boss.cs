using Assets.Script.Monster;
using Assets.Script.Monster.AFar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour,IMonster
{
    public GameObject prefabExplosion;
    private const float distanceToAttack = 10f;

    private static Boss instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static Boss GetInstance()
    {
        return instance;
    }
    public void Attack(float dame, GameObject monster)
    {

    }

    public void Move(float speed, GameObject monster)
    {
        GameObject targetPickup = GameObject.FindWithTag("TankBody");
        monster.transform.position = Vector3.MoveTowards(monster.transform.position, targetPickup.transform.position, speed);
    }

    public void Destroy(GameObject monster)
    {
        Instantiate<GameObject>(prefabExplosion, monster.transform.position, Quaternion.identity);
    }
}
