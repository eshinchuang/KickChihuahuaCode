using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kick : MonoBehaviour
{
    bool Ready;
    public float speed;
    public GameObject dog;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentRotateZ = transform.eulerAngles.z;
        if (currentRotateZ > 180)
        {
            currentRotateZ = currentRotateZ - 360;
        }
        if (Input.GetMouseButton(0))
        {
            if (currentRotateZ >= -45)
            {
                transform.Rotate(new Vector3(0, 0, -1) * 100f * Time.deltaTime);
            }
            Ready = true;
        }
        else if (Ready)
        {
            if (currentRotateZ <= 30)
                transform.Rotate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            respawn();
        }
        if (dog.transform.position.x <= -10 || dog.transform.position.x >= 15)
        {
            respawn();
        }

        if (dog.transform.position.y <= -10 || dog.transform.position.y >= 10)
        {
            respawn();
        }

    }
    void respawn()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Ready = false;
    }

}
