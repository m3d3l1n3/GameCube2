using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    #region Declarations
    public Rigidbody Player;
    public System.Diagnostics.Stopwatch coolDown1;
    public System.Diagnostics.Stopwatch abilityDuration1;
    public System.Diagnostics.Stopwatch coolDown2;
    public System.Diagnostics.Stopwatch abilityDuration2;
    float acceleration = 25f;
    long coolDownPeriod = 60000;
    float MassSpeedProportion = 2f;
    #endregion 
    // Start is called before the first frame update
    void Start()
    {
        coolDown1 = new System.Diagnostics.Stopwatch();
        abilityDuration1 = new System.Diagnostics.Stopwatch();
        coolDown2 = new System.Diagnostics.Stopwatch();
        abilityDuration2 = new System.Diagnostics.Stopwatch();
    }

    void AbilityCall1()
    {
        abilityDuration1.Reset();
        abilityDuration1.Start();
        movement.moveSpeed += acceleration;
    }
    void AbilityCall2()
    {
        abilityDuration2.Reset();
        abilityDuration2.Start();
        Player.mass *= MassSpeedProportion;
        movement.moveSpeed *= MassSpeedProportion;
    }
    //Update is called once per frame
    void Update()
    {
        #region Ability1
        if (abilityDuration1.ElapsedMilliseconds > 21000 && abilityDuration1.IsRunning)
        {
            abilityDuration1.Stop();
            coolDown1.Reset();
            coolDown1.Start();
            movement.moveSpeed -= acceleration;
        }

        if (coolDown1.ElapsedMilliseconds > coolDownPeriod && coolDown1.IsRunning)
            coolDown1.Stop();

        if (abilityDuration1.IsRunning == false && coolDown1.IsRunning == false)
            if (Input.GetKeyDown(KeyCode.F)||Input.GetKeyDown(KeyCode.Keypad1))
                AbilityCall1();
        #endregion

        #region Ability2
        if (abilityDuration2.ElapsedMilliseconds > 10000 && abilityDuration2.IsRunning)
        {
            abilityDuration2.Stop();
            coolDown2.Reset();
            coolDown2.Start();
            Player.mass /= MassSpeedProportion;
            movement.moveSpeed /= MassSpeedProportion;
        }

        if (coolDown2.ElapsedMilliseconds > coolDownPeriod / 2 && coolDown2.IsRunning)
            coolDown2.Stop();

        if (abilityDuration2.IsRunning == false && coolDown2.IsRunning == false)
            if (Input.GetKeyDown(KeyCode.G)||Input.GetKeyDown(KeyCode.Keypad3))
                AbilityCall2();
        #endregion
    }
}
