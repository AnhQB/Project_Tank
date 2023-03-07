using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4Controller : MonoBehaviour
{
    public float HP = 6f;
    public float speedM4 = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedM4 * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
    }

    public static void Spawn()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            HP -= 0.75f;
            if (HP <= 0)
            {
                CloseMonster.GetInstance().Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Bullet2"))
        {
            HP -= 1.5f;
            if (HP <= 0)
            {
                CloseMonster.GetInstance().Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Bullet3"))
        {
            HP -= 3f;
            if (HP <= 0)
            {
                CloseMonster.GetInstance().Destroy(gameObject);
            }
        }
        else
        {
            CloseMonster.GetInstance().Destroy(gameObject);
        }
    }
}
