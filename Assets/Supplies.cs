using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Supplies : MonoBehaviour
{
    public Rigidbody Ball;
    public Text Storage;
    public Timer supplyTime;
    int numberSupply = 0;
    public Text RunTimeSupp;
    public System.Diagnostics.Stopwatch WarningPlayerSupply;
    public System.Diagnostics.Stopwatch StopSuppply;
    int MaxSupplies = 3;
    int NumberSupplyInUse = 0;
    // Start is called before the first frame update
    void Start()
    {
        StopSuppply = new System.Diagnostics.Stopwatch();
        supplyTime = new Timer(10000);
        supplyTime.AutoReset = false;
        supplyTime.Elapsed += SupplyTime_Elapsed;
        WarningPlayerSupply = new System.Diagnostics.Stopwatch();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("Collision");
            Ball.AddForce(0f, 100f, 0f);
        }
        if (collision.gameObject.tag == "Supply")
        {
            if(numberSupply>=MaxSupplies)
            {
                Storage.text = "You have reached the maximum capacity";
                WarningPlayerSupply.Start();
            }
            else
            {
                numberSupply++;
                Storage.text = $"You have absorbed {numberSupply} supplies";
                //collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }

        }
    }

    public void UsingSupply()
    {
        supplyTime.Start();
        StopSuppply.Start();
        movement.moveSpeed=movement.moveSpeed+40f;
        NumberSupplyInUse++;
        Debug.Log($"Movement speed with supply: {movement.moveSpeed}");
        numberSupply--;
        Storage.text = $"You have absorbed {numberSupply} supplies";
    }

    private void SupplyTime_Elapsed(object sender, ElapsedEventArgs e)
    {
        movement.moveSpeed = 50f;
        StopSuppply.Stop();
        NumberSupplyInUse--;
        Debug.Log($"Number supply in use: {NumberSupplyInUse}");
        Debug.Log($"Movement speed with supply: {movement.moveSpeed}");
    }

    // Update is called once per frame
    void Update()
    {
        if (numberSupply != 0 && Input.GetKeyDown("1")&&NumberSupplyInUse<2)
            UsingSupply();
        if (StopSuppply.IsRunning)
            RunTimeSupp.text = $"{10 - StopSuppply.ElapsedMilliseconds / 1000}";
        else RunTimeSupp.text = "";
        if (WarningPlayerSupply.ElapsedMilliseconds / 1000 == 5) Storage.text = "";
        if(movement.moveSpeed>=50) Debug.Log($"Movement speed with supply: {movement.moveSpeed}");
    }
}
