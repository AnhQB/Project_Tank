using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	public float Damage = 1f;
    private float distance = 30f;
    private Vector3 startPostion;

    public float forceMagnitude = 100f;
    public float recoilMagnitude = 10f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float f = 10;
        startPostion = GameObject.FindWithTag("TankBody").transform.position;
        gameObject.GetComponent<Rigidbody2D>().velocity = 
			new Vector2(transform.position.x - GameObject.Find("Target").transform.position.x, transform.position.y 
			- GameObject.Find("Target").transform.position.y) * f;
		Destroy(gameObject, 3f);
        
	}

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, startPostion);
        if(distance >= this.distance)
        {
            //Debug.Log("kc: " + distance);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer).Equals("bulletMonster"))
        {
            // Lấy vị trí của Rocket và đạn quái
            Vector2 rocketPosition = transform.position;
            Vector2 bulletPosition = collision.gameObject.transform.position;

            // Tính toán hướng và khoảng cách giữa Rocket và đạn quái
            Vector2 direction = rocketPosition - bulletPosition;
            float distance = direction.magnitude;

            // Đảm bảo khoảng cách lớn hơn 0 để tránh chia cho 0
            if (distance > 0)
            {
                // Chuẩn hóa hướng
                direction /= distance;

                // Đẩy đạn quái theo hướng của Rocket
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * forceMagnitude, ForceMode2D.Impulse);

                // Giảm thiểu tác động của đạn quái lên Rocket bằng cách đẩy Rocket ngược lại
                rb.AddForce(-direction * recoilMagnitude, ForceMode2D.Impulse);

                
            }

            Destroy(collision.gameObject);
        }
    }
}
