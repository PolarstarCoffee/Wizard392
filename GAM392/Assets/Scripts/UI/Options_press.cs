using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options_press : MonoBehaviour
{
    void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("op");
        SceneManager.LoadScene("Options");
    }
}
