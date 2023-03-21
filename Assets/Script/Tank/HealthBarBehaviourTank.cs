using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviourTank : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;

    private static HealthBarBehaviourTank instance;
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

    public static HealthBarBehaviourTank GetInstance()
    {
        return instance;
    }
    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = health;
        slider.maxValue= maxHealth;

        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    public void Start()
    {
        //slider = GetComponent<Slider>();
        slider.gameObject.SetActive(true);
        slider.value = Movie.GetInstance().Max_Health;
        slider.maxValue = Movie.GetInstance().Max_Health;
    }

    // Update is called once per frame
    public void Update()
    {
        slider.value = Movie.GetInstance().Current_Health;
    }
}
