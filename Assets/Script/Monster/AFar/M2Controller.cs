using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2Controller : MonoBehaviour
{
    float speedM2 = 5f;
    float hit;
    float HP = 2f;
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
        float speed = speedM2 * Time.deltaTime;
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
                hit--;
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
        healthBar.SetHealth(hit, HP);
    }

    private void DestroyExplode()
    {
        Destroy(gameObject);
        FarMonster.GetInstance().Destroy(gameObject);
    }
}
