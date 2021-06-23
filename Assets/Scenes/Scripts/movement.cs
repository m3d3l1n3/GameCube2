using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    #region Declarations
    public Rigidbody cube;
    public Camera camera;
    public Transform target;
    public static float moveSpeed = 40f;
    public float jumpHeight = 2f;
    public bool IsOnGround;
    public int NumberJumps;
    public Vector3 offset;
    public float cameraSpeed = 0.75f;
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
                cube.AddForce(Vector3.up * jumpHeight);
                NumberJumps += 1;
            }
        }
        PlayerMovementV2();
        #region CameraMovement
        Vector3 DesieredPosition = target.position + offset;
        Vector3 SmoothPosition = Vector3.Lerp(camera.transform.position, DesieredPosition, (cameraSpeed * Time.deltaTime));
        camera.transform.position = SmoothPosition;
        camera.transform.LookAt(target);
        #endregion
    }

    private void PlayerMovementV2()
    {
        var typeOfForce = ForceMode.Impulse;
        var forceAplied = moveSpeed * Time.deltaTime * cube.mass;
        if (Input.GetKey(KeyCode.A))
            cube.AddRelativeForce(new Vector3(-forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(KeyCode.W))
            cube.AddRelativeForce(new Vector3(0f, 0f, forceAplied), typeOfForce);
        //cube.AddRelativeForce(Vector3.forward*forceAplied);
        if (Input.GetKey(KeyCode.D))
            cube.AddRelativeForce(new Vector3(forceAplied, 0f, 0f), typeOfForce);
        if (Input.GetKey(KeyCode.S))
            cube.AddRelativeForce(new Vector3(0f, 0f, -forceAplied), typeOfForce);
        if (Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            cube.AddRelativeForce(0, forceAplied*10, 0,typeOfForce);
            IsOnGround = false;
        }
        if (Input.GetKey(KeyCode.E))
            cube.transform.Rotate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.Q))
            cube.transform.Rotate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.C))
            cube.transform.eulerAngles = new Vector3();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
            cube.transform.position += Time.deltaTime * moveSpeed * -transform.right;
        if (Input.GetKey(KeyCode.D))
            cube.transform.position += Time.deltaTime * moveSpeed * transform.right;
        if (Input.GetKey(KeyCode.W))
            cube.transform.position += Time.deltaTime * moveSpeed * transform.forward;
        if (Input.GetKey(KeyCode.S))
            cube.transform.position += Time.deltaTime * moveSpeed * -transform.forward;
        if (Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            cube.AddForce(0, 50f, 0, ForceMode.Impulse);
            IsOnGround = false;
        }

        if (Input.GetKey(KeyCode.E))
            cube.transform.Rotate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.Q))
            cube.transform.Rotate(new Vector3(0f, -moveSpeed * Time.deltaTime, 0f));
        var initialRotation = cube.rotation;
        if (Input.GetKey(KeyCode.R))
        {
            cube.transform.Rotate(new Vector3(0f, 0f, moveSpeed * Time.deltaTime));
            var finalRotation = cube.rotation;
            var diferenceRotation = finalRotation.eulerAngles.z - initialRotation.eulerAngles.z;
            camera.transform.Rotate(new Vector3(0f, 0f, diferenceRotation));
        }
    }
}
