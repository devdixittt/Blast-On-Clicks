using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Targets;
    private float spawnRate = 2.0f;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI Lives;
    public Button restart;
    public bool isGameActive;
    private int score;
    public GameObject Titlescreen;
    private int life;
    public GameObject Panel;
    private bool paused;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            changePause();
        }
        
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    public void UpdateScore(int ScoretoAdd)
    {
        score += ScoretoAdd;
        ScoreText.text = "Score: " + score;
    }

    public void Live(int lives)
    {
        life += lives;
        Lives.text = "Lives: " + life;
        if(life <= 0)
        {
            GameOver();
        }
    }
    
    public void GameOver()
    {
        
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
        restart.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StarGame(int Difficulty)
    {
        isGameActive = true;
        spawnRate /= Difficulty;
        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
        Live(3);
        Titlescreen.gameObject.SetActive(false);


    }

    void changePause()
    {
        if (!paused)
        {
            paused = true;
            Panel.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            paused = false;
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
