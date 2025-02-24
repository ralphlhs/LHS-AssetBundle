using UnityEngine;

[CreateAssetMenu(fileName ="InfoOfplayer", menuName = "ScriptableObj/PlayerItem", order = 0)]
public class LHS_Scrp_Obj : ScriptableObject
{
    [Header("퀘스트 정보")]
    public float damage;
    public float cooltime;

    public string animationName;
    public Sprite icon;

    [Header("각각 플레이어들")]
    public Enemy enemy;
    public Player player;
    //Enemy enemy = new Enemy(10, "적군");
    //Player player = new Player(20, "아군");
}

[CreateAssetMenu(fileName = "EnemyIO", menuName = "ScriptableObj/에너미아이템")]
public class Enemy : ScriptableObject
{
    public Enemy(int HP, string name) {
        this.HP = HP;
        this.name = name;
    }
    public int HP;
    public string name;
}

[CreateAssetMenu(fileName = "PlayerIO", menuName = "ScriptableObj/플레이아이템")]
public class Player : ScriptableObject
{
    public Player(int HP, string name)
    {
        this.HP = HP;
        this.name = name;
    }
    public int HP = 20;
    public string name;
}