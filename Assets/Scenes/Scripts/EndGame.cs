using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    //public Text gaameOverScene;
    int MaxScore = 2;
   
    // Update is called once per frame
    public void Ending()
    {
        GameState.ScoreTeam1 = Score.PointsGate1;
        GameState.ScoreTeam2 = Score.PointsGate2;
        if (Score.PointsGate1 + Score.PointsGate2 == MaxScore)
        {
            if (GameState.ScoreTeam1 > GameState.ScoreTeam2) GameState.Winner = "Blue team";
            else GameState.Winner = "Red team";
            GameState.HasGameEnded = true;
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
            FindObjectOfType<Text>().text = "Game Over!" + Environment.NewLine + "The winner is: " + GameState.Winner;
            //FindObjectOfType<>
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //???
    }

}

public static class GameState
{
    public static int ScoreTeam1;
    public static int ScoreTeam2;
    public static string Winner;
    public static bool HasGameEnded = false;
}
