using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3Controller : MonoBehaviour
{
    public float HP = 4f;
    public float speedM3 = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedM3 * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            HP --;
            if (HP <= 0)
            {
                CloseMonster.GetInstance().Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Bullet2"))
        {
            HP -= 2f;
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
