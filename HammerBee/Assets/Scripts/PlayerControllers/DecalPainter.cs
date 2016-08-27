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
            Instantiate(decalObject, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            print(hit.normal);
            print(hit.normal * Mathf.Rad2Deg);
            //print(new Vector3(RoundBetween(hit.normal.x * Mathf.Rad2Deg, hit.normal.x * Mathf.Rad2Deg % 90f, (hit.normal.x * Mathf.Rad2Deg % 90f) + 90f), RoundBetween(hit.normal.y * Mathf.Rad2Deg, hit.normal.y * Mathf.Rad2Deg % 90f, (hit.normal.y * Mathf.Rad2Deg % 90f) + 90f), RoundBetween(hit.normal.z * Mathf.Rad2Deg, hit.normal.z * Mathf.Rad2Deg % 90f, (hit.normal.z * Mathf.Rad2Deg % 90f) + 90f)));
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
