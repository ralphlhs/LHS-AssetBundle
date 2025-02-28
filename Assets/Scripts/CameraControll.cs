using UnityEngine;

public class CameraControll : MonoBehaviour
{
    GameObject player;
    public float speed = 3.0f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("MaleCharacterPBR");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameravec = player.transform.position + new Vector3(0, 8f, -10.6f);
        transform.position = Vector3.Lerp(transform.position, cameravec, Time.deltaTime * speed);
    }
}
