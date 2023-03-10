using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float x;
    public bool lateStartX;
    Rigidbody2D rb;
    BossCtrl bossCtrl;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
        Destroy(gameObject, 3f);
    }

    private void Update()
    {

        if (lateStartX == false)
        {
            x = transform.localEulerAngles.z;
            lateStartX = true;
        }
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
