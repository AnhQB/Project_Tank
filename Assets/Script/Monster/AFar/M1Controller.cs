using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class M1Controller : MonoBehaviour
{
    float speedM1 = 4f;
    public GameObject item;

    float valueitem;
    public float speedShooting = 2f;
    // Start is called before the first frame update
    void Start()
    {
        valueitem = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedM1 * Time.deltaTime;
        FarMonster.GetInstance().Move(speed, this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Bullet1"))
        {
           
             DestroyExplode();
            

        }
      

    }


    private void DestroyExplode()
    {
        FarMonster.GetInstance().Destroy(gameObject);
        if (valueitem > 70)
        {
            GameObject iteInsm = Instantiate(item) as GameObject;
            iteInsm.transform.position = gameObject.transform.position;
        }
        Destroy(gameObject);
    }

}
