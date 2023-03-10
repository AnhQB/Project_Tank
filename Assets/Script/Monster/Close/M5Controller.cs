using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M5Controller : MonoBehaviour
{
    public float hit;
    public float HP = 8f;
    public float speedM5 = 6f;
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
        float speed = speedM5 * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
    }

    public static void Spawn()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Bullet"))
        {
            if (collision.gameObject.CompareTag("Bullet1"))
            {
                hit -= 0.5f;
                healthBar.SetHealth(hit, HP);
                if (hit <= 0)
                {
                    DestroyExplode();
                }
            }
            else if (collision.gameObject.CompareTag("Bullet2"))
            {
                hit -= 1f;
                healthBar.SetHealth(hit, HP);
                if (hit <= 0)
                {
                    DestroyExplode();
                }
            }
            else if (collision.gameObject.CompareTag("Bullet3"))
            {
                hit -= 2f;
                healthBar.SetHealth(hit, HP);
                if (hit <= 0)
                {
                    DestroyExplode();
                }
            }
            else if (collision.gameObject.CompareTag("Bullet4"))
            {
                hit -= 4f;
                healthBar.SetHealth(hit, HP);
                if (hit <= 0)
                {
                    DestroyExplode();
                }
            }
            else
            {
                DestroyExplode();
            }
        }

         
    }

    private void DestroyExplode()
    {
        Destroy(gameObject);
        CloseMonster.GetInstance().Destroy(gameObject);
    }
}
