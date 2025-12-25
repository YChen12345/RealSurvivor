using System.Collections.Generic;
using UnityEngine;

public class Battle_PlayerWeapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject avatar;
    Battle_Info data;
    IUF uf;
    float timer;
    public int index;
    public int weaponID;
    public int kind;
    public WeaponData wd;
    GameObject player;
    Vector2 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        if (kind == 0)
        {
            avatar.GetComponent<SpriteRenderer>().sprite = uf.LoadResource<Sprite>("PlayerWeapon", weaponID);
        }
        else if(kind == 1) 
        {
            avatar.GetComponent<SpriteRenderer>().sprite = uf.LoadResource<Sprite>("Card", weaponID);
        }
       
        player = data.bd.player;
        wd.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        player.GetComponent<Battle_Player>().weapon_cd[index] = Mathf.Min(timer / wd.atkgap,1);
    }
    void Attack()
    {
        timer += Time.deltaTime;
        if (timer >= wd.atkgap)
        {
            AtkMode();
        }
    }
    void AtkMode()
    {
        GameObject target = GetTarget();
        if (target != null)
        {
            timer = 0;
            if (wd.mode == 0)
            {
                FireBullet(dir,0);
            }
            if (wd.mode == 1)
            {
                FireBullet(dir, 1);
            }
            if (wd.mode == 2)
            {
                FireBullet(uf.RotatedVector2(dir, -40),1);
                FireBullet(uf.RotatedVector2(dir, -20),1);
                FireBullet(uf.RotatedVector2(dir, 0),1);
                FireBullet(uf.RotatedVector2(dir, 20),1);
                FireBullet(uf.RotatedVector2(dir, 40),1);
            }
            if (wd.mode == 3)
            {
                int num = 8;//¿ÅÊý
                for (int i = 0; i < num; i++)
                {
                    FireBullet(uf.RotatedVector2(dir, (360 / num) * i),1);
                }
            }
            if (wd.mode == 4)
            {
                FireBullet(dir, 2);
            }
            if (wd.mode == 5)
            {
                FireBullet(dir, 3);
            }
        }
    }
    void FireBullet(Vector2 dir,int bid)
    {
        GameObject p = GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        p.GetComponent<Battle_PlayerBullet>().bid = bid;
        p.GetComponent<Battle_PlayerBullet>().dir = dir;
        p.GetComponent<Battle_PlayerBullet>().playerBullet.Set(wd);
        p.transform.parent = null;
        p.SetActive(true);
    }
    GameObject GetTarget()
    {
        GameObject target = null;
        float dis = wd.triggerdistance;
        for (int i = 0; i < data.bd.emyList.Count; i++)
        {
            if (uf.Distance2(this.gameObject, data.bd.emyList[i]) < dis)
            {
                target = data.bd.emyList[i];
                dis = uf.Distance2(this.gameObject, data.bd.emyList[i]);
            }
        }
        if (data.bd.boss != null)
        {
            if (uf.Distance2(this.gameObject, data.bd.boss) < dis)
            {
                target = data.bd.boss;
            }
        }
        if (target != null)
        {
            dir = uf.Direction2(this.gameObject, target);
        }
        return target;
    }
}
