using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public static Enemies instance;
    public float moveSpeed;

    public GameObject explosionEffect;
    void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {

    }


    void Update()
    {
        //Endles Run
        transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Robot")
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);

            gameObject.SetActive(false);
        }
    }
}
   