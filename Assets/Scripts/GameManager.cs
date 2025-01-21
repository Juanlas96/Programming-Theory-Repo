using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private float boundary = 10;
    private int wave = 1;
    public bool isGameOver = false;
    public GameObject gameOverUI;
    public List<GameObject> enemies;
    // Encapsulation
    public static GameManager instance { get; private set;}


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && isGameOver == false)
        {
            wave++;
            StartWave();
        }
    }

    // Abstraction
    private void StartWave()
    {
        for(int i = 0; i < wave; i++)
        {
            SpawnEnemies();
        }
    }

    // Abstraction
    private void SpawnEnemies()
    {
        int randomIndex = Random.Range(0, enemies.Count);
        Vector3 spawnPos = new Vector3(Random.Range(-boundary, boundary), 0, Random.Range(-boundary, boundary));
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
        isGameOver = true;
    }

    public void GoBackToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
