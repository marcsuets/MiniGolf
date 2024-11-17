using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScreen : MonoBehaviour
{
    private GameManager gm;
    public TextMeshProUGUI textGoodJob;
    private String playerName;
    
    void Start()
    {
        gm = GameManager.Instance.GetComponent<GameManager>();
        playerName = gm.getName();
        gameObject.GetComponent<TextMeshProUGUI>().SetText("Your you used  " + gm.getStrokes().ToString() + " Strokes!");
        textGoodJob.text = "Good job, " + playerName +"!";
        
        // Llamar al método AddEntry del script de Scoreboard
        var scoreboard = FindObjectOfType<ScoreboardManager>(); // Asegúrate de que el script del scoreboard tenga este nombre
        if (scoreboard != null)
        {
            scoreboard.AddEntry(playerName, gm.getStrokes());
        }
        else
        {
            Debug.LogError("No se encontró el script de Scoreboard.");
        }
    }

    public void buttonToMenu()
    {
        gm.resetStrokes();
        gm.resetName();
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }
}
