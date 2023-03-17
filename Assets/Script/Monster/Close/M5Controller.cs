using Assets.Script.Monster.AFar;
using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M5Controller : MonoBehaviour
{
    public float hit;
    public float HP = 8f;
    public float speedM5 = 6f;
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
        float speed = speedM5 * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
    }

    public static void Spawn()
    {

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
        if(Movie.GetInstance().exp <= 320)
        {
            Movie.GetInstance().exp += 0.5f;
        }else if(Movie.GetInstance().exp <= 1280)
        {
            Movie.GetInstance().exp += 1f;
        }
        else
        {
            Movie.GetInstance().exp = 3f;
        }
        FarMonster.GetInstance().Destroy(gameObject);
        if (valueitem > 80)
        {
            GameObject iteInsm = Instantiate(item) as GameObject;
            iteInsm.transform.position = gameObject.transform.position;
        }
        Destroy(gameObject);
    }
}
