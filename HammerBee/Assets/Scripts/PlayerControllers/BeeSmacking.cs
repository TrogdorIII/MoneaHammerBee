using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using XboxCtrlrInput;
using XInputDotNetPure;

public class BeeSmacking : MonoBehaviour
{

    private GameObject ItemsInTrigger;
    public float RayDistance;
    public Image Reticleimage;
    public Animator playerAnimator;
    private int rayLayerMask;
    public AudioClip[] sounds;
    public AudioSource source;

    void Awake()
    {
        Reticleimage = GameObject.Find("PlayerReticle").transform.GetChild(0).GetComponent<Image>();
        //Stuff
        rayLayerMask = 1 << 31;
        rayLayerMask = ~rayLayerMask;
        StartCoroutine("ReticleChanger");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || XCI.GetButtonDown(XboxButton.RightBumper))
        {
            playerAnimator.ResetTrigger("Hammer");
            playerAnimator.SetTrigger("Hammer");
            source.PlayOneShot(sounds[0]);
            RaycastHit RaycastReceive = new RaycastHit();
            //transform.position + transform.forward * 0.5f, transform.forward
            //if (Physics.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0)), (Camera.main.transform.forward), out RaycastReceive, RayDistance, rayLayerMask))
            if (Physics.Raycast(transform.position + transform.forward * 0.5f, transform.forward, out RaycastReceive, RayDistance, rayLayerMask))
            {
                Debug.Log(RaycastReceive.collider.name);
                if (RaycastReceive.collider.GetComponent<Destructable>() != null)
                {
                    source.PlayOneShot(sounds[1]);
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
            //transform.position + transform.forward * 0.5f, transform.forward
            if (Physics.Raycast(transform.position + transform.forward * 0.5f, transform.forward, RayDistance, rayLayerMask))
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
