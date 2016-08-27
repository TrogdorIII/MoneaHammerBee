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
    public float playerMoveSpeed = 1;
    [Header("Can Input")]
    public bool takeCameraInput = true;
    public bool takeMovementInput = true;

    private Camera playerView;
    private Rigidbody playerRigidBody;
    private CapsuleCollider playerCollider;

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
    }

    void CameraInput()
    {
        VerticalLook(-Input.GetAxis("Mouse Y"));
        HorizontalLook(Input.GetAxis("Mouse X"));
    }

    void VerticalLook(float _lookAxis)
    {
        playerView.transform.Rotate(_lookAxis * VerticalLookSpeed, 0, 0);
    }

    void HorizontalLook(float _lookAxis)
    {
        transform.Rotate(0, _lookAxis * HorizontalLookSpeed, 0);
    }

    void FixedUpdate()
    {
        ForwardMovement(Input.GetAxis("MoveForward"));
    }

    void ForwardMovement(float Moveplace)
    {
        playerRigidBody.velocity = (transform.forward * Moveplace) * playerMoveSpeed;
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
