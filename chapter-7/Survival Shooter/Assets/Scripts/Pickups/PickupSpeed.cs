using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerMovement;
    SphereCollider collider;
    MeshRenderer renderer;
    Light light;

    // Start is called before the first frame update
    void Start()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag ("Player");
 
        //mendapatkan komponen player health
        playerMovement = player.GetComponent <PlayerMovement> ();

        //mendapatkan komponen collider dan renderer
        collider = GetComponent <SphereCollider> ();
        renderer = GetComponent <MeshRenderer> ();
        light = GetComponent <Light> ();
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
        playerMovement.ChangeSpeed(3);
        StartCoroutine(SpeedUp(5));
        Destroy(collider);
        Destroy(renderer);
        Destroy(light);
    }

    IEnumerator SpeedUp(int sec) {
        yield return new WaitForSeconds(sec);
        playerMovement.ChangeSpeed(-3);
        Destroy(gameObject);
    }
}
