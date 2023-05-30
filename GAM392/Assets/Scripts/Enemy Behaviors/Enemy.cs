using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    //GameObject enemy is moving towards
    public GameObject Heart;
    public GameManager gameManager;
    public float beatTempo;
    public AudioSource deathSound;
    private void Start()
    {
        beatTempo = beatTempo / 60f;
        deathSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Heart.transform.position, beatTempo * Time.deltaTime);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("hit");
            //gameObject.SetActive(false);
           
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag == "Player")
        {
          FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
             FindObjectOfType<AudioManager>().Play("Hit");
             deathSound.Play();
        }
    }

   
}
