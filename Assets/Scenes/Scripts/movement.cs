using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    #region Declarations
    public Rigidbody Player1;
    public Rigidbody Player2;
    public Camera camera1;
    public Camera camera2;
    public Transform target1;
    public Transform target2;
    public static float moveSpeed = 30f;
    public float jumpHeight = 2f;
    public bool IsOnGround;
    public int NumberJumps;
    public Vector3 offset;
    public float cameraSpeed = 0.8f;
    public bool HasCollided;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
    }
    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        IsOnGround = true;
        NumberJumps = 0;
    }

    void FixedUpdate()
    {
        if (NumberJumps > 1)
        {
            IsOnGround = false;
        }

        if (IsOnGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Player1.AddForce(Vector3.up * jumpHeight);
                NumberJumps += 1;
            }
        }
        PlayerMovementV2();

        Player2Movement();
    }
    private void LateUpdate()
    {
        #region Camera Movement
        Vector3 DesieredPosition = target1.position + offset;
        Vector3 SmoothPosition = Vector3.Lerp(camera1.transform.position, DesieredPosition, (cameraSpeed * Time.deltaTime));
        camera1.transform.position = SmoothPosition;
        camera1.transform.LookAt(target1);
        #endregion

        #region Camera Movement
        Vector3 DesieredPosition2 = target2.position + offset;
        Vector3 SmoothPosition2 = Vector3.Lerp(camera2.transform.position, DesieredPosition2, (cameraSpeed * Time.deltaTime));
        camera2.transform.position = SmoothPosition2;
        camera2.transform.LookAt(target2);
        #endregion
    }

    private void PlayerMovementV2()
    {
        var typeOfForce = ForceMode.Impulse;
        var forceAplied = moveSpeed * Time.deltaTime * Player1.mass;
        if (Input.GetKey(KeyCode.A))
            Player1.AddRelativeForce(new Vector3(-forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(KeyCode.W))
            Player1.AddRelativeForce(new Vector3(0f, 0f, forceAplied), typeOfForce);
        //cube.AddRelativeForce(Vector3.forward*forceAplied);
        if (Input.GetKey(KeyCode.D))
            Player1.AddRelativeForce(new Vector3(forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(KeyCode.S))
            Player1.AddRelativeForce(new Vector3(0f, 0f, -forceAplied), typeOfForce);
        if (Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            Player1.AddRelativeForce(0, forceAplied*10, 0,typeOfForce);
            IsOnGround = false;
        }
        if (Input.GetKey(KeyCode.E))
            Player1.transform.Rotate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.Q))
            Player1.transform.Rotate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.C))
            Player1.transform.eulerAngles = new Vector3();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
            Player1.transform.position += Time.deltaTime * moveSpeed * -transform.right;
        if (Input.GetKey(KeyCode.D))
            Player1.transform.position += Time.deltaTime * moveSpeed * transform.right;
        if (Input.GetKey(KeyCode.W))
            Player1.transform.position += Time.deltaTime * moveSpeed * transform.forward;
        if (Input.GetKey(KeyCode.S))
            Player1.transform.position += Time.deltaTime * moveSpeed * -transform.forward;
        if (Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            Player1.AddForce(0, 50f, 0, ForceMode.Impulse);
            IsOnGround = false;
        }

        if (Input.GetKey(KeyCode.E))
            Player1.transform.Rotate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.Q))
            Player1.transform.Rotate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
        var initialRotation = Player1.rotation;
        if (Input.GetKey(KeyCode.R))
        {
            Player1.transform.Rotate(new Vector3(0f, 0f, moveSpeed * Time.deltaTime));
            var finalRotation = Player1.rotation;
            var diferenceRotation = finalRotation.eulerAngles.z - initialRotation.eulerAngles.z;
            camera1.transform.Rotate(new Vector3(0f, 0f, diferenceRotation));
        }
    }

    private void Player2Movement()
    {
        var typeOfForce = ForceMode.Impulse;
        var forceAplied = moveSpeed * Time.deltaTime * Player2.mass;
        if (Input.GetKey(KeyCode.Keypad4))
            Player2.AddRelativeForce(new Vector3(-forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(KeyCode.Keypad8))
            Player2.AddRelativeForce(new Vector3(0f, 0f, forceAplied), typeOfForce);
        //cube.AddRelativeForce(Vector3.forward*forceAplied);
        if (Input.GetKey(KeyCode.Keypad6))
            Player2.AddRelativeForce(new Vector3(forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(KeyCode.Keypad5))
            Player2.AddRelativeForce(new Vector3(0f, 0f, -forceAplied), typeOfForce);
        if (Input.GetKey(KeyCode.Keypad0) && IsOnGround)
        {
            Player2.AddRelativeForce(0, forceAplied * 10, 0, typeOfForce);
            IsOnGround = false;
        }
        if (Input.GetKey(KeyCode.Keypad7))
            Player2.transform.Rotate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.Keypad9))
            Player2.transform.Rotate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.Keypad2))
            Player2.transform.eulerAngles = new Vector3();
    }
}
