using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movement : MonoBehaviour
{
    public float PlayerLife = 3f;
    //accel is public so we can find in the unity interface
    public float Haccel = 10f;
    public float Vaccel = 10f;

    private Vector2 mouse;
    private Rigidbody2D rb;
    private float mx;
    private float my;

    public GameObject bulletPrefab;
    public Transform firingPoint;
    public float playerscore;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        //Vector3 currentDir = Dir();
        //currentDir.x *= Haccel;
        //currentDir.y *= Vaccel;
        //transform.Translate(currentDir);
        rb.velocity = new Vector2(mx, my).normalized * Haccel;
    }

    public Vector3 Dir()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 myDir = new Vector3(x, y, 0);
        return myDir;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player has collided with: " +  collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            PlayerLife--;

        }



    }

    private void Shoot()
    {
       Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);

    }

}