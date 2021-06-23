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
    public GameObject Cube;
    public int Points1;
    public int Points2;
    public Text ScoreText;
    public Text ScoreText2;
    public Time timeFromScore;
    public Text GoalScored;
    public Text Timer;
    float timer = 1000f;
    public Timer Tseconds;
    float CountDownSpeed = 1.5f;
    public GameObject supplyPrefab;
    private static bool spawnSupply = false;
    int supplyNumber = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        GoalScored.text = "";
        Points1 = 0;
        Points2 = 0;
        Tseconds = new Timer(2000);
        Tseconds.AutoReset = false;
        Tseconds.Elapsed += Tseconds_Elapsed;
        Tseconds.Start();
        SpawnSupply();
        SpawnSupply();
        SpawnSupply();
    }

    private void Tseconds_Elapsed(object sender, ElapsedEventArgs e)
    {
        //Debug.Log("Timer elapsed");
        spawnSupply = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Plane")
            Goal();
        if (collision.collider.name == "Plane2")
            Goal2();
    }

    private void Goal()
    {
        Points1 = Points1 + 1;
        GoalScored.text = "Blue team scored a goal";
        GoalScored.color = Color.blue;
        ScoreText.text = $"Blue team: {Points1} goals";
        ScoreText.color = Color.blue;
        timer = 5f;
        Cube.SetActive(false);
    }
    private void Goal2()
    {
        Points2 = Points2 + 1;
        GoalScored.text = "Red team scored a goal";
        GoalScored.color = Color.red;
        ScoreText2.text = $"Red team: {Points2} goals";
        ScoreText2.color = Color.red;
        timer = 5f;
        Cube.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        #region Moving the timer && spawning supplies
        bool DoWENeedCountDown;
        if(Time.realtimeSinceStartup/CountDownSpeed<=4.5)
            CountDown(-Time.realtimeSinceStartup / CountDownSpeed + 4);
        if (timer > 3) DoWENeedCountDown = false;
        else DoWENeedCountDown = true;
        switch (DoWENeedCountDown && !string.IsNullOrEmpty(GoalScored.text))
        {
            case false:
                CountDown(timer);
                timer -= Time.deltaTime;
                break;
            case true:
                Tseconds.Start();
                Respawn();
                break;
        }
        if (spawnSupply)
        {
            SpawnSupply();
            spawnSupply = false;
        }
        #endregion
    }

    private void CountDown(float timer)
    {
        timer = Mathf.CeilToInt(timer);
        if (timer <= 3&& timer >= 0)
            //contor = Time.time;
            Timer.text = $"{timer:0}";
        if (timer <= 0)
        {
            Timer.text = "";
            //SpawnSupply();
        }
    }//si pt dipa gol 

    private void Respawn()
    {
        GoalScored.text = "";
        Cube.SetActive(true);
        Cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.transform.position = new Vector3(486f, 2f, 385f);
        Cube.transform.position = new Vector3(486f, 2f, 380f);
    }
    private void SpawnSupply()
    {
        GameObject a = Instantiate(supplyPrefab) as GameObject;
        a.name = $"Supply {supplyNumber}";
        supplyNumber++;
        a.transform.position = new Vector3(Random.Range(10, 990), 2f, Random.Range(10, 990));
    }
}
