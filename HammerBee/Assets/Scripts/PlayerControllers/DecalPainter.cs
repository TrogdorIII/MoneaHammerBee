using UnityEngine;
using System.Collections;

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
            Instantiate(decalObject, hit.point, Quaternion.Euler(50 * hit.normal));
            print(hit.normal);
            print(hit.normal * 50);
        }
        
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + transform.forward * 0.5f, transform.forward * 100f);
    }
}
