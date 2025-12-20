using UnityEngine;

public struct Drop
{
    public int mode;
    public float speed;
    public float distance;
    public int heal;
    public int gold;
    public int treasure;

    public void Init()
    {
        mode = 1;
        speed = 8;
        heal = 0;
        gold = 1;
        treasure = 0;
        distance = 3;
    }
}
