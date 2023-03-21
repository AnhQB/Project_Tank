using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarController : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManaBarController mn;
    public Slider manaTank;
    public Text manaText;

    private static ManaBarController instance;

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

    public static ManaBarController GetInstance()
    {
        return instance;
    }

    public void SetMana(float exp, float maxExp)
    {
        manaTank.gameObject.SetActive(true);
        manaTank.value = exp;
        manaTank.maxValue = maxExp;
    }

    void Start()
    {
       // mana.mn = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (curentMana < myMana)
        {
            manaTank.value = Mathf.MoveTowards(manaTank.value, 1f, Time.deltaTime * 0.01f);
            curentMana = Mathf.MoveTowards(curentMana/myMana, 1f, Time.deltaTime * 0.01f) * myMana;
        }*/
        manaTank.value = Movie.GetInstance().mana;
        manaText.text = "" + Movie.GetInstance().mana;
    }

}
