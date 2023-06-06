using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score_Text;
    //Update score by adding increment method in Enemy class to 
    //score value reference
  
    public int score;

    public void Update()
    {
        score_Text.text = score.ToString(); 
    }


    public void updateScore()
    {
        Debug.Log(score);
        score++;
    }
}
