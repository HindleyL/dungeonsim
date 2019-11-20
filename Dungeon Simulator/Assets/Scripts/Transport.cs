using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    public Transform waypoint;
    CharacterController character;
    static float nextMove;

    void Start(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player){
            character = player.GetComponent<CharacterController>();
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && Time.time > nextMove){
            nextMove = Time.time + 5.0f;
            character.enabled = false;
            other.gameObject.transform.position = waypoint.position;
            character.enabled = true;
        }
    } 
}
