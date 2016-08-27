using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeeSmacking : MonoBehaviour
{

    private GameObject ItemsInTrigger;
    public float RayDistance;
    public Image Reticleimage;
    private int rayLayerMask;

    void Awake()
    {
        rayLayerMask = 1 << 8;
        rayLayerMask = ~rayLayerMask;
        StartCoroutine("ReticleChanger");
    }

    void Update()
    {
        if (Input.GetButtonDown("HitBee"))
        {
            RaycastHit RaycastReceive = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0)), (Camera.main.transform.forward), out RaycastReceive, RayDistance, rayLayerMask))
            {
                Debug.Log(RaycastReceive.collider.name);
                if (RaycastReceive.collider.GetComponent<BeePlayerController>() != null)
                {
                    RaycastReceive.collider.GetComponent<BeePlayerController>().OnHit();
                }
                if (RaycastReceive.collider.GetComponent<Destructable>() != null)
                {
                    RaycastReceive.collider.GetComponent<Destructable>().Break();
                }
            }
            else
            {
                Debug.Log("Miss");
            }
        }
    }

    IEnumerator ReticleChanger()
    {
        while (true)
        {
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0)), (Camera.main.transform.forward), RayDistance, rayLayerMask))
            {
                Reticleimage.color = Color.green;
            }
            else
            {
                Reticleimage.color = Color.red;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
