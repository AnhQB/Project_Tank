using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie : MonoBehaviour
{

    public float move_speed;
    public float rotate_speed;
    public float aim_speed;
    Rigidbody2D r_body;
    public Transform shoot;
    public bool right, left, forward, back, turn;
    // Start is called before the first frame update
    void Start()
    {
        r_body =  GetComponent<Rigidbody2D>();
        transform.rotation = shoot.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //forward
        if (forward == true) 
        {
             r_body.velocity = transform.up * move_speed;
        }
		if (forward == false)
		{
			r_body.velocity = transform.up * 0;
		}
        //back
		if (back == true)
		{
			r_body.velocity = transform.up * -move_speed;
		}
        //right
		if (right == true)
		{
			transform.Rotate(0,0, -rotate_speed *Time.deltaTime);
		}
        //left
		if (left == true)
		{
			transform.Rotate(0, 0, rotate_speed * Time.deltaTime);
		}
        //turn
		if (turn == true)
		{
            shoot.transform.Rotate(0, 0, aim_speed * Time.deltaTime);
		}

	}
    public void Forward()
    {
        forward = true;
    }
    public void Forward_up()
    {
        forward = false;
    }
    public void Back()
    {
        back = true;
    }
    public void Back_up()
     {
        back = false;
     }
    public void Right()
    {
        right = true;
    }
    public void Right_up()
    {
        right = false;
    }
    public void Left()
    {
        left = true;
    }
    public void Left_up()
    
    {
        left = false;
    }
    public void Turn()
    {
        turn = true;
    }
    public void Turn_up()
    {
        turn = false;
    }
}
