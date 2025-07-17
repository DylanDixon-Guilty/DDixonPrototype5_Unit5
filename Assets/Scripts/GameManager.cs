using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    public float SpawnRate; // Set to 1.5 seconds in Unity
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public bool IsGameOver = false;

    private int score;
    
    private void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// Used in the Target script to either add 15 points when you click on a good prop, or minus 15 points when you click on a bad prop
    /// </summary>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Every 1.5 seconds a random object will spawn and be sent upwards within view of the player
    /// </summary>
    private IEnumerator SpawnTarget()
    {
        while(IsGameOver == false)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    /// <summary>
    /// When the player clicks on a bad prop, the game ends
    /// </summary>
    public void GameOver()
    {
        IsGameOver = true;
        GameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
