using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1Controller : MonoBehaviour
{
    float speedM1 = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedM1 * Time.deltaTime;
        FarMonster.GetInstance().Move(speed, this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Bullet"))
        {
            DestroyExplode();
        }
    }

    private void DestroyExplode()
    {
        Destroy(gameObject);
        FarMonster.GetInstance().Destroy(gameObject);
    }

}
