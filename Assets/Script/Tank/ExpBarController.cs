using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarController : MonoBehaviour
{
	public Slider slider;
	public Text text;

	private static ExpBarController instance;
	
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public static ExpBarController GetInstance()
	{
		return instance;
	}

	public void SetExp(float exp, float maxExp)
	{
		slider.gameObject.SetActive(true);
		slider.value = exp;
		slider.maxValue = maxExp;

		//slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
	}

	public void Start()
	{
		//slider = GetComponent<Slider>();
		/*slider.gameObject.SetActive(true);
        slider.value = Movie.GetInstance().Max_Health;
        slider.maxValue = Movie.GetInstance().Max_Health;*/
	}
	public void Update()
	{
		slider.value = Movie.GetInstance().exp;
		text.text = Math.Round(Movie.GetInstance().exp, 2).ToString();
    }
}
