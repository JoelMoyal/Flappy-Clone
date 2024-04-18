using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public GameObject gameOvertext;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;

    // Start is called before the first frame update
    void Awake()
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
    void Update()
    {
        if(gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BirdScored()
    {
        if (gameOver)
        {
            return;
           
        }
        score++;
        scoreText.text = "score:" + score;
    } 

    public void BirdDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }
}
