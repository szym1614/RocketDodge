using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
    private float backgroundVerticalLength;
    private BoxCollider2D b2d;
    
    // Use this for initialization

 
    void Start () {
        b2d = GetComponent<BoxCollider2D>();
        backgroundVerticalLength = b2d.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -backgroundVerticalLength)
        {
            RepositionBakcground();
        }
	}

    private void RepositionBakcground()
    {
        Vector2 backgroundOffset = new Vector2(0, backgroundVerticalLength * 2f);
        transform.position = (Vector2)transform.position + backgroundOffset;
    }
}
