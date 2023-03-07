using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M5Controller : MonoBehaviour
{
    public float HP = 8f;
    public float speedM5 = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
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
            CloseMonster.GetInstance().Destroy(gameObject);
            if (collision.gameObject.CompareTag("Bullet1"))
            {
                HP -= 0.5f;
                if (HP <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("Bullet2"))
            {
                HP -= 1f;
                if (HP <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("Bullet3"))
            {
                HP -= 2f;
                if (HP <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("Bullet4"))
            {
                HP -= 4f;
                if (HP <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

         
    }
}
