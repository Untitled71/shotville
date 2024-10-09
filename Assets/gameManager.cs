using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor.SearchService;

public class gameManager : MonoBehaviour
{

    public float myTimer = 0f;
    public float myfixedTimer = 0f;

    public GameObject ime;
    public GameObject myPlayer;
    //public GameObject collectable1;

    public TextMeshProUGUI MyScore;
    public TextMeshProUGUI Lives;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    //public Transform spawn5;

    public float spawnINterval = 2f;
    public float spawnTimer = 0f;
    float health;
    public float pscore = 0f;
    private int e = 0;
    private int i = 0;


    //public float finalscore = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        scorer.deadenemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(i);
       // Debug.Log(spawnINterval);
        //Debug.Log(spawnTimer);
        myTimer += Time.deltaTime;
        // once interval is hit, spawn enemy and reset timer
        spawnTimer += Time.deltaTime + ((e%10) * .00025f);

        i = (int)myTimer;

        if (i%5 == 4) {
            //Debug.Log("YESS");
            e++;

        }

        int wherespawn = 0;
        if (spawnTimer >= spawnINterval)
        {
            spawnTimer = 0f; //+ 1 * myTimer;
            if (e%7 < 3)
            {
                wherespawn = Random.Range(1, 5);
            }
            else
            {
                wherespawn = Random.Range(5, 12);
            }
            if(wherespawn == 1)
            {
                Instantiate(ime, spawn1.position, Quaternion.identity);
            }
            if(wherespawn == 2)
            {
                Instantiate(ime, spawn2.position, Quaternion.identity);
            }
            if(wherespawn == 3)
            {
                Instantiate(ime, spawn3.position, Quaternion.identity);
            }
            if(wherespawn == 4)
            {
                Instantiate(ime, spawn4.position, Quaternion.identity);
            }
            if(wherespawn == 5 || wherespawn == 6)
            {
                Instantiate(ime, spawn1.position, Quaternion.identity);
                Instantiate(ime, spawn2.position, Quaternion.identity);
            }
            if(wherespawn == 7 || wherespawn == 8)
            {
                Instantiate(ime, spawn3.position, Quaternion.identity);
                Instantiate(ime, spawn4.position, Quaternion.identity);
            }
            if(wherespawn == 9)
            {
                Instantiate(ime, spawn1.position, Quaternion.identity);
                Instantiate(ime, spawn2.position, Quaternion.identity);
                Instantiate(ime, spawn3.position, Quaternion.identity);
                Instantiate(ime, spawn4.position, Quaternion.identity);
            }
            if(wherespawn == 10)
            {
                Instantiate(ime, spawn1.position, Quaternion.identity);
                Instantiate(ime, spawn3.position, Quaternion.identity);
            }
            if(wherespawn == 11)
            {
                Instantiate(ime, spawn2.position, Quaternion.identity);
                Instantiate(ime, spawn4.position, Quaternion.identity);
            }

            //Debug.Log("enemy spawn");
        }
        health = myPlayer.GetComponent<movement>().PlayerLife;
        Lives.text = health.ToString();

        pscore += Time.deltaTime;
        MyScore.text = (pscore * (1 + (0.05f * scorer.deadenemies))).ToString();

        if (health == 0) 
        {
            scorer.totalScore = pscore * (1 + (0.05f * scorer.deadenemies));
            //Destroy(myPlayer.gameObject);
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        /*int spawnobj = 0;
        spawnobj = Random.Range(0, 100);
        if (spawnobj == 4)
        {
            Instantiate(collectable1, spawn5);
        }*/
    }

    private void FixedUpdate()
    {
        myfixedTimer -= Time.fixedDeltaTime;
    }
}
