using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTank : MonoBehaviour
{
	public Movie playerHealth;
	public Image fillImage;
	private Slider slider;

	private void Awake()
	{
		slider = GetComponent<Slider>(); 
	}

	
	private void Update()
	{

		if (slider.value <= slider.minValue)
		{
			fillImage.enabled = false;
		}
		if (slider.value > slider.minValue && !fillImage.enabled)
		{
			fillImage.enabled = true;
		}

		
		float fillValue = playerHealth.Current_Health / playerHealth.Max_Health;

		if (fillValue <= slider.maxValue / 3)
		{
			fillImage.color = Color.white;
		}
		else if(fillValue > slider.maxValue / 3)
		{
			fillImage.color= Color.red;
		}
		slider.value = fillValue;


	}

}
