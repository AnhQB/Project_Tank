using Assets.Script.Monster.Close;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M6Controller : MonoBehaviour
{
    public float hit;
    public float HP = 6f;
    public float speedM6 = 7f;
    public HealthBarBehaviour healthBar;
    // Start is called before the first frame update
    void Start()
    {
        hit = HP;
        healthBar.SetHealth(hit, HP);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = speedM6 * Time.deltaTime;
        CloseMonster.GetInstance().Move(speed, this.gameObject);
    }

    public static void Spawn()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void DestroyExplode()
    {
        Destroy(gameObject);
        CloseMonster.GetInstance().Destroy(gameObject);
    }
}
