using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Image imgeColldown;
    [SerializeField] private TMP_Text textCooldown;

    private bool isCooldown = false;
    private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imgeColldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }


    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imgeColldown.fillAmount = 0.0f;
        }
        else
        { 
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imgeColldown.fillAmount = cooldownTimer / cooldownTime;

        }

    }

    public void UseSpell()
    {
        if (isCooldown)
        {
            
        }
        else
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            
        }
    }
}
