using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class M3Controller : MonoBehaviour
{
    public float hit;
    public float HP = 4f;
    public float speedM3 = 5f;
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
        float speed = speedM3 * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
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
            else if (collision.gameObject.CompareTag("Bullet2"))
            {
                hit -= 2f;
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
        FarMonster.GetInstance().Destroy(gameObject);
    }

}
