using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PuduController : Character
{
    public float monster_speed;
    public float rate = 5.0f;
    public LHS_Scrp_Obj lHS_Scrp_Obj;
    public TextMeshProUGUI PuduHP;

    GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("MaleCharacterPBR");
        StartCoroutine(HPCoroutine());
    }

    private void Update()
    {
        PuduHP.text = "돼지 HP : " + lHS_Scrp_Obj.enemy.HP.ToString();

        float target_distance = Vector3.Distance(transform.position, player.transform.position);
        if (target_distance <= rate)
        {
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * monster_speed);
            SetMotionChange("isAttack", true);
        }
        else 
        {
            SetMotionChange("isAttack", false);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Stone(Clone)")
            
        {
            lHS_Scrp_Obj.enemy.HP -= 20;
            Destroy(collision.gameObject);
            if (lHS_Scrp_Obj.enemy.HP == 0)
            {
                lHS_Scrp_Obj.player.HP += 50;
                lHS_Scrp_Obj.meat += 100;
                Invoke("Ex", 5.0f);
            }
        }
    }

    IEnumerator HPCoroutine()
    {
        yield return new WaitForSeconds(5.0f);

        while (true)
        {
            lHS_Scrp_Obj.enemy.HP += 1;
            lHS_Scrp_Obj.player.HP -= 1;
            yield return new WaitForSeconds(5.0f);
        }
    }


    private void Ex()
    {
        Destroy(gameObject);
    }
}



    