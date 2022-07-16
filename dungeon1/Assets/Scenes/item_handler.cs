using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_handler : MonoBehaviour
{

    public player_movement PlayerMove;

    public string itemName = "item";
    public bool IsMeeleeWeapon = true;

    public GameObject thisb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(IsMeeleeWeapon == true)
            {
                PlayerMove.meelee = itemName;
            }
            if(IsMeeleeWeapon == false)
            {
                PlayerMove.ranged_magic = itemName;
            }

            
        }

        thisb.SetActive(false);

    }
}
