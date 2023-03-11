using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	public float Damage = 1f;
	// Start is called before the first frame update
	void Start()
    {
		float f = 10;
		gameObject.GetComponent<Rigidbody2D>().velocity = 
			new Vector2(transform.position.x - GameObject.Find("Target").transform.position.x, transform.position.y 
			- GameObject.Find("Target").transform.position.y) * f;
		Destroy(gameObject, 3f);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
