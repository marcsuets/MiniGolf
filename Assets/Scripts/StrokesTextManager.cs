using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrokesTextManager : MonoBehaviour
{
    private GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        gameObject.GetComponent<TextMeshProUGUI>().text = "Strokes: " + gm.getStrokes();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Strokes: " + gm.getStrokes();
    }
}
