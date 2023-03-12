using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public static bullet blt;
    public float Damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        bullet.blt = this;
        float f=10;
        float dameIm = PlayerPrefs.GetInt("Damage");
        if(dameIm ==0)
        {
            Damage = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if(dameIm == 1)
        {
            Damage = 2f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0.8f,0.3f,1f);

        }
        else if (dameIm == 2)
        {
            Damage = 3f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

        }
        else if (dameIm == 3)
        {
            Damage = 4f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(1, 0.5f, 0); ;

        }
        else if (dameIm == 4)
        {
            Damage = 5f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x - GameObject.Find("Target").transform.position.x, transform.position.y - GameObject.Find("Target").transform.position.y)*f;
        Destroy(gameObject, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
