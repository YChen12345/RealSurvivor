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
        attack = 0;
        trans = 0;
        distance = 1;
        speed = 1;
        range = 0.3f;
    }
}
