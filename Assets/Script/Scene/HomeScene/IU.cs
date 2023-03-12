using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class IU : MonoBehaviour
{
    public GameObject Help, StartBtn, ScoreBtn, ExitBtn, ScorePop;
    bool checkOpen,checkScore;
    public Text textScore;
    void Start()
    {
       
        checkScore = true;
        checkOpen = true;
    }
    public void HelpPopup()
    {
        if(checkOpen ==false)
        {
            checkOpen = true;
            
            StartBtn.SetActive(true);
            ScoreBtn.SetActive(true);
            ExitBtn.SetActive(true);
            Help.transform.DOScale(new Vector3(0,0),1);
            Help.SetActive(false);
        }
        else if(checkOpen ==true)
        {
            StartBtn.SetActive(false);
            ScoreBtn.SetActive(false);
            ExitBtn.SetActive(false);
            checkOpen = false;
            Help.transform.DOScale(new Vector3(1, 1), 1);
            Help.SetActive(true);

        }    

    }
    public void LoadScene()
    {
        PlayerPrefs.SetInt("Damage", 0);
        SceneManager.LoadScene("move");
    }
    public void LoadScore()
    {
        if (checkScore == false)
        {
            checkScore = true;
            StartBtn.SetActive(true);
            ScoreBtn.SetActive(true);
            ExitBtn.SetActive(true);
            ScorePop.transform.DOScale(new Vector3(0, 0), 1);
            ScorePop.SetActive(false);

        }
        else if(checkScore == true)
        {
            checkScore = false;
            StartBtn.SetActive(false);
            ScoreBtn.SetActive(false);
            ExitBtn.SetActive(false);
            ScorePop.SetActive(true);
            ScorePop.transform.DOScale(new Vector3(1, 1), 1);
        }

        if(PlayerPrefs.GetInt("HighScore") == 0)
        {
            textScore.text = "Chua co du lieu, ban chua tham gia tro choi";


        }
        else
        {
            textScore.text = "Diem cao nhat la: " + PlayerPrefs.GetInt("HighScore");

        }
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    // Start is called before the first frame update

}
