using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    //GameObject enemy is moving towards
    public GameObject Heart;
    [SerializeField]
    private float moveSpeed = 1f;
    public GameManager gameManager;



    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Heart.transform.position, moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
          FindObjectOfType<GameManager>().EndGame();
           
        }
    }



}
