using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(GameObject.Find("tankBody").transform.position.x, GameObject.Find("tankBody").transform.position.y + 2f, transform.position.z);


    }
}
