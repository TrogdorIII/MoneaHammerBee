using UnityEngine;
using System.Collections;
using XboxCtrlrInput;
using XInputDotNetPure;

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
    [Header("BeeStats")]
    public float beeLives = 3;
    public float invincibleTime = 3;
    [Header("Debug")]
    public float currentMovementSpeed;
    public float currentTurnSpeed;
    public float currentPitchSpeed;

    private Camera playerView;
    private Rigidbody playerRigidBody;
    private CapsuleCollider playerCollider;

    private Vector3 zVelocity;
    private Vector3 moveDir = Vector3.zero;
    private bool canBeHit;
    #endregion

    #region Init
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
    #endregion

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

    #region Update Things
    // Update is called once per frame
    void Update()
    {
        PitchBee(XCI.GetAxis(XboxAxis.RightStickY, 2));
        RotateBee(XCI.GetAxis(XboxAxis.RightStickX, 2));

        if (beeLives <= 0)
        {
            //SEND BEE DEATH METHOD HERE
        }
    }

    void FixedUpdate()
    {
        ForwardMovement(XCI.GetAxis(XboxAxis.LeftStickY, 2));
    }

    #endregion

    #region Movement
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

    #endregion

    #region TakeDamage
    public void OnHit()
    {
        if (canBeHit)
        {
            beeLives -= 1;
            canBeHit = false;
            StartCoroutine("InvincibilityCooldown");
        }
    }
    #endregion

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

    IEnumerator InvincibilityCooldown()
    {
        yield return new WaitForSeconds(invincibleTime);
        canBeHit = true;
        yield break;
    }
}
