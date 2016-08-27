using UnityEngine;
using System.Collections;
using Game;

public class Destructable : MonoBehaviour
{

    public GameObject normal;
    public GameObject destroyed;
    private Collider[] SelfCollider;

    public void Break()
    {
        GameManager.instance.currentScore += GameManager.instance.destructable_scoreToAdd;

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
