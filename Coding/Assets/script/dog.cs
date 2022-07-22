using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dog : MonoBehaviour
{
    public bowling bottle;
    public float power;
    bool Ready, shoot;
    Rigidbody2D rb;
    float x, y;
    Vector2 spot;
    int Try;
    public int scores;
    public Text txt, txt1;
    public GameObject end;
    public AudioClip se, bgm;
    public AudioSource ads;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spot = transform.position;
        Time.timeScale = 1;
        scores = 0;
        respawn();
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton(0))
        {
            if (power <= 600f)
            {
                power += 100 * Time.deltaTime;
            }
            Ready = false;
        }
        else if (!Ready)
        {
            if (shoot)
            {
                ads.PlayOneShot(se);
                Try += 1;
                Vector2 dir = new Vector2(x - transform.position.x, y - transform.position.y);
                rb.AddForce(power * dir);
                txt.text = Try.ToString();
                txt1.text = Try.ToString();
            }
            shoot = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            respawn();
        }

        if (transform.position.x <= -10 || transform.position.x >= 15)
        {
            respawn();
        }

        if (transform.position.y <= -10 || transform.position.y >= 10)
        {
            respawn();
        }
    }

    void respawn()
    {
        gameObject.transform.position = spot;
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        power = 0;
        Ready = true;
        shoot = true;
    }
    
    public void Score(){
        scores++;
        if(scores >= 6){
            Invoke("EndGame", 1);
        }
    }
    private void OnTriggerEnter2D()
    {   
        Invoke("EndGame", 1);
    }

    void EndGame()
    {
        ads.PlayOneShot(bgm);
        end.SetActive(true);
        Time.timeScale = 0;
    }
}
