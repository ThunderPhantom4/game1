using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_move : MonoBehaviour
{
    public float hinput;
    public float vinput;

    public float speed = 1f;

    public int health = 100;
    public Text healthText;


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

        healthText.text = health.ToString();
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "item")
        {
            col.gameObject.SetActive(false);
            health -= 1;
        }
    }
}
