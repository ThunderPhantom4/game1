using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class player_movement : MonoBehaviour
{
    public float hinput;
    public float vinput;

    public string meelee = "null";
    public string ranged_magic = "null";

    public float speed = 1f;

    public int health = 100;

    //public Text healthText;

    public GameObject testSprite;
    public GameObject daggerSprite;

    public int timer = 101;

    public GameObject tthis;

    public Transform daggerPickup;
    public Transform testPickup;

    public bool wasDaggerEquipedLastFrame = false;
    public bool wasTestEquipedLastFrame = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hinput = Input.GetAxis("Horizontal");
        vinput = Input.GetAxis("Vertical");

        this.transform.Translate(Vector3.forward * vinput * Time.deltaTime * speed);
        this.transform.Translate(Vector3.right * hinput * Time.deltaTime * speed);

        //healthText.text = health.ToString();


        if(meelee == "item test")
        {
            wasTestEquipedLastFrame = true;
            testSprite.SetActive(true);
            if(Input.GetMouseButtonDown(0))
            {
                if(timer == 101)
                {
                    timer = 0;
                    StartCoroutine("testHit");
                }
            }
        }
        else
        {
            testSprite.SetActive(false);
            if (wasTestEquipedLastFrame == true)
            {
                //Instantiate(testPickup, new Vector3(0, 0, -2), Quaternion.identity);
                wasTestEquipedLastFrame = false;
            }
            wasTestEquipedLastFrame = false;
           
        }
        if (meelee == "dagger")
        {
            wasDaggerEquipedLastFrame = true;
            daggerSprite.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                if (timer == 101)
                {
                    timer = 0;
                    StartCoroutine("daggerHit");
                }
            }
        }
        else
        {
            
            daggerSprite.SetActive(false);
            if(wasDaggerEquipedLastFrame == true)
            {
                //Instantiate(daggerPickup, new Vector3(0, 0, 2), Quaternion.identity);
                wasDaggerEquipedLastFrame = false;
            }
            wasDaggerEquipedLastFrame = false;
            
        }


        if (hinput < 0)
        {
            tthis.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if(hinput > 0)
        {
            tthis.transform.localEulerAngles = new Vector3(0, 0, 0);
        }



    }

    public IEnumerator testHit()
    {
        if (timer <= 50)
        {
            testSprite.transform.Translate(Vector3.right * 0.015f);
            testSprite.transform.Translate(Vector3.up * 0.015f);
            yield return new WaitForSeconds(0.01f);
            timer += 1;
            StartCoroutine("testHit");
        }
        if(timer >= 50 && timer <= 99)
        {
            testSprite.transform.Translate(Vector3.right * -0.015f);
            testSprite.transform.Translate(Vector3.up * -0.015f);
            yield return new WaitForSeconds(0.01f);
            timer += 1;
            StartCoroutine("testHit");
        }
        if(timer >= 100)
        {
            timer = 101;
        }
    }
    public IEnumerator daggerHit()
    {
        if (timer <= 50)
        {
            daggerSprite.transform.Translate(Vector3.right * 0.03f);
            daggerSprite.transform.Translate(Vector3.up * 0.03f);
            yield return new WaitForSeconds(0.01f);
            timer += 2;
            StartCoroutine("daggerHit");
        }
        if (timer >= 50 && timer <= 99)
        {
            daggerSprite.transform.Translate(Vector3.right * -0.03f);
            daggerSprite.transform.Translate(Vector3.up * -0.03f);
            yield return new WaitForSeconds(0.01f);
            timer += 2;
            StartCoroutine("daggerHit");
        }
        if (timer >= 100)
        {
            timer = 101;
        }
    }



}
