using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public static Rocket instance;
    public float speed = 5f;
    public float dirX;
    public bool inGame = false;

    private Rigidbody2D rb2d;
    private Vector2 originalRocketPosition;
    
    

    // Use this for initialization
    void Start()
    {
        originalRocketPosition = instance.transform.position;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();


        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        if (inGame)
        {
            dirX = Input.acceleration.x * speed;
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5f, 5f), transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(dirX, 0f);
    }

    public void UpdateRocketPosition()
    {
        rb2d.velocity = new Vector2(0, 0);
        instance.transform.position = originalRocketPosition;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //rb2d.velocity = Vector2.zero;

        //inGame = false;

        //GameController.instance.EndGame();

        if (collision.gameObject.GetComponent<Obstacle>() != null)
        {
            rb2d.velocity = Vector2.zero;
            inGame = false;
            GameController.instance.EndGame();
        }

    }
}
