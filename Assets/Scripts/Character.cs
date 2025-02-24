using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;

    //일반적인 방치형 게임의 체력이나 공격력 등의 수치는
    //매우 높은 편에 속함.
    public double hp;
    public double atk;
    //공격 속도는 너무 높으면 문제가 될 수 있음.
    public float attack_speed;

    protected float attack_range = 6.0f;
    protected float target_range = 6.0f;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void SetMotionChange(string motion_name, bool param)
    {
        animator.SetBool(motion_name, param);
    }

    protected virtual void Thrown()
    {
        Debug.Log("발사~! ");
    }

    protected Transform target; //타겟에 대한 정보 (위치)

    //타겟을 찾는 기능
    protected void TargetSearch<T>(T[] targets) where T : Component
    {
       
        var units = targets;//전달받은 값을 통해 할당
        Transform closet = null; //가장 가까운 값은 현재 null
        float max_distance = target_range; //최대 거리 == 타겟의 거리

        //타겟들 전체를 대상으로 거리를 체크합니다.
        foreach (var unit in units)
        {
            //상대와의 거리 체크
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            //타겟 거리보다 작으면 가장 가까운 값
            if (distance < max_distance) {
                closet = unit.transform;
                max_distance = distance;
            }
        }
        //타겟적용
        target = closet;

        //타겟을 응시합니다.
        if (target != null)
            transform.LookAt(target.position);
    }
}
