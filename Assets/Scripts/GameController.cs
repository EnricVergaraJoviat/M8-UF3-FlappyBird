using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f; // Intervalo de tiempo entre la generación de tuberías
    public float minHeight = -1f; // Altura mínima para la tubería
    public float maxHeight = 3f; // Altura máxima para la tubería

    private void Start()
    {
        StartCoroutine(SpawnPipes());
    }

    private IEnumerator SpawnPipes()
    {
        while (true)
        {
            // Genera una nueva tubería
            float height = Random.Range(minHeight, maxHeight);
            GameObject newPipe = Instantiate(pipePrefab, new Vector3(transform.position.x, height, 0), Quaternion.identity);

            // Espera por el intervalo de tiempo antes de generar otra tubería
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
