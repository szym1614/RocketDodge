using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
    public Rigidbody2D rb2d;
    
    // Use this for initialization
    

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, GameController.instance.scrollSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(0, GameController.instance.scrollSpeed);
    }
}
