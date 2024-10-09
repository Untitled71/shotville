using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menucontrol : MonoBehaviour
{
    public string Scene1;
    public TextMeshProUGUI FinalScore;
    public float fscore = 0f;
    //public GameObject gm1;
    public void Loadscene()
    {
        SceneManager.LoadScene(Scene1, LoadSceneMode.Single);  
    }

    public void CloseGame()
    {
            Application.Quit();
    }

    public void Awake()
    {
        fscore = scorer.totalScore;
        FinalScore.text = "Last Score: " + fscore.ToString();
    }
}
