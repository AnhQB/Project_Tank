using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4Controller : MonoBehaviour
{
    public float hit;
    public float HP = 6f;
    public float speedM4 = 5f;
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
        float speed = speedM4 * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Bullet"))
        {
            if (collision.gameObject.CompareTag("Bullet1"))
            {
                hit -= 0.75f;
                healthBar.SetHealth(hit, HP);
                if (hit <= 0)
                {
                    DestroyExplode();
                }
            }
            else if (collision.gameObject.CompareTag("Bullet2"))
            {
                hit -= 1.5f;
                healthBar.SetHealth(hit, HP);
                if (hit <= 0)
                {
                    DestroyExplode();
                }
            }
            else if (collision.gameObject.CompareTag("Bullet3"))
            {
                hit -= 3f;
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
        CloseMonster.GetInstance().Destroy(gameObject);
        Destroy(gameObject);
    }
}
