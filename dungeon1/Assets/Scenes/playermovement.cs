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

    public int timer = 101;


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



    }

    public IEnumerator testHit()
    {
        if (timer <= 50)
        {
            testSprite.transform.Translate(Vector3.right * 0.01f);
            testSprite.transform.Translate(Vector3.up * 0.01f);
            yield return new WaitForSeconds(0.01f);
            timer += 1;
            StartCoroutine("testHit");
        }
        if(timer >= 50 && timer <= 99)
        {
            testSprite.transform.Translate(Vector3.right * -0.01f);
            testSprite.transform.Translate(Vector3.up * -0.01f);
            yield return new WaitForSeconds(0.01f);
            timer += 1;
            StartCoroutine("testHit");
        }
        if(timer >= 100)
        {
            timer = 101;
        }
    }

    
    
}
