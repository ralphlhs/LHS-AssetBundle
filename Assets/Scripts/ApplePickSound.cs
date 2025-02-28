using UnityEngine;

public class ApplePickSound : MonoBehaviour
{
    AudioSource audio;
    GameObject apple;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        apple = GameObject.Find("Apple(Clone)");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            audio.Play();
        }
    }
}
