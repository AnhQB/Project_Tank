using Assets.Script.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movie : MonoBehaviour
{
    public FixedJoystick joystick;
    public float move_speed;
    public float rotate_speed;
    public float aim_speed;
    Rigidbody2D r_body;
    public Transform shoot;
    public bool right, left, forward, back, turn;
    public static bool PointerDown = false;
    public float Current_Health;
    public float Max_Health;
    public float speedFlash;
   
	public float exp = 0;
	public float maxExp = 10;
    public int level = 1;
    public int prevlevel = 1;
    public float mana = 0;
    public float maxMana = 10;


	public static Movie instance;

    Vector2 move;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Movie GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        mana = maxExp = 10;
        speedFlash = 1f;
        r_body =  GetComponent<Rigidbody2D>();
        transform.rotation = shoot.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       
        //if(Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == null)
        //{
        //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.GetChild(0).transform.position;
        //    pos.Normalize();
        //    float z = Mathf.Atan2(pos.x, pos.y)*Mathf.Rad2Deg;
        //    gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, 0, -z));
        //}
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

        float hAxis = move.x;
        float VAxis = move.y;
        float zAxis = Mathf.Atan2(hAxis, VAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
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
			r_body.velocity = transform.up * -move_speed ;
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

        SettingLevel();
    }

    private void SettingLevel()
    {
        if(exp < (int)LevelTank.Level2)
        {
            level = 1;
        }else if(exp < (int)LevelTank.Level3)
        {
            level = 2;
        }
        else if (exp < (int)LevelTank.Level4)
        {
            level = 3;
        }else if(exp < (int)LevelTank.Level5)
        {
            level = 4;
        }
        else if (exp < (int)LevelTank.Level6)
        {
            level = 5;
        }
        else if (exp < (int)LevelTank.Level7)
        {
            level = 6;
        }
        else if (exp < (int)LevelTank.Level8)
        {
            level = 7;
        }
        else if (exp < (int)LevelTank.Level9)
        {
            level = 8;
        }
        else if (exp < (int)LevelTank.Level10)
        {
            level = 9;
        }
        else 
        {
            level = 10;
        }

        if(prevlevel < level)
        {
            SetHealthByLevel();
            SetManaByLevel();
            SetBaseSpeed();
            prevlevel = level;
        }

    }

    private void SetBaseSpeed()
    {
        move_speed++;
    }

    private void SetManaByLevel()
    {
        if(level <= 4)
        {
            mana += 5;
            maxMana = 12f;
        }else if (level <= 7)
        {
            mana += 6;
            maxMana = 15f;
        }
        else if(level <= 9)
        {
            mana += 7;
            maxMana = 18f;
        }
        else
        {
            mana = maxMana;
            maxMana = 20f;
        }
    }

    private void SetHealthByLevel()
    {
        if (level <= 5)
        {
            Current_Health += 5f;
            Max_Health += 5;
        }
        else
        {
            Current_Health += 10f;
            Max_Health += 10;
        }
    }

    /*public void TangToc()
    {
        speedFlash = 3f;
    } */
    private void FixedUpdate()
	{
        if(speedFlash>1)
        {
            speedFlash -= Time.deltaTime;
        }  
        if (PointerDown)
        {
            r_body.velocity = Vector3.zero;
        }
        else
        {
			r_body.MovePosition(r_body.position + move * move_speed*speedFlash * Time.fixedDeltaTime);
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
