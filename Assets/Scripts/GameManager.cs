using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coins = 0;
    public int strokes = 0;
    private String playerName = "";
    public TMP_InputField inputName;
    public TMP_Text top5Text;
    
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

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("GamManager duplicat i eliminat");
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        DisplayTop5();
        
    }

    // Métodes per a la navegació
    public void HomeSceneToLevel1()
    {
        playerName = inputName.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            playerName = ("player" + UnityEngine.Random.Range(1, 10000));
            SceneManager.LoadScene("Level1");
        }
    }
    public void Level1To2()
    {
        resetCoins();
        SceneManager.LoadScene("Level2");
    }
    public void Level2To3()
    {
        resetCoins();
        SceneManager.LoadScene("Level3");
    }
    public void Level3To4()
    {
        resetCoins();
        SceneManager.LoadScene("Level4");
    }
    public void Level4To5()
    {
        resetCoins();
        SceneManager.LoadScene("Level5");
    }
    public void Level5ToFinishScene()
    {
        resetCoins();
        SceneManager.LoadScene("FinishScene");
    }
    
    //Al agafar moneda (s'utilitza al script Coin)
    public void incrementCoin()
    {
        coins++;
        Debug.Log("increment coin");
    }

    public int getCoins()
    {
        return coins;
    }

    public void resetCoins()
    {
        coins = 0;
    }

    public int getStrokes()
    {
        return strokes;
    }
    
    public void resetStrokes()
    {
        strokes = 0;
    }

    public void increaseStrokes()
    {
        strokes++;
    }

    public String getName()
    {
        return playerName;
    }
    
    public void resetName()
    {
        name = null;
    }
    
    private void DisplayTop5()
    {
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

        // Asignar el texto al componente TMP_Text
        top5Text.text =
            $"1. {name1} ({strokes1} strokes)\n" +
            $"2. {name2} ({strokes2} strokes)\n" +
            $"3. {name3} ({strokes3} strokes)\n" +
            $"4. {name4} ({strokes4} strokes)\n" +
            $"5. {name5} ({strokes5} strokes)";
    }
}

