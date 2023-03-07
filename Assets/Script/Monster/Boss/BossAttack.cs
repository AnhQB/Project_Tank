using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack(enemy);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("Attack!");
            
        }
    }
    void Attack(GameObject target)
    {
        this.target = target;
    }
}
