using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    [SerializeField] float speed = 5f;

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
            Attack(); ;
        }
    }

    private static void Attack()
    {
        Debug.Log("Attack");
    }
}
