using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMangerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;


    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
		SceneManager.LoadScene("move");
	}
}
