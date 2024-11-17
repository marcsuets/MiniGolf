using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de importar el espacio de nombres para UI

public class PushBall: MonoBehaviour
{
    private float force;
    public int seconds = 1; 
    public float speed = 1;
    public Slider slider;
    private LineRenderer lineaPotencia;
    private float maxLineLength = 1.0f; 
    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance.GetComponent<GameManager>();
        
        // Setup liniaPotencia
        lineaPotencia = gameObject.AddComponent<LineRenderer>(); 
        lineaPotencia.positionCount = 2; 
        lineaPotencia.startWidth = 0.05f; 
        lineaPotencia.endWidth = 0.05f; 
        lineaPotencia.material = new Material(Shader.Find("Sprites/Default")); 
        lineaPotencia.startColor = Color.grey; 
        lineaPotencia.endColor = Color.grey; 
        lineaPotencia.sortingOrder = 1;
    }

    // Update is called once por frame
    void Update()
    {
        // Obtener la posición del ratón en la pantalla
        Vector3 mousePosition = Input.mousePosition;
        // Convertir la posición del ratón a coordenadas del mundo
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
        mousePosition.z = 0; // Asegúrate de que z sea 0 para el 2D

        // Calcular la dirección desde el objeto hacia el ratón
        Vector2 direction = (mousePosition - transform.position).normalized;
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

        // Debug.Log(velocity.magnitude);
        if (velocity.magnitude <= 0.1)
        {
            velocity = new Vector2(0, 0);
            lineaPotencia.enabled=true;
        }else{
            lineaPotencia.enabled=false;
        }

        if (velocity.magnitude <= 0.1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                force = 0; // Reinicia la fuerza al presionar la tecla
                slider.gameObject.SetActive(true);
            }

            if (Input.GetMouseButton(0))
            {
                if (seconds == 0)
                {
                    seconds = 1;
                } 
                force += Time.deltaTime / seconds; 
                if (force >= 1)
                {
                    force = 1;
                } 
                slider.value = force;
            }

            if (Input.GetMouseButtonUp(0))
            {
                gm.increaseStrokes();
                GetComponent<Rigidbody2D>().AddForce(direction * (force * speed), ForceMode2D.Impulse);
                Invoke("ResetForce", 2);
            }
        }
        
        // Actualitzar i limitar llargada de la linea d'apuntar
        lineaPotencia.SetPosition(0, transform.position);
        float distance = Vector2.Distance(transform.position, mousePosition);
        if (distance > maxLineLength)
        {
            Vector2 adjustedPosition = (Vector2)transform.position + direction * maxLineLength;
            lineaPotencia.SetPosition(1, adjustedPosition); 
        }
        else
        {
            lineaPotencia.SetPosition(1, mousePosition); 
        }
    }

    private void ResetForce()
    {
        force = 0;
        slider.value = 0; // Reinicia la fuerza después de aplicarla
    }
}
