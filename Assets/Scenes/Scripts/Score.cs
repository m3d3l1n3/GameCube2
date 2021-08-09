using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using System.Text;
using System;
using Random = UnityEngine.Random; //alias 

public class Score : MonoBehaviour
{
    #region Declarations
    public Rigidbody Ball;
    public GameObject Player1;
    public GameObject Player2;
    public static int PointsGate1;
    public static int PointsGate2;
    public Text ScoreTextGate1;
    public Text ScoreTextGate2;
    public Time timeFromScore;
    public Text GoalScored;
    public Text TextTimer;
    float IntTimer = 1000f;
    public Timer Timer;
    float CountDownSpeed = 1.5f;
    public GameObject supplyPrefab;
    private static bool SupplyHasntSpawn = false;
    int supplyNumber = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        ScoreTextGate1.text = "Score team blue";
        ScoreTextGate2.text = "Score team red";
        GoalScored.text = "Score";
        PointsGate1 = 0;
        PointsGate2 = 0;
        Timer = new Timer(2000);
        Timer.AutoReset = false;
        Timer.Elapsed += Tseconds_Elapsed;
        Timer.Start();
        SpawnSupply();
        SpawnSupply();
        SpawnSupply();
    }

    private void Tseconds_Elapsed(object sender, ElapsedEventArgs e)
    {
        //Debug.Log("Timer elapsed");
        SupplyHasntSpawn = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Plane")
        {
            Goal();
            FindObjectOfType<EndGame>().Ending();
        }
        if (collision.collider.name == "Plane2")
        {
            Goal2();
            FindObjectOfType<EndGame>().Ending();
        }
    }

    private void Goal()
    {
        PointsGate1 = PointsGate1 + 1;
        GoalScored.text = "Blue team scored a goal";
        GoalScored.color = Color.blue;
        ScoreTextGate1.text = $"Blue team: {PointsGate1} goals";
        ScoreTextGate1.color = Color.blue;
        IntTimer = 5f;
        Player1.SetActive(false);
        Player2.SetActive(false);
    }
    private void Goal2()
    {
        PointsGate2 = PointsGate2 + 1;
        GoalScored.text = "Red team scored a goal";
        GoalScored.color = Color.red;
        ScoreTextGate2.text = $"Red team: {PointsGate2} goals";
        ScoreTextGate2.color = Color.red;
        IntTimer = 5f;
        Player2.SetActive(false);
        Player1.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        #region Moving the timer && spawning supplies
        bool DoWENeedCountDown;
        if(Time.timeSinceLevelLoad/CountDownSpeed<=4.5)
            CountDown(-Time.timeSinceLevelLoad / CountDownSpeed + 4);
        if (IntTimer > 3) DoWENeedCountDown = false;
        else DoWENeedCountDown = true;
        switch (DoWENeedCountDown && !string.IsNullOrEmpty(GoalScored.text))
        {
            case false:
                CountDown(IntTimer);
                IntTimer -= Time.deltaTime;
                break;
            case true:
                Timer.Start();
                Respawn();
                break;
        }
        if (SupplyHasntSpawn)
        {
            SpawnSupply();
            SupplyHasntSpawn = false;
        }
        #endregion
    }

    private void CountDown(float timer)
    {
        timer = Mathf.CeilToInt(timer);
        if (timer <= 3&& timer >= 0)
            TextTimer.text = $"{timer:0}";
        if (timer <= 0)
        {
            TextTimer.text = "";
        }
    }//si pt dipa gol 

    private void Respawn()
    {
        GoalScored.text = "";
        Player1.SetActive(true);
        Player2.SetActive(true);
        Player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.transform.position = new Vector3(486f, 2f, 385f);
        Player1.transform.position = new Vector3(486f, 2f, 380f);
        Player2.transform.position = new Vector3(481f, 2f, 375f);
    }
    private void SpawnSupply()
    {
        GameObject a = Instantiate(supplyPrefab) as GameObject;
        a.name = $"Supply {supplyNumber}";
        supplyNumber++;
        a.transform.position = new Vector3(Random.Range(10, 990), 2f, Random.Range(10, 990));
    }
}
