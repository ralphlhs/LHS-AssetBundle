using UnityEngine;
using UnityEngine.UI;

public class SkilButton : MonoBehaviour
{
    public LHS_Scrp_Obj lhs;
    public Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //lhs.player.HP = 0;
    }


    public void OnButton()
    {
        
        lhs.player.HP++;
        text.text = lhs.player.HP.ToString();
    }
}
