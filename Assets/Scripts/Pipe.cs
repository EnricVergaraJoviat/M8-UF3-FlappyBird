using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f; // Velocidad a la que se mueve la tubería

    private void Update()
    {
        // Mueve la tubería hacia la izquierda
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
