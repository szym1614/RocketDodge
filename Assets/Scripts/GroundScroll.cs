using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour {
    public static GroundScroll instance;
    public Rigidbody2D rb2d;
    public Vector2 originalGroundPosition;

    // Use this for initialization
    void Awake () {
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

    private void Start()
    {
        originalGroundPosition = instance.transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ScrollGround()
    {
        rb2d.velocity = new Vector2(0, -3.5f);
    }

    public void UpdateGroundPosition()
    {
        rb2d.velocity = new Vector2(0, 0);
        instance.transform.position = originalGroundPosition;
    }
}
