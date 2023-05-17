using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_press : MonoBehaviour
{
    public string enteringScene;
    void OnMouseDown()
    {
        SceneManager.LoadScene(enteringScene);
    }
}
