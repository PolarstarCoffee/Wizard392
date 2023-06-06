using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_press : MonoBehaviour
{
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("st");

        SceneManager.LoadScene("LevelDesign_Demo");
    }
}
