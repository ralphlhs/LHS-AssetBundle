using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monster_prefab;
    public int monster_count = 10;
    public float monster_spawn_time = 15.0f;
    public float summon_rate = 5.0f; // 해당 수치를 수정할 경우 생성되는 영역(구)의 위치 값이 점점 넓어집니다.
    public float re_rate = 2.0f;     // 생성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있습니다.
    GameObject player;
    GameObject tree;

    public static List<Monster> monster_list = new List<Monster>(); //생성된 몬스터
    public static List<Players> player_list = new List<Players>();  //생성된 캐릭터

    void Start()
    {
        player = GameObject.Find("MaleCharacterPBR");
        tree = GameObject.Find("Tree");
        StartCoroutine(SpawnMonster());
        //StartCoroutine("SpawnMonsterPooling");
    }

    //일반생성시 이걸로 작성
    IEnumerator SpawnMonster()
    {
        Vector3 pos; //생성 좌표 
        for (int i = 0; i < monster_count; i++)
        {
            pos = tree.transform.position + Random.insideUnitSphere * summon_rate;
            pos.y = 3.0f; //생성된 유닛이 맵에 제대로 존재하기 위해 설정
            //너무 근접한 범위에서 생성됐을 경우재할당.
            while (Vector3.Distance(pos, player.transform.position) <= re_rate)
            {
                pos = player.transform.position + Random.insideUnitSphere * summon_rate;
                pos.y = 3.0f;
            }
            GameObject go = Instantiate(monster_prefab, pos, Quaternion.identity);
        }
        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine(SpawnMonster());
        //나 자신을 호출함으로 무한 반복.
    }

    IEnumerator SpawnMonsterPooling()
    {
        Vector3 pos; //생성좌표

        for (int i = 0; i < monster_count; i++)
        {
            pos = tree.transform.position + Random.insideUnitSphere * summon_rate;
            pos.y = 3.0f; //생성된 유닛이 맵에 제대로 존재하기 위해 설정

            while (Vector3.Distance(pos, player.transform.position) <= re_rate)
            {
                pos = player.transform.position + Random.insideUnitSphere * summon_rate;
                pos.y = 5.0f;
            }

            var go = Manager.POOL.PoolObject("SlimePolyart").GetGameObject(); //전달할 함수가 없는 경우(일반 생성)

                //var go = Manager.POOL.PoolObject("SlimePolyart").GetGameObject((result) =>
                //{
                //    result.transform.position = pos;2
                //    result.transform.LookAt(player.transform.position);
                //    monster_list.Add(result.GetComponent<Monster>());
                //    //생성한 유닛을 몬스터 리스트에 추가
                //});//전달할 함수가 있는 경우(Action<GameObject>)
            }
            yield return new WaitForSeconds(monster_spawn_time);
            StartCoroutine("SpawnMonsterPooling");
        }

        //몬스터 풀링한 값에 대한 리턴 코드
        IEnumerator ReturnMonsterPooling(GameObject ob)
        {
            yield return new WaitForSeconds(1.0f);
            Manager.POOL.pool_dict["Monster"].ObjectReturn(ob);
        }
    }
