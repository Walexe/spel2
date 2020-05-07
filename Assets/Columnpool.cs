using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columnpool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public float spawnrate = 4f; 
    public GameObject columnPrefab;
    public float columnMin = -1f;
    public float columnMax = -3.5f;

    private GameObject[] columns; 
    private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0; 

	// Use this for initialization
	void Start ()
    {   
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject) Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity); 
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (gameController.instance.gameover == false && timeSinceLastSpawned >= spawnrate )
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }

    }
}

