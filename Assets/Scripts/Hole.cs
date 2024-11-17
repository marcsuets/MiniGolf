using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public int currentLevel = -1; // 0 = HomeScene, 100 = FinishScene
    public int requiredCoins = 0;
    public TextMeshProUGUI coinsLeft = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coinsLeft != null)
        {
            coinsLeft.text = "Coins left: " + (requiredCoins - GameManager.Instance.getCoins());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLevel();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Ball ha de tenir el tag "Ball"
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 2f)
            {
                if (requiredCoins == GameManager.Instance.getCoins())
                {
                    Debug.Log("Hole");
                    Destroy(collision.gameObject);
                    Invoke("NextLevel", 2f);
                }
                else
                {
                    Debug.Log("Get all the coins to finish the level");
                }
                
            }
            else
            {
                Debug.Log("Too fast!");
            }
        }

    }

    void NextLevel()
    {
        switch (currentLevel)
        {
            case 1:
                GameManager.Instance.Level1To2();
                break;
            case 2:
                GameManager.Instance.Level2To3();
                break;
            case 3:
                GameManager.Instance.Level3To4();
                break;
            case 4:
                GameManager.Instance.Level4To5();
                break;
            case 5:
                GameManager.Instance.Level5ToFinishScene();
                break;
        }
    }
}
