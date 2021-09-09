using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Declarations
    public Rigidbody Player;
    public Transform Target;
    public Camera Camera;
    public Vector3 CameraOffset;
    private float movementSpeed = 30f;
    private float cameraSpeed = 0.5f;
    private Dictionary<PlayerActions, KeyCode> actionMapping;
    public int MovementControlOption;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        GameState.HasGameEnded = false;
        SetMapping(MovementControlOption);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();

        #region Camera Movement
        Vector3 DesieredPosition = Target.position + CameraOffset;
        Vector3 SmoothPosition = Vector3.Lerp(Camera.transform.position, DesieredPosition, (cameraSpeed * Time.deltaTime));
        Camera.transform.position = SmoothPosition;
        Camera.transform.LookAt(Target);
        #endregion
    }
    private void SetMapping(int option)
    {
        if (option == 1)
        {
            actionMapping = new Dictionary<PlayerActions, KeyCode>()
            {
                {PlayerActions.Forward, KeyCode.W},
                {PlayerActions.Left, KeyCode.A},
                {PlayerActions.Right, KeyCode.D},
                {PlayerActions.Back, KeyCode.S},
                {PlayerActions.TurnLeft, KeyCode.Q},
                {PlayerActions.TurnRight, KeyCode.E},
                {PlayerActions.Jump, KeyCode.Space},
                {PlayerActions.Reset, KeyCode.C}
            };
        }
        if (option == 2)
        {
            actionMapping = new Dictionary<PlayerActions, KeyCode>()
            {
                {PlayerActions.Forward, KeyCode.Keypad8},
                {PlayerActions.Left, KeyCode.Keypad4},
                {PlayerActions.Right, KeyCode.Keypad6},
                {PlayerActions.Back, KeyCode.Keypad5},
                {PlayerActions.TurnLeft, KeyCode.Keypad7},
                {PlayerActions.TurnRight, KeyCode.Keypad9},
                {PlayerActions.Jump, KeyCode.Keypad0},
                {PlayerActions.Reset, KeyCode.Keypad2}
            };
        }
    }
    public enum PlayerActions
    {
        NoAction,
        Forward, 
        Left,
        Right,
        Back,
        TurnLeft,
        TurnRight,
        Jump,
        Reset
    }
    private void Movement()
    {
        var typeOfForce = ForceMode.Impulse;
        var forceAplied = movementSpeed * Time.deltaTime * Player.mass;
        if (Input.GetKey(actionMapping[PlayerActions.Left]))
            Player.AddRelativeForce(new Vector3(-forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(actionMapping[PlayerActions.Forward]))
            Player.AddRelativeForce(new Vector3(0f, 0f, forceAplied), typeOfForce);
        //cube.AddRelativeForce(Vector3.forward*forceAplied);
        if (Input.GetKey(actionMapping[PlayerActions.Right]))
            Player.AddRelativeForce(new Vector3(forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(actionMapping[PlayerActions.Back]))
            Player.AddRelativeForce(new Vector3(0f, 0f, -forceAplied), typeOfForce);
        if (Input.GetKey(actionMapping[PlayerActions.Jump]) && Player.position.y <= 1.2)
        {
            Player.AddRelativeForce(0, forceAplied, 0, typeOfForce);
        }
        if (Input.GetKey(actionMapping[PlayerActions.TurnRight]))
            Player.transform.Rotate(new Vector3(0f, movementSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(actionMapping[PlayerActions.TurnLeft]))
            Player.transform.Rotate(new Vector3(0f, -movementSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(actionMapping[PlayerActions.Reset]))
            Player.transform.eulerAngles = new Vector3();
    }
}
