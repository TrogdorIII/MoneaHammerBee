using UnityEngine;
using System.Collections;
using ExtensionMethods;

public class DecalPainter : MonoBehaviour
{
    public GameObject decalObject;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + transform.forward * 0.5f, transform.forward, out hit, 100f);
            Instantiate(decalObject, hit.point + (hit.normal * 0.01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
        }
        
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }

    public float RoundBetween(float f, float min, float max)
    {
        return (f >= min + ((max - min) / 2)) ? max : min;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + transform.forward * 0.5f, transform.forward * 100f);
    }
}
