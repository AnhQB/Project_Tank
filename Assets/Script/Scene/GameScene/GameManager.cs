using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Script.Tank;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseBtn, ExitBtn, ContinueBtn, PlayGameBtn;
    bool CheckClickGPlay;
    float k, x, y, z;
    public GameObject bullet;
    public GameObject rocket;
    public GameObject bomm;
    float timeP, timeS;
    public TextMeshProUGUI TextTime;
    public float cooldownRocket;
    public float cooldownBomm;
    public float cooldownSpeed;
    public TextMeshProUGUI textBtnRocket;
    public TextMeshProUGUI textBtnBom;
    public TextMeshProUGUI textBtnSpeed;
    public TextMeshProUGUI textLvRocket;
    public TextMeshProUGUI textLvBom;

    private float currentLvRocket = 1;
    private float currentLvBom = 1;

    void Start()
    {
        timeP = 0;
        timeS = 0;
        TextTime.text = (int)timeP + ":" + (int)timeS;
        k = 2.5f;
        x = PauseBtn.transform.position.y;
        y = ContinueBtn.transform.position.y;
        z = ExitBtn.transform.position.y;
        CheckClickGPlay = true;

    }
    public void GamePlay()
    {
        if(CheckClickGPlay==true)
        {
            CheckClickGPlay = false;
            PauseBtn.SetActive(true);
            ExitBtn.SetActive(true);
            ContinueBtn.SetActive(true);
            PauseBtn.transform.DOMoveY(PlayGameBtn.transform.position.y - k, 1f);
            ContinueBtn.transform.DOMoveY(PlayGameBtn.transform.position.y - 2*k, 1f);
            ExitBtn.transform.DOMoveY(PlayGameBtn.transform.position.y - 3*k, 1f);
        }
        else if(CheckClickGPlay==false)
        {
            CheckClickGPlay = true;
            PauseBtn.transform.DOMoveY(x, 0.5f);
            ContinueBtn.transform.DOMoveY(y, 0.5f);
            ExitBtn.transform.DOMoveY(z, 0.5f);
            PauseBtn.SetActive(false);
            ExitBtn.SetActive(false);
            ContinueBtn.SetActive(false);
        }
    }
    public void PauseGame()
    {
        CheckClickGPlay = false;
        Time.timeScale = 0;
        GamePlay();
    }
    public void ContinueGame()
    {
        CheckClickGPlay = false;
        Time.timeScale = 1;
        GamePlay();
    }
    public void ExitGame()
    {
        DOTween.KillAll();
        Time.timeScale = 1;
        SceneManager.LoadScene("HomeScene");
    }
    // Update is called once per frame
    void Update()
    {
        if(cooldownBomm > 0)
        {
            cooldownBomm -= Time.deltaTime;
            textBtnBom.text = "" + Math.Round(cooldownBomm, 1);
        }
        else
        {
            textBtnBom.gameObject.SetActive(false);
        }

        if(cooldownRocket > 0)
        {
            cooldownRocket -= Time.deltaTime;
            textBtnRocket.text = "" + Math.Round(cooldownRocket, 1); 
        }
        else
        {
            textBtnRocket.gameObject.SetActive(false);
        }

        if (cooldownSpeed > 0)
        {
            cooldownSpeed -= Time.deltaTime;
            textBtnSpeed.text = "" + Math.Round(cooldownSpeed, 1);
        }
        else
        {
            textBtnSpeed.gameObject.SetActive(false);
        }

        if(currentLvBom != ItemTank.GetInstance().boomLevel)
        {
            currentLvBom = ItemTank.GetInstance().boomLevel;
            textLvBom.text = "" + currentLvBom;
        }

        if (currentLvRocket != ItemTank.GetInstance().rocketLevel)
        {
            currentLvRocket = ItemTank.GetInstance().rocketLevel;
            textLvRocket.text = "" + currentLvRocket;

        }

    }
    public void InsBullet()
    {
        GameObject bl = Instantiate(bullet) as GameObject;
        bl.transform.position = GameObject.Find("tankGreen").transform.position;
        bl.transform.rotation = GameObject.Find("tankGreen").transform.rotation;
    }
    public void InsRocket()
    {
		if(cooldownRocket <= 0)
        {
            if (ItemTank.GetInstance().rocketLevel == 1)
            {
                if (Movie.GetInstance().mana >= 1)
                {
                    ShootRocket();
                    Movie.GetInstance().mana -= 1;
                    cooldownRocket = 3;
                }
            }
            else if (ItemTank.GetInstance().rocketLevel == 2)
            {
                if (Movie.GetInstance().mana >= 3)
                {
                    ShootRocket();
                    Movie.GetInstance().mana -= 3;
                    cooldownRocket = 4;
                }
            }
            else
            {
                if (Movie.GetInstance().mana >= 5)
                {
                    ShootRocket();
                    Movie.GetInstance().mana -= 5;
                    cooldownRocket = 5;
                }
            }
            textBtnRocket.gameObject.SetActive(true);
        }
    }

    private void ShootRocket()
    {
        GameObject rc = Instantiate(rocket) as GameObject;
        rc.transform.position = GameObject.Find("tankGreen").transform.position;
        rc.transform.rotation = GameObject.Find("tankGreen").transform.rotation;
    }

	public void InsBomm()
	{
		if(cooldownBomm <= 0)
        {

            if (ItemTank.GetInstance().boomLevel == 1)
            {
                if (Movie.GetInstance().mana >= 1)
                {
                    SetBom();
                    Movie.GetInstance().mana -= 1;
                    cooldownBomm = 3;
                }

            }
            else if (ItemTank.GetInstance().boomLevel == 2)
            {
                if (Movie.GetInstance().mana >= 3)
                {
                    SetBom();
                    Movie.GetInstance().mana -= 3;
                    cooldownBomm = 4;
                }
            }
            else
            {
                if (Movie.GetInstance().mana >= 5)
                {
                    SetBom();
                    Movie.GetInstance().mana -= 5;
                    cooldownBomm = 5;
                }
            }
            textBtnBom.gameObject.SetActive(true);
        }
    }

    private void SetBom()
    {
        GameObject bo = Instantiate(bomm) as GameObject;
        bo.transform.position = GameObject.FindGameObjectWithTag("TankBody").transform.position;
        bo.transform.rotation = GameObject.FindGameObjectWithTag("TankBody").transform.rotation;
    }

    public void InsSpeed()
    {
        if(cooldownSpeed <= 0)
        {
            Movie.GetInstance().speedFlash = 3f;
            cooldownSpeed = 6;
            Movie.GetInstance().mana -= 5;
            textBtnSpeed.gameObject.SetActive(true);
        }
    }

	private void FixedUpdate()
    {
        timeS += Time.deltaTime;
        if(timeS>=60 && timeP <15)
        {
            timeS = 0;
            timeP++;
        }
        TextTime.text = (int)timeP + ":" + (int)timeS;

    }
}
