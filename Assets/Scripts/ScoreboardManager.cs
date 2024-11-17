using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    private int strokes1;
    private int strokes2;
    private int strokes3;
    private int strokes4;
    private int strokes5;

    private String name1;
    private String name2;
    private String name3;
    private String name4;
    private String name5;


    void Start()
    {
        // Cargar datos guardados en PlayerPrefs
        name1 = PlayerPrefs.GetString("Name1", "-");
        strokes1 = PlayerPrefs.GetInt("Strokes1", 9999);

        name2 = PlayerPrefs.GetString("Name2", "-");
        strokes2 = PlayerPrefs.GetInt("Strokes2", 9999);

        name3 = PlayerPrefs.GetString("Name3", "-");
        strokes3 = PlayerPrefs.GetInt("Strokes3", 9999);

        name4 = PlayerPrefs.GetString("Name4", "-");
        strokes4 = PlayerPrefs.GetInt("Strokes4", 9999);

        name5 = PlayerPrefs.GetString("Name5", "-");
        strokes5 = PlayerPrefs.GetInt("Strokes5", 9999);
        
        Invoke("PrintScores", 5f);
    }
    
    public void AddEntry(string name, int strokes)
    {
        // Empezamos comprobando si la nueva puntuación es mejor que la posición 5
        if (strokes < strokes5)
        {
            // Si es mejor que la posición 5, movemos la puntuación 4 a la 5
            name5 = name4;
            strokes5 = strokes4;

            if (strokes < strokes4)
            {
                // Movemos la puntuación 3 a la 4
                name4 = name3;
                strokes4 = strokes3;

                if (strokes < strokes3)
                {
                    // Movemos la puntuación 2 a la 3
                    name3 = name2;
                    strokes3 = strokes2;

                    if (strokes < strokes2)
                    {
                        // Movemos la puntuación 1 a la 2
                        name2 = name1;
                        strokes2 = strokes1;

                        if (strokes < strokes1)
                        {
                            // Nueva puntuación es la mejor, reemplaza al top 1
                            name1 = name;
                            strokes1 = strokes;
                        }
                        else
                        {
                            // Nueva puntuación ocupa la posición 2
                            name2 = name;
                            strokes2 = strokes;
                        }
                    }
                    else
                    {
                        // Nueva puntuación ocupa la posición 3
                        name3 = name;
                        strokes3 = strokes;
                    }
                }
                else
                {
                    // Nueva puntuación ocupa la posición 4
                    name4 = name;
                    strokes4 = strokes;
                }
            }
            else
            {
                // Nueva puntuación ocupa la posición 5
                name5 = name;
                strokes5 = strokes;
            }
        }

        // Guardar el top 5 actualizado en PlayerPrefs
        SaveScores();
    }
    
    private void SaveScores()
    {
        PlayerPrefs.SetString("Name1", name1);
        PlayerPrefs.SetInt("Strokes1", strokes1);

        PlayerPrefs.SetString("Name2", name2);
        PlayerPrefs.SetInt("Strokes2", strokes2);

        PlayerPrefs.SetString("Name3", name3);
        PlayerPrefs.SetInt("Strokes3", strokes3);

        PlayerPrefs.SetString("Name4", name4);
        PlayerPrefs.SetInt("Strokes4", strokes4);

        PlayerPrefs.SetString("Name5", name5);
        PlayerPrefs.SetInt("Strokes5", strokes5);

        PlayerPrefs.Save();
    }
    
    // Método para mostrar el top 5 (opcional, para debug)
    public void PrintScores()
    {
        Debug.Log($"1: {name1} - {strokes1} strokes");
        Debug.Log($"2: {name2} - {strokes2} strokes");
        Debug.Log($"3: {name3} - {strokes3} strokes");
        Debug.Log($"4: {name4} - {strokes4} strokes");
        Debug.Log($"5: {name5} - {strokes5} strokes");
    }
}
