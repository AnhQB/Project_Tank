using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    public float speed = 5f;
    public float speedShoot = 2f;
    [SerializeField] int damage = 10;

    Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        this.Move();
        
    }

    protected virtual void Move()
    {
        GameObject targetPickup = GameObject.FindWithTag("TankBody");
        transform.position = Vector3.MoveTowards(transform.position, targetPickup.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("TankBody"))
        {
            Attack(); 
        }
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            hp -= 10f;
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private static void Attack()
    {
        Debug.Log("Attack");
    }

    
}
