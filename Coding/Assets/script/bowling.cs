using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bowling : MonoBehaviour
{
    dog scoring;
    GameObject dogg;
    Collider2D bottle;
    public AudioClip se;
    public AudioSource ads;
    bool fall = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        bottle = gameObject.GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        dogg = GameObject.Find("Alient");
        scoring = dogg.GetComponent<dog>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotateZ = transform.eulerAngles.z;
        if (currentRotateZ > 180)
        {
            currentRotateZ = currentRotateZ - 360;
        }
        /*
        if (currentRotateZ >= 0)
        {
            transform.Rotate(new Vector3(0, 0, -1) * 10f * Time.deltaTime);
            rb.angularVelocity = 0;
        }
        */
        if ( (currentRotateZ <= -90 || currentRotateZ >= 90) && !fall)
        {
            ads.PlayOneShot(se);
            bottle.enabled = false;
            rb.angularVelocity = 0;
            scoring.Score();
            fall = true;
        }
    }
}
