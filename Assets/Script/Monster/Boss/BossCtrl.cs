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
    public float HP = 100f;
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


    //public float hit;
    //[SerializeField] float hp = 100f;
    //public float speed = 5f;
    //public float speedShoot = 2f;
    //[SerializeField] int damage = 10;
    //public HealthBarBehaviour healthBar;
    //Rigidbody2D rigidbody2D;
    //void Start()
    //{
    //    hit = hp;
    //    healthBar.SetHealth(hit, hp);
    //}
    //private void Awake()
    //{
    //    rigidbody2D= GetComponent<Rigidbody2D>();
    //}
    //private void Update()
    //{
    //    this.Move();

    //}

    //protected virtual void Move()
    //{
    //    GameObject targetPickup = GameObject.FindWithTag("TankBody");
    //    transform.position = Vector3.MoveTowards(transform.position, targetPickup.transform.position, speed * Time.deltaTime);
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.Contains("TankBody"))
    //    {
    //        Attack(); 
    //    }
    //    if (collision.gameObject.tag.Contains("Bullet"))
    //    {
    //        if (collision.gameObject.CompareTag("Bullet1"))
    //        {
    //            hit--;
    //            healthBar.SetHealth(hit, hp);
    //            if (hit <= 0)
    //            {
    //                DestroyExplode();
    //            }
    //        }
    //        else if (collision.gameObject.CompareTag("Bullet2"))
    //        {
    //            hit -= 2f;
    //            healthBar.SetHealth(hit, hp);
    //            if (hit <= 0)
    //            {
    //                DestroyExplode();
    //            }
    //        }
    //        else
    //        {
    //            DestroyExplode();
    //        }
    //    }
    //}

    //private static void Attack()
    //{
    //    Debug.Log("Attack");
    //}
    //private void DestroyExplode()
    //{
    //    FarMonster.GetInstance().Destroy(gameObject);
    //    Destroy(gameObject);
    //}

}
