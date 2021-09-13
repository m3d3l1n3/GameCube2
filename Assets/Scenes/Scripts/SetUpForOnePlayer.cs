using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine;

public class SetUpForOnePlayer : MonoBehaviour
{
    public Dropdown dropdown;
    public void SetPlayerNumber()
    {
        GameState.TypeOfPlayer = dropdown.options[dropdown.value].text;
    }
}
