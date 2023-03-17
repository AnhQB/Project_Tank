using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    public float hit;
    public float HP = 200f;
    public float speedboss = 5f;
    public float speedshooting = 2f;
    public HealthBarBehaviour healthBar;

    // Start is called before the first frame update
    void Start()
    {
        hit = HP;
        healthBar.SetHealth(hit, HP);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedboss * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Bullet1"))
        {
            float st = collision.gameObject.GetComponent<bullet>().Damage;
            hit -= st;
            healthBar.SetHealth(hit, HP);
            if (hit <= 0)
            {
                DestroyExplode();
            }

        }
        if (collision.gameObject.tag.Contains("Rocket"))
        {
            float st = collision.gameObject.GetComponent<Rocket>().Damage;
            hit -= st;
            healthBar.SetHealth(hit, HP);
            if (hit <= 0)
            {
                DestroyExplode();
            }

        }
        if (collision.gameObject.tag.Contains("bomm"))
        {
            //float st = collision.gameObject.GetComponent<Bomm>().Damage;
            //hit -= st;
            //healthBar.SetHealth(hit, HP);
            //if (hit <= 0)
            //{
            DestroyExplode();
            //}

        }
    }

    private void DestroyExplode()
    {
        CloseMonster.GetInstance().Destroy(gameObject);
        Destroy(gameObject);
    }


   
}
