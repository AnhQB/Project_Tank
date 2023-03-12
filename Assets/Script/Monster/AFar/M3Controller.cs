using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class M3Controller : MonoBehaviour
{
    public float hit;
    public float HP = 4f;
    public float speedM3 = 5f;
    public HealthBarBehaviour healthBar;
    public GameObject item;
    float valueitem;
    // Start is called before the first frame update
    void Start()
    {
     
       
        valueitem = Random.Range(0, 100);

        hit = HP;
        healthBar.SetHealth(hit, HP);

    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedM3 * Time.deltaTime;
        FarMonster.GetInstance().Move(speed, this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Bullet1"))
        {
            float st = collision.gameObject.GetComponent<bullet>().Damage;
            hit -= st;
            healthBar.SetHealth(hit, HP);
            if (hit <= 0)
            {
                DestroyExplode();
            }

        }
		if (collision.gameObject.tag.Contains("Rocket"))
		{
			float st = collision.gameObject.GetComponent<bullet>().Damage;
			hit -= st;
			healthBar.SetHealth(hit, HP);
			if (hit <= 0)
			{
				DestroyExplode();
			}

		}
		if (collision.gameObject.tag.Contains("bomm"))
		{
			float st = collision.gameObject.GetComponent<bullet>().Damage;
			hit -= st;
			healthBar.SetHealth(hit, HP);
			if (hit <= 0)
			{
				DestroyExplode();
			}

		}


	}


    private void DestroyExplode()
    {
        FarMonster.GetInstance().Destroy(gameObject);
        if(valueitem>70)
        {
            GameObject iteInsm = Instantiate(item) as GameObject;
            iteInsm.transform.position = gameObject.transform.position;
        }
        Destroy(gameObject);
    }

}
