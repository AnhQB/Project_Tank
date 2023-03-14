using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class item : MonoBehaviour
{
    public Sprite[] itemIMG;
    float setitem;
    // Start is called before the first frame update
    private void Awake()
    {
        setitem = Random.Range(0, 100);
        if (setitem >= 0 && setitem <= 45)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = itemIMG[0];

        }
        else if (setitem > 45 && setitem < 90)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = itemIMG[1];

        }
        else if (setitem >= 90 && PlayerPrefs.GetInt("Damage") <= 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = itemIMG[2];

        }
        else if(setitem >= 90 && PlayerPrefs.GetInt("Damage") > 3)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
       
        Debug.Log(setitem);
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == "TankBody")
        {
            if (setitem >= 0 && setitem<=45)
            {
                Movie.instance.Current_Health += 10;
                if(Movie.instance.Current_Health>Movie.instance.Max_Health)
                {
                    Movie.instance.Current_Health = Movie.instance.Max_Health;
                }
                Destroy(gameObject);

            }
            else if (setitem >45 && setitem<95)
            {
                mana.mn.curentMana += 5;
                if(mana.mn.curentMana >mana.mn.myMana)
                {
                    mana.mn.curentMana = mana.mn.myMana;
                }
                Destroy(gameObject);

            }
            else if (setitem >= 95 && PlayerPrefs.GetInt("Damage")<=3)
            {
                PlayerPrefs.SetInt("Damage", PlayerPrefs.GetInt("Damage") + 1);
                Destroy(gameObject);

            }
            else if (setitem >=90 && PlayerPrefs.GetInt("Damage") > 3)
            {
                Destroy(gameObject);
            }


        }
    }
}
