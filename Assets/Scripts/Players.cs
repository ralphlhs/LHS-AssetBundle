using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Players : Character
{
    Vector3 start_pos;
    Vector3 destination;
    Quaternion rotation;
    Camera camera;

    protected override void Start()
    {
        camera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        //camera = Camera.main; // 메인카메라로 전체 뷰를 볼때 
        //캐릭터 클래스의 Start 시작(animator = GetComponent<Animator>();)
        base.Start();
        start_pos = transform.position;
        rotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }//클릭한 지점으로 이동좌표구함. 





        if(target == null)
        {
            //가까운 타겟 조사
            TargetSearch(Spawner.monster_list.ToArray());

            //리스트명.ToArray()를 통해 list -> array
            float pos = Vector3.Distance(transform.position, destination);
            if(pos > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 2.0f);
                transform.LookAt(destination);
                SetMotionChange("Fwd",true);
            }
            else
            {
                //transform.rotation = rotation;
                transform.localRotation =
                Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 180.0f, 0), Time.deltaTime * 9);
                SetMotionChange("Fwd", false);
            }
            return; //작업 종료
        }

        float distance = Vector3.Distance(transform.position, target.position);

        //타겟 범위보다 작으면서 공격 범위보다 높은 경우
        if (distance <= target_range && distance > attack_range)
        {
            SetMotionChange("Bwd", true);
            //타겟 지점으로 이동
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }
        //공격 범위 안에 들어온 경우
        else if (distance <= attack_range)
        {
            //공격 자세로 넘어갑니다.
            SetMotionChange("Fwd", true);
        }
    }

    private void SetDestination(Vector3 point)
    {
        destination = point;
    }//마우스 클릭해서 hit.point값을 destination에 입력.
}
