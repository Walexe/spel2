using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_1 : MonoBehaviour {
    public float upforce = 100f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    
    // Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isDead == false)
        {
            if (Input.GetMouseButton(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upforce));
                anim.SetTrigger("Flap");
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero; 
        isDead = true;
        anim.SetTrigger("Die");
        gameController.instance.Birddied ();
    }
}
