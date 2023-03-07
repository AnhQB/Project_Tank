using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M2Controller : MonoBehaviour
{
    float speedM2 = 5f;
    float HP = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            HP--;
            if(HP <= 0) {
                CloseMonster.GetInstance().Destroy(gameObject);
            }
        }
        else
        {
            CloseMonster.GetInstance().Destroy(gameObject);
        }
    }
}
