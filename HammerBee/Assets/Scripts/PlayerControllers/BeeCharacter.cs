using UnityEngine;
using System.Collections;

public class BeeCharacter : MonoBehaviour
{

    public bool living;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!living)
        {
            Debug.Log("DISEASE AND FAMINE");
        }
    }
}
