using UnityEngine;
using System.Collections;
using ExtensionMethods;

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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.forward * 0.5f, transform.forward, out hit, 2f))
            {
                GameObject decalInstance = (GameObject)Instantiate(decalObject, hit.point + (hit.normal * 0.01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
                decalInstance.transform.SetParent(hit.collider.gameObject.transform);
                Destroy(decalInstance, destroyTime);
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
    //    Gizmos.DrawLine(transform.position + transform.forward * 0.5f, transform.position + transform.forward * 2f);
    //}
}
