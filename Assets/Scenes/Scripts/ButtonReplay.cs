using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonReplay : MonoBehaviour
{
    public void PlayAgain()
    {
        Debug.Log("Time to play again");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

}
