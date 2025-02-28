using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Npc_Talking : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Queue<string> stringQueue = new Queue<string>();
    public GameObject gameO;
    public GameObject npcCamera;
    string npcmode = "beforetalking";
    Camera camera;

    void Awake()
    {
        stringQueue.Enqueue("안녕친구, R동21마을에 온것을 환영해~");
        stringQueue.Enqueue("여기는 먹지를 않으면 죽는 곳이야 반드시 먹어야만해!");
        stringQueue.Enqueue("여긴 사과가 있고 동물들도 있어.");
        stringQueue.Enqueue("사과는 주어서 먹으면되고 동물은 잡아 먹어야해~ ");
        stringQueue.Enqueue("그럼 알아서 잘살아봐~~");
    }

    private void Start()
    {
        //npcCamera = GameObject.Find("NPC_Camera");
        camera =  GetComponent<Camera>();
    }


    public void OnButtonClick()
    {
        gameO.SetActive(false);
        npcCamera.SetActive(false);
    }

    public void CoroutinStart()
    {
        if (npcmode == "beforetalking") { StartCoroutine(MyCoroutine()); }
        else if (npcmode == "aftertalking") { StartCoroutine(AgainCoroutine()); }
    }

    IEnumerator MyCoroutine()
    {
        npcCamera.SetActive(true);
        gameO.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            text.text = stringQueue.Dequeue();
            yield return new WaitForSeconds(2.0f);
        }
        gameO.SetActive(false);
        npcCamera.SetActive(false);
        npcmode = "aftertalking";
    }

    IEnumerator AgainCoroutine()
    {
        npcCamera.SetActive(true);
        gameO.SetActive(true);

            text.text = "아까한 얘기 안듣고 뭐했어 ?";
            yield return new WaitForSeconds(2.0f);
        
        gameO.SetActive(false);
        npcCamera.SetActive(false);
        npcmode = "aftertalking";
    }
}

