using UnityEngine;
using System.Collections;

public class BasePlayerController : MonoBehaviour
{
    #region Variables
    [Header("LookVariables")]
    public float VerticalLookSpeed = 10;
    public float HorizontalLookSpeed = 10;
    public float maxVertLookAngle = 85;
    public float minVertLookAngle = 5;
    [Header("MovementVariables")]
    public float ForwardMovementSpeed = 10;
    [Header("Can Input")]
    public bool takeCameraInput = true;
    public bool takeMovementInput = true;

    private Camera playerView;
    private Rigidbody playerRigidBody;
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
    #endregion

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (takeCameraInput)
        {
            VerticalLook(-Input.GetAxis("Mouse Y"));
            HorizontalLook(Input.GetAxis("Mouse X"));
        }
        if (takeMovementInput)
        {
            ForwardMovement(Input.GetAxis("ForwardMovement"));
        }
    }

    #region CameraInput
    void VerticalLook(float _lookAxis)
    {
        playerView.transform.Rotate(_lookAxis * VerticalLookSpeed, 0, 0);
        playerView.transform.rotation = Quaternion.Euler(Mathf.Clamp(playerView.transform.rotation.eulerAngles.x, minVertLookAngle, maxVertLookAngle), 0, 0);
    }

    void HorizontalLook(float _lookAxis)
    {
        transform.Rotate(0, _lookAxis * HorizontalLookSpeed, 0);
    }
    #endregion

    #region Movement

    void ForwardMovement(float _forwardSpeed)
    {
        transform.Translate(((transform.forward * _forwardSpeed) * ForwardMovementSpeed), Space.World);
    }

    #endregion
}
