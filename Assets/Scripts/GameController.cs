using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f; // Intervalo de tiempo entre la generación de tuberías
    public float minHeight = -1f; // Altura mínima para la tubería
    public float maxHeight = 3f; // Altura máxima para la tubería
    public Player player;
    public bool gameStarted;
    private void Start()
    {
        gameStarted = false;
    }

    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            player.StartGame();
            StartCoroutine(SpawnPipes());
        }
    }

    private IEnumerator SpawnPipes()
    {
        while (true)
        {
            Debug.Log("Coroutine esta viva");
            // Genera una nueva tubería
            float height = Random.Range(minHeight, maxHeight);
            GameObject newPipe = Instantiate(pipePrefab, new Vector3(transform.position.x, height, 0), Quaternion.identity);

            // Espera por el intervalo de tiempo antes de generar otra tubería
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void PlayerDie()
    {
        Debug.Log("Estoy llamando a player die");
        StopAllCoroutines();
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (var pipe in pipes)
        {
            pipe.GetComponent<Pipe>().move = false;
        }
    }

    private void RestartGame()
    {
        //Restart la escena
        Debug.Log("Player Die--> Restart Level");
        string sceneName = SceneManager.GetActiveScene().name;
            
        // Cargar la escena actual de nuevo
        SceneManager.LoadScene(sceneName);
    }
}
