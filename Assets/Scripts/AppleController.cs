using UnityEngine;
using TMPro;

public class AppleController : MonoBehaviour
{
    public LHS_Scrp_Obj lHS_Scrp_Obj;
    public Enemy enemy;
    public Player player;

    public TextMeshProUGUI appleCount;
    public TextMeshProUGUI meatCount;
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        appleCount.text = lHS_Scrp_Obj.apple.ToString();
        meatCount.text = lHS_Scrp_Obj.meat.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Apple(Clone)")
        {
            audio.Play();
            lHS_Scrp_Obj.apple++;
            lHS_Scrp_Obj.player.HP += 10;
            Destroy(collision.gameObject);
        }
    }
}

    
  