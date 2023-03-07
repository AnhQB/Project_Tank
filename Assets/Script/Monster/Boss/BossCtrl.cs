using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    
    [SerializeField] float speed = 3;

    Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GameObject targetPickup = GameObject.FindWithTag("TankBody");
        transform.position = Vector3.MoveTowards(transform.position, targetPickup.transform.position, speed * Time.deltaTime);
        
    }
}
