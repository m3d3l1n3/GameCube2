using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class DissablePlayer2 : MonoBehaviour
{
    public GameObject Player2;
    public void Start()
    {
        if (GameState.TypeOfPlayer == "Single player") Player2.SetActive(false);
    }
}
