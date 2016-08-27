using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour
{

    public GameObject normal;
    public GameObject destroyed;

    public void Break()
    {
        Debug.Log("Blah");
        normal.SetActive(false);
        destroyed.SetActive(true);
        //StartCoroutine("DestroySelf");
    }


    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
