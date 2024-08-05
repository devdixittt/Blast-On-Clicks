using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficultymanager : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int Difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");

        gameManager.StarGame(Difficulty);
    }
    
}
