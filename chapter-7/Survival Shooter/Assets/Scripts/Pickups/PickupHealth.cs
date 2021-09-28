using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag ("Player");
 
        //mendapatkan komponen player health
        playerHealth = player.GetComponent <PlayerHealth> ();
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            PickedUp();
        }
    }

    //Jika player berusaha pick up item
    void PickedUp() {
        if(playerHealth.currentHealth < 100)
        {
            playerHealth.Heal(50);
            Destroy(gameObject);
        }
    }
}
