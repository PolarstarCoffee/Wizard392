using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Score : MonoBehaviour
{
    //Update score by adding increment method in Enemy class to 
    private int score; //score value reference

    private SpriteRenderer scoreSprite; //score sprite reference 
    void Start()
    {
        score = 0; //initalize score to 1
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
