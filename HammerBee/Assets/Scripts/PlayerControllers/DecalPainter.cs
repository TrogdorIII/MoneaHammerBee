using UnityEngine;
using System.Collections;
using ExtensionMethods;
using XboxCtrlrInput;
using XInputDotNetPure;

public class DecalPainter : MonoBehaviour
{
    public GameObject decalObject;
    public float destroyTime;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || XCI.GetButtonDown(XboxButton.RightBumper, 1))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.forward * 0.5f, transform.forward, out hit, 1.5f))
            {
                GameObject decalInstance = (GameObject)Instantiate(decalObject, hit.point + (hit.normal * 0.01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
                decalInstance.transform.SetParent(hit.collider.gameObject.transform);
                Destroy(decalInstance, destroyTime);
            }
            Debug.Log(hit.collider.name);
            if (hit.collider.GetComponent<BeePlayerController>() != null)
            {
                hit.collider.GetComponent<BeePlayerController>().OnHit();
            }

        }

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }

    public float RoundBetween(float f, float min, float max)
    {
        return (f >= min + ((max - min) / 2)) ? max : min;
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(transform.position + transform.forward * 0.5f, transform.position + transform.forward * 1.5f);
    //}
}
