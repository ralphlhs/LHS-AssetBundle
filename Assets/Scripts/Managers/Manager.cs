using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    private static PoolManager pool_Manager = new PoolManager();
    public static PoolManager POOL
    {
        get
        {
            return pool_Manager;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject CreateFromPath(string path)
    {
        return Instantiate(Resources.Load<GameObject>(path));
    }
}