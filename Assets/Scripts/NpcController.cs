using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{
    Npc_Talking talkingStart;
    private GameObject player;
    AudioSource audio;
    //public GameObject gameOefore the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        talkingStart = GetComponent<Npc_Talking>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "MaleCharacterPBR")
        {
            audio.Play();
            talkingStart.CoroutinStart();
        }
    }
}
