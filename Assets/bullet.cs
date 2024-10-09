using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10f;
    private float lifeTime = 3f;


    public GameObject myPlayer;
    private Rigidbody2D rb;
    //public float score;
    //public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        myPlayer = FindObjectOfType<movement>().gameObject;
        //score = myPlayer.GetComponent<movement>().playerscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet has collided with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            scorer.deadenemies++;
            Debug.Log(scorer.deadenemies);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "inanimate")
        {
            Destroy(gameObject);
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;

    }
}
