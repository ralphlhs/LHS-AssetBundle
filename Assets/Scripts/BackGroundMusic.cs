using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        audio.Play();
    }

}
