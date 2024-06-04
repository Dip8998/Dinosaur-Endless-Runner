using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _hiScoreText;
    public float gameSpeed { get; private set; }
    public float gameSpeedIncrement = 0.5f;
    public float startingGameSpeed = 5f;
    private float timer;
    private float _score;
    private float _hiScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        Time.timeScale = 1.0f;
    }
    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _score = 0;
        gameSpeed = startingGameSpeed;
    }

    void Update()
    {
        GameSpeed();
        UpdateHighScore();
    }

    private void GameSpeed()
    {
        gameSpeed += gameSpeedIncrement * Time.deltaTime;
        _score += gameSpeed * Time.deltaTime;
        _scoreText.text = Mathf.FloorToInt(_score).ToString("D5");
        ObstacalSpawnSpeed();
    }

    private void ObstacalSpawnSpeed()
    {
        if (gameSpeed > 8 && gameSpeed < 18)
        { 
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                OBJspawner.Instance.maxTimer -= 0.05f;


                timer = 0f;
            }
        }
        if (gameSpeed > 18)
        {
            OBJspawner.Instance.maxTimer = 0.8f;
        }
    }
    public void GameOver()
    {
        _canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        
    }

    private  void UpdateHighScore()
    {
        _hiScore = PlayerPrefs.GetFloat("hiscore", 0);
        if(_score > _hiScore)
        {
            _hiScore = _score;
            PlayerPrefs.SetFloat("hiscore", _hiScore);

        }
        _hiScoreText.text = Mathf.FloorToInt(_hiScore).ToString("D5");
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
}
