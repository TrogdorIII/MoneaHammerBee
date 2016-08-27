using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour
{

    public GameObject normal;
    public GameObject destroyed;
    private Collider[] SelfCollider;

    public void Break()
    {
        SelfCollider = GetComponents<Collider>();
        foreach (var item in SelfCollider)
        {
            item.enabled = false;
        }
        normal.SetActive(false);
        destroyed.SetActive(true);
        StartCoroutine("DestroySelf");
    }


    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
