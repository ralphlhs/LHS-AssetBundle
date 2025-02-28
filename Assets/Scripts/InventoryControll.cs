using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryControll : MonoBehaviour
{
    public GameObject inventory;
    bool inventoryOnOff = false;
    public LHS_Scrp_Obj lHS_Scrp_Obj;
    public GameObject gotoScene02;
    AudioSource audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lHS_Scrp_Obj.player.HP >= 170)
        {
            Time.timeScale = 0;
            gotoScene02.SetActive(true);
        }
    }

    public void InventoryOpen()
    {
        if (!inventoryOnOff) {
            audio.Play();
            inventory.SetActive(true);
            inventoryOnOff = true;
        }
        else if (inventoryOnOff)
        {
            audio.Play();
            inventory.SetActive(false);
            inventoryOnOff = false;
        }

    }

    public void OnButtonScene1()
    {
        audio.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void OnButtonScene2()
    {
        audio.Play();
        SceneManager.LoadScene("Intro");
    }
}
