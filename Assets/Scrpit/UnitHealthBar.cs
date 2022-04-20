using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitHealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public TMPro.TextMeshProUGUI  textMesh;

	public void refillHealth()
	{
		slider.value = slider.maxValue;
		fill.color = gradient.Evaluate(1f);
		textMesh.text = ((int)slider.maxValue).ToString();
		
	}

	public void SetMaxHealth(float health)
	{
		slider.maxValue = health;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(float health)
	{
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
		textMesh.text = ((int)health).ToString();
	}

}
