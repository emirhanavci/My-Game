using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public float speed;

    public bool MoveRight;

    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(0, speed, 0);
            //   transform.localScale = new Vector2(, 2);
        }
        else
        {
            transform.Translate(0,-speed, 0);
            // transform.localScale = new Vector2(-2, 2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Turn")
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }
}