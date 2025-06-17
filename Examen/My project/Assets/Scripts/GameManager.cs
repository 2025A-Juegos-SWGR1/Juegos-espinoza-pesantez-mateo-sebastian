using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Configuración de nivel")]
    public int totalFruits = 20;
    public float startTime = 60f;

    [Header("Referencias UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private int fruitsCollected;
    private float timeRemaining;
    private bool isGameOver;

    void Start()
    {
        fruitsCollected = 0;
        timeRemaining = startTime;
        UpdateScoreUI();
        UpdateTimerUI();
    }

    void Update()
    {
        if (isGameOver) return;

        // Actualiza temporizador
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            GameOver(false);
        }
        UpdateTimerUI();
    }

    public void CollectFruit()
    {
        if (isGameOver) return;

        fruitsCollected++;
        UpdateScoreUI();

        if (fruitsCollected >= totalFruits)
            GameOver(true);
    }

    public void PenalizeTime(float penalty)
    {
        if (isGameOver) return;

        timeRemaining = Mathf.Max(0f, timeRemaining - penalty);
        UpdateTimerUI();

        if (timeRemaining <= 0f)
            GameOver(false);
    }

    void UpdateScoreUI()
    {
        scoreText.text = $"Frutas: {fruitsCollected}/{totalFruits}";
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = $"Tiempo: {seconds}";
    }

    void GameOver(bool won)
    {
        isGameOver = true;

        // 1) Pausar todo el juego
        Time.timeScale = 0f;

        // 2) Detener spawners
        var fruitSpawner = FindObjectOfType<FruitSpawner>();
        if (fruitSpawner != null) fruitSpawner.StopSpawning();
        var obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        if (obstacleSpawner != null) obstacleSpawner.StopSpawning();

        // 3) Desactivar control del carrito
        var driver = FindObjectOfType<Driver>();
        if (driver != null) driver.enabled = false;

        Debug.Log(won ? "¡Victoria!" : "Se acabó el tiempo");
    }
}
