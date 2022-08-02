using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float x;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (x<5)
            {
                x = x+0.5f;
                transform.position =new Vector3(x, transform.position.y, z);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (x>0)
            {
                x = x-0.5f;
                transform.position = new Vector3(x, transform.position.y, z);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (z<10)
            {
                z = z+0.5f;
                transform.position = new Vector3(x, transform.position.y, z);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (z>0)
            {
                z = z-0.5f;
                transform.position = new Vector3(x, transform.position.y, z);
            }
        }
    }
    
}
