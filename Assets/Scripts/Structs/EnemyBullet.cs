using UnityEngine;
[System.Serializable]
public struct EnemyBullet
{
    public int attack;
    public int trans;
    public float distance;
    public float speed;
    public float range;

    public void Init()
    {
        attack = 3;
        trans = 1;
        distance = 3;
        speed = 2;
        range = 0.3f;
    }
}
