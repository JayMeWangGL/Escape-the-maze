using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private PlayerController Player;
    private AI ai;
    public float damage;
    float tempTime = 0;
    public float cd = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.GetComponent<PlayerController>();
        ai = gameObject.GetComponent<AI>();
        damage = 10.0f;


    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag =="Enemy")
        {
            if (Time.time - tempTime > cd)
            {
                other.gameObject.GetComponent<AI>().Attacked(damage);
                tempTime = Time.time;
            }
            
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
