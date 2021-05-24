using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Rigidbody Ball;
    public GameObject Cube;
    public int Points;
    public Text ScoreText;
    public Time timeFromScore;
    public Text GoalScored;
    float timer = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        Points = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Plane" || collision.collider.name == "Plane2")
        {
            Goal();
        }
    }

    private void Goal()
    {
        Points = Points + 1;
        GoalScored.text = "A goal was scored";
        ScoreText.text = $"{Points}";
        timer = 5f;
        Cube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool timerdone;
        if (timer > 0) timerdone = false;
        else timerdone = true;
        switch (timerdone&& !string.IsNullOrEmpty(GoalScored.text))
        {
            case false:
                timer -= Time.deltaTime;
                break;
            case true:
                Respawn();
                break;
        }
    }

    private void Respawn()
    {
        GoalScored.text = "";
        Cube.SetActive(true);
        Cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.transform.position = new Vector3(500f, 2f, 400f);
        Cube.transform.position = new Vector3(480f, 2f, 380f);
    }
}
