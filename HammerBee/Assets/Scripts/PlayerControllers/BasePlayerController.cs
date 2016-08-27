using UnityEngine;
using System.Collections;

public class BasePlayerController : MonoBehaviour
{
    #region Variables
    [Header("LookVariables")]
    public float VerticalLookSpeed = 10;
    public float HorizontalLookSpeed = 10;
    public float maxVertLookAngle = 10;
    public float minVertLookAngle = 170;
    [Header("MovementVariables")]
    public float playerMoveSpeed = 1;
    [Header("Can Input")]
    public bool takeCameraInput = true;
    public bool takeMovementInput = true;

    public GameObject playerView;
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
                //playerView = transform.GetChild(i).GetComponent<Camera>();
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
        PlayerInput();
    }

    void FixedUpdate()
    {
        if (takeMovementInput)
        {
            AllMovement(new Vector2(Input.GetAxis("ForwardMovement"), Input.GetAxis("RightMovement")));
        }
    }

    void PlayerInput()
    {
        if (takeCameraInput)
        {
            VerticalLook(-Input.GetAxis("Mouse Y"));
            HorizontalLook(Input.GetAxis("Mouse X"));
        }
    }

    #region CameraInput
    void VerticalLook(float _lookAxis)
    {
        Vector3 rotation = playerView.transform.localRotation.eulerAngles;
        rotation.x += (_lookAxis * VerticalLookSpeed);
        ///rotation.x = Mathf.Clamp(rotation.x, -80, 80);
        playerView.transform.localRotation = Quaternion.Euler(rotation);
    }

    void HorizontalLook(float _lookAxis)
    {
        transform.Rotate(0, _lookAxis * HorizontalLookSpeed, 0);
    }
    #endregion

    #region Movement

    void AllMovement(Vector2 _forwardSpeed)
    {
        Vector3 desiredMove = transform.forward * _forwardSpeed.x + transform.right * _forwardSpeed.y;
        RaycastHit hitInfo;
        Physics.SphereCast(transform.position, playerCollider.radius, Vector3.down, out hitInfo,
                           playerCollider.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;
        moveDir.x = desiredMove.x * playerMoveSpeed;
        moveDir.z = desiredMove.z * playerMoveSpeed;

        playerRigidBody.velocity = (moveDir);
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
}
