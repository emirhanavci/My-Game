using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{ // P><L
    public static Controller instance;
    private Touch touch;
    public float speedModifier, moveSpeed, yzSpeed, boostTimer;
    public bool booster;
    public GameObject finishMenu;
    //, sol, sað, orta, touchEnd;
    // Rigidbody rigi;


    public TMP_Text puanText, liveText;
    private int puanScore = 0, liveScore = 1;

    void Start()
    {
        //   rigi = GetComponent <Rigidbody>(); 

        moveSpeed = 5.0f;
        boostTimer = 0.0f;
       // booster = false;
       // orta = true;

    }

   
    void LateUpdate()
    {
        // Endless Run
        // eski yöntem -  transform.Translate(0, 0, moveSpeed * Time.deltaTime);         
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // Yönlendirme
      //  Vector3 rightGo = new Vector3(-1f, transform.position.y, transform.position.z);
      //  Vector3 leftGo = new Vector3(-2f, transform.position.y, transform.position.z);
      //  Vector3 middleGo = new Vector3(-1.5f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //  transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
                transform.Translate(Vector3.right * touch.deltaPosition.x * speedModifier, Space.World);
            }
        }
        // Limit
        if (transform.position.x > -1)
            transform.position = new Vector3(-1, transform.position.y, transform.position.z);
        if (transform.position.x < -2)
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);

        // Booster
        if (booster == true)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= 5)
            {
                moveSpeed = moveSpeed - 10;
                boostTimer = 0;
                booster = false;
            }
        }
        if (liveScore < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            puanScore++;
            puanText.text = "" + puanScore;
            SoundManager.instance.PlayStar();
        }
        if (other.tag == "Lives")
        {
            liveScore++;
            liveText.text = "" + liveScore;
            SoundManager.instance.PlayStar();
        }
        if (other.tag == "Boost")
        {
            moveSpeed = moveSpeed + 10;
            booster = true;
            SoundManager.instance.PlayBoost();
        }
        if (other.tag == "Speeder")
        {
            moveSpeed++;
        }
        if (other.tag == "enemies")
        {
            liveScore--;
            liveText.text = "" + liveScore;
            SoundManager.instance.PlayBomb();
        }
        if (other.tag == "Finish")
        {
            finishMenu.SetActive(true);
        }
    }
    IEnumerator WaitFixedFrame()
    {
        yield return new WaitForFixedUpdate();
    }

}
