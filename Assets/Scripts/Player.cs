using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float flapForce = 200f;
    private Rigidbody2D rb;
    private Animator animator;
    private GameController gc;
    private bool gameStarted = false;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.isKinematic = true;
    }

    public void StartGame()
    {
        rb.isKinematic = false;
        animator.SetInteger("State", 1);
        gameStarted = true;
    }

    void Update()
    {
        if (gameStarted && Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    void Flap()
    {
        rb.velocity = Vector2.up * flapForce;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "Border Up")
        {
            animator.SetInteger("State", 2);
            gc.PlayerDie();
        }
    }
}
