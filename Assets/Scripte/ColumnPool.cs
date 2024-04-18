using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnprefab;
    public int columnpoolsize = 5;
    public float spawnRate = 3f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private int currentColumn = 0;
    private Vector2 objectPoolPosition = new Vector2(-15, -25);
    private float spawnXPosition = 10f;
    private float timeSimceLastSpawned = 0f;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnpoolsize];
        for(int i = 0; i < columnpoolsize; i++)
        {
            columns[i] = Instantiate(columnprefab, objectPoolPosition, Quaternion.identity);
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        timeSimceLastSpawned += Time.deltaTime;

        if(!GameController.instance.gameOver && timeSimceLastSpawned >= spawnRate)
        {
            timeSimceLastSpawned = 0f;
            float spawnYposition = Random.Range(columnMin, columnMax);

            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYposition);
            currentColumn++;

            if (currentColumn >= columnpoolsize)
            {
                currentColumn = 0;
            }
        }
    }
}
