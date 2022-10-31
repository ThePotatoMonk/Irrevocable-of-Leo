using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreText;

    //Variables
    public static GameManager instance;
    private static int health = 6;
    private static int maxHealth = 6;       
    private static float moveSpeed = 8f;    
    private static float attackRate = 0.5f;

    public static float timeInvincible = 2.0f;
    private static bool isInvincible;

    int coinsAmount;
    int enemiesKilled;
    int playerScore;

    protected float Timer;

    // makes these variables accessable in a certain way   
    public static int Health { get => health; set => health = value; }
    public static int MaxHealth { get => maxHealth; set => maxHealth = value; } 
    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; } 
    public static float FireRate { get => attackRate; set => attackRate = value; }

    public static event Action OnPlayerDamaged;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        playerScore = 400;
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore();
        CheckHighScore();
    }

    // Take damage function
    public static void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            health -= damage;
            OnPlayerDamaged?.Invoke();
            Debug.Log("Health: " + health + "/" + maxHealth);
            if (health <= 0)
            {
                Debug.Log("Health < 0");
                KillPlayer();
            }
        }

    }

    // Move speed change
    public static void MoveSpeedChange(float speed)
    {
        moveSpeed += speed;
    }

    public static void FireRateChange(float rate)
    {
        attackRate -= rate;
    }

    public static void HealPlayer(int healAmount)
    {
        Health = Mathf.Min(maxHealth, Health + healAmount);
    }

    private static void KillPlayer()
    {
        
    }

    private void OnEnable()
    {
        Coin.OnCoinCollected += IncreaseCoins;
        EnemyController.OnEnemyKilled += EnemiesKilled;
    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= IncreaseCoins;
        EnemyController.OnEnemyKilled -= EnemiesKilled;
    }

    public void PlayerScore()
    {
        Timer += Time.deltaTime;

        // When the timer passes 1 second
        if (Timer >= 1)
        {
            // Resets timer, takes 1 away from playerScore
            Timer = 0f;
            playerScore--;
        }
        // Updates and checks high score
        UpdateScore();
        CheckHighScore();
    }

    // When collecting coins this runs
    public void IncreaseCoins()
    {
        coinsAmount++;
        playerScore += 2;

    }

    // When an enemy gets killed this runs
    public void EnemiesKilled()
    {
        enemiesKilled++;
        playerScore += 5;
        //PlayerPrefs.SetInt("HighScore", enemiesKilled);
        //PlayerPrefs.GetInt("HighScore");
        Debug.Log("Enemies Killed: " + enemiesKilled);
    }

    private void UpdateScore()
    {
        // Updates score
        scoreText.text = $"Score: {playerScore}";
    }

    private void CheckHighScore()
    {
        // When playerScore is higher then high score
        if(playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            // Saving high score to local computer
            PlayerPrefs.SetInt("HighScore", playerScore);
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        // Loading high score from local computer
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}


