using UnityEngine;
using System.Collections;

public class BeePlayerController : MonoBehaviour
{
    #region Variables
    [Header("LookVariables")]
    public float VerticalLookSpeed = 10;
    public float HorizontalLookSpeed = 10;
    public float maxVertLookAngle = 85;
    public float minVertLookAngle = 5;
    [Header("MovementVariables")]
    public float forwardAcceleration = 5;
    public float turnAcceleration = 5;
    public float pitchAcceleration = 5;
    public float minForwardSpeed = 5;
    public float maxForwardSpeed = 50;
    public float minTurnAngle = -45;
    public float maxTurnAngle = 45;
    public float minPitchAngle = -45;
    public float maxPitchAngle = 45;
    [Header("Can Input")]
    public bool takeCameraInput = true;
    public bool takeMovementInput = true;
    [Header("Debug")]
    public float currentMovementSpeed;
    public float currentTurnSpeed;
    public float currentPitchSpeed;

    private Camera playerView;
    private Rigidbody playerRigidBody;
    private CapsuleCollider playerCollider;

    private Vector3 zVelocity;
    private Vector3 moveDir = Vector3.zero;
    #endregion

    // Use this for initialization
    void Start()
    {
        InitializeVariables();
    }

    void InitializeVariables()
    {
        GetCameraVar();
        GetRigidBody();
        GetPlayerCollider();
    }

    #region GetVars

    void GetCameraVar()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Camera>())
            {
                playerView = transform.GetChild(i).GetComponent<Camera>();
                break;
            }
        }
        if (playerView == null)
        {
            Debug.LogError("Cannot Initialize camera variable");
        }
    }

    void GetRigidBody()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void GetPlayerCollider()
    {
        playerCollider = GetComponent<CapsuleCollider>();
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        CameraInput();
        PitchBee(Input.GetAxis("PitchMovement"));
        RotateBee(Input.GetAxis("RightMovement"));
    }

    void CameraInput()
    {
        //VerticalLook(-Input.GetAxis("Mouse Y"));
        //HorizontalLook(currentTurnSpeed);
    }

    void VerticalLook(float _lookAxis)
    {
        playerView.transform.Rotate(_lookAxis * VerticalLookSpeed, 0, 0);
    }

    void HorizontalLook(float _lookAxis)
    {
        //playerView.transform.localEulerAngles = new Vector3(playerView.transform.localEulerAngles.x, playerView.transform.localEulerAngles.y, _lookAxis);
        //playerView.transform.localEulerAngles = Vector3.SmoothDamp(playerView.transform.localEulerAngles, new Vector3(playerView.transform.localEulerAngles.x, playerView.transform.localEulerAngles.y, _lookAxis), ref zVelocity, 1f);
    }

    void FixedUpdate()
    {
        ForwardMovement(Input.GetAxis("ForwardMovement"));
    }

    void ForwardMovement(float forwardInput = 0)
    {
        currentMovementSpeed += forwardInput * forwardAcceleration;
        currentMovementSpeed = Mathf.Clamp(currentMovementSpeed, minForwardSpeed, maxForwardSpeed);
        Vector3 CalculatedMovement = Vector3.zero;
        CalculatedMovement = (-transform.forward * (currentMovementSpeed * Time.deltaTime));
        playerRigidBody.velocity = CalculatedMovement;
    }

    void RotateBee(float horizontalInput = 0)
    {
        currentTurnSpeed = horizontalInput * turnAcceleration;
        currentTurnSpeed = Mathf.Clamp(currentTurnSpeed, minTurnAngle, maxTurnAngle);
        transform.eulerAngles += (Vector3.up * currentTurnSpeed);
    }

    void PitchBee(float pitchInput = 0)
    {
        currentPitchSpeed = pitchInput * pitchAcceleration;
        currentPitchSpeed = Mathf.Clamp(currentPitchSpeed, minPitchAngle, maxPitchAngle);
        transform.eulerAngles += (-Vector3.right * currentPitchSpeed);
    }

    #region Utility
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    #endregion
}
