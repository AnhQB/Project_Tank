using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mana : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Slider manaTank;
    public Text manaText;

    public float myMana;

    private float curentLife;
    private float curentMana;
    private float calculatelife;

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curentMana < myMana)
        {
            manaTank.value = Mathf.MoveTowards(manaTank.value, 1f, Time.deltaTime * 0.01f);
            curentMana = Mathf.MoveTowards(curentMana/myMana, 1f, Time.deltaTime * 0.01f) * myMana;
        }
        manaText.text = "" + Mathf.FloorToInt(curentMana);
    }

    public void Damage(float damage)
    {
        curentLife -= damage;
    }
    public void ReduceMana(float mana)

    {
        if (mana <= curentMana)
        {
            curentMana -= mana;
            manaTank.value -= mana / myMana;
        }
        else
        {

        }

        
    }
}
