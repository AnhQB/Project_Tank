using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseBtn, ExitBtn, ContinueBtn, PlayGameBtn;
    bool CheckClickGPlay;
    float k, x, y, z;
    public GameObject bullet;
    public GameObject rocket;
    float timeP, timeS;
    public TextMeshProUGUI TextTime;
    void Start()
    {
        timeP = 15;
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
        SceneManager.LoadScene("HomeScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void InsBullet()
    {
        GameObject bl = Instantiate(bullet) as GameObject;
        bl.transform.position = GameObject.Find("tankGreen").transform.position;
        bl.transform.rotation = GameObject.Find("tankGreen").transform.rotation;
    }
    public void InsRocket()
    {
		GameObject rc = Instantiate(rocket) as GameObject;
		rc.transform.position = GameObject.Find("tankGreen").transform.position;
		rc.transform.rotation = GameObject.Find("tankGreen").transform.rotation;
	}
    private void FixedUpdate()
    {
        timeS -= Time.deltaTime;
        if(timeS<=0)
        {
            timeS = 60;
            timeP--;
        }
        TextTime.text = (int)timeP + ":" + (int)timeS;

    }
}
