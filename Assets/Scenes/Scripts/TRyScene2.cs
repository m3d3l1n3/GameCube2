using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TRyScene2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if (GameState.HasGameEnded)
        {
            Debug.Log("Hello");
            FindObjectOfType<Text>().text = "Game Over!" + Environment.NewLine + "The winner is: " + GameState.Winner;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
