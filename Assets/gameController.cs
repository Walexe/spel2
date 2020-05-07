using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public static gameController instance;
    public GameObject gameovertext;
    public bool gameover = false;
    public Text scoreText;
    public float scrollspeed = -1.5f;

    private int score = 0;

    private void Awake()
    {
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
	void Update ()
    {
		if (gameover == true && Input.GetMouseButtonDown (0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
    
    public void BirdScored ()
    {
        if (gameover)
        {
            return; 
        }
        score++;
        scoreText.text = "Score" + score.ToString ();
    }


    public void Birddied ()
    {
        gameovertext.SetActive (true);
        gameover = true;
    }
}
