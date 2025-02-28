using UnityEngine;
//가까우면 멈추고 멀면 따라오는 코드 
public class Monster : Character
{
    public float monster_speed;

    public float rate = 3.5f;

    GameObject obj;

    protected override void Start()
    {
        base.Start();
        obj = GameObject.Find("MaleCharacterPBR");
    }

    // Action 테스트
    public void MonsterSample()
    {
        Debug.Log("몬스터가 생성되었습니다.");
    }

    private void Update()
    {
        transform.LookAt(obj.transform.position);
        //영점 기준으로 시선 변경

        //간격 설정
        float target_distance = Vector3.Distance(transform.position, obj.transform.position);
        if(target_distance <= rate)
        {
            SetMotionChange("isAttack", false);
        }
        else //일반적인 경우에는 움직임을 진행한다.
        {
            transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, Time.deltaTime * monster_speed);
            //영점으로, 몬스터의 속도만큼 앞으로 이동합니다.
            SetMotionChange("isAttack", true);
        }
    }
}
