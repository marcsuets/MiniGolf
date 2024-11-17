using System;
using UnityEngine;

public class ResetBallPosition : MonoBehaviour
{
    private GameObject ball;
    private GameObject startPoint;
    
    private void Start()
    {
        // Asignar referencias una sola vez
        ball = GameObject.FindGameObjectWithTag("Ball");
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar que la colisión sea con la pelota
        if (collision.CompareTag("Ball"))
        {
            // Verificar si las referencias no son nulas antes de mover la pelota
            if (ball != null && startPoint != null)
            {
                // Reposicionar la pelota en el punto de inicio
                ball.transform.position = startPoint.transform.position;
                ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}