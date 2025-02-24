using System;
using System.Collections.Generic;
using UnityEngine;

//풀(웅덩이)
//오브젝트를 풀에 만들어두고, 필요할 때마다 풀 안에 있는 객체를 꺼내서 사용하는 방식
//매번 실시간으로 파괴하고, 생성하는 것보다 CPU의 부담을 줄일 수 있습니다.
//대신 미리 할당해두는 방식이기 때문에 메모리를 희생해서 성능을 높이는 방식입니다.using UnityEngine;

public interface IPool
{
    Transform parent { get; set; }
    Queue<GameObject> pool { get; set; } //FIFO(First In First Out)
    //Function
    //default parameter : 값을 따로 넣지 않았을 경우 지정한 값으로 자동 처리됩니다.
    //ex) var go = GetGameObject();
    //ex) var go = GetGameObject(action);

    GameObject GetGameObject(Action<GameObject> action = null);
    void ObjectReturn(GameObject ob, Action<GameObject> action = null);
}

public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null) {
        var obj = pool.Dequeue();//풀에있는 값 하나 빼오겠습니다.

        obj.SetActive(true);//오브젝트 활성화 진행

        if (action != null)
        {
            action?.Invoke(obj);
        }
        return obj;
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null) {
        pool.Enqueue(ob);
        ob.transform.parent = parent;
        ob.SetActive(false);
        if (action != null)
        {
            action?.Invoke(ob);
        }
    }
}

public class PoolManager
{
    public Dictionary<string, IPool> pool_dict = new Dictionary<string, IPool>();

    public IPool PoolObject(string path)
    {
        //해당 키가 없다면 추가를 진행합니다.
        if (!pool_dict.ContainsKey(path))
        { Add(path); }

        if (pool_dict[path].pool.Count <= 0)
        {
            AddQ(path);
        }
        return pool_dict[path];
    }

    private void Add(string path)
    {
        var obj = new GameObject(path + "Pool");
        //전달받은 이름으로 풀 오브젝트 생성
        ObjectPool object_pool = new ObjectPool();
        //오브젝트 풀 생성
        pool_dict.Add(path, object_pool);
        //경로와 오브젝트 풀을 딕셔너리에 저장
        object_pool.parent = obj.transform;
        //트랜스폼 설정
    }

    private void AddQ(string path)
    {
        var go = Manager.instance.CreateFromPath(path);
        go.transform.parent = pool_dict[path].parent;
        pool_dict[path].ObjectReturn(go);
    }
}
