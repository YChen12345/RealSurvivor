using UnityEngine;

public class Battle_PlayerBullet : MonoBehaviour
{
    public int bid;
    public Vector2 dir;
    Battle_Info data;
    public PlayerBullet playerBullet;
    public GameObject avatar;
    IUF uf;
    float s;
    float t;
    float atk_t;
    int state;
    int num;
    int cross;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        avatar.GetComponent<SpriteRenderer>().sprite = uf.LoadResource<Sprite>("PlayerBullet", bid);
        playerBullet.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (data.state == 1)
        {
            Destroy(this.gameObject);
        }
        if (state == 0)
        {
            s += GetComponent<Rigidbody2D>().linearVelocity.magnitude*Time.deltaTime;
            GetComponent<Rigidbody2D>().linearVelocity = dir * playerBullet.speed;
            if (s > playerBullet.distance)
            {
                state = 1;
            }
            else 
            {
                if (data.bd.boss != null)
                {
                    if (uf.Distance2(this.gameObject, data.bd.boss) < playerBullet.range)
                    {
                        HurtEmy(data.bd.boss);
                        cross++;
                    }
                }
                for (int i = 0; i < data.bd.emyList.Count; i++)
                {
                    if (uf.Distance2(this.gameObject, data.bd.emyList[i]) < playerBullet.range)
                    {
                        HurtEmy(data.bd.emyList[i]);
                        cross++;
                        break;
                    }
                }
                if (cross > playerBullet.across)
                {
                    state = 1;
                }
            } 
        }
        else
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            t += Time.deltaTime;
            atk_t += Time.deltaTime;
            if (atk_t > playerBullet.atkgap)
            {
                atk_t = 0;
                num = 0;
                if (data.bd.boss != null)
                {
                    if (uf.Distance2(this.gameObject, data.bd.boss) < playerBullet.range)
                    {
                        HurtEmy(data.bd.boss);
                        num++;
                    }
                }
                for (int i = 0; i < data.bd.emyList.Count; i++)
                {
                    if(uf.Distance2(this.gameObject, data.bd.emyList[i]) < playerBullet.range)
                    {
                        HurtEmy(data.bd.emyList[i]);
                        num++;
                    }
                    if (num > playerBullet.maxaim)
                    {
                        break;
                    }
                }
            }
            if (t > playerBullet.lasttime)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void HurtEmy(GameObject e)
    {
        int k = 1;
        if (Random.Range(0f, 1f) < playerBullet.critical)
        {
            k = 2;
        }
        if (e.GetComponent<Battle_Enemy>().enemy.defence > 0)
        {
            e.GetComponent<Battle_Enemy>().enemy.blood -= playerBullet.attack*k;
            e.GetComponent<Battle_Enemy>().enemy.defence -= playerBullet.trans*k;
        }
        else
        {
            e.GetComponent<Battle_Enemy>().enemy.blood -= playerBullet.attack*2*k;
        }
        if (e.GetComponent<Battle_Enemy>().enemy.defence < 0)
        {
            e.GetComponent<Battle_Enemy>().enemy.defence = 0;
        }
        //HitBack(e);
        SpeedDown(e);
    }
    void HitBack(GameObject e)
    {
        if (playerBullet.repel > 0.1f)
        {
            if (e.GetComponent<Battle_Enemy>().hitBack_timer <= 0)
            {
                e.GetComponent<Battle_Enemy>().hitBack_timer = 0.3f;
                e.GetComponent<Battle_Enemy>().hitBack_speed = playerBullet.repel;
            }
        }    
    }
    void SpeedDown(GameObject e)
    {
        if (e.GetComponent<Battle_Enemy>().speedDown_timer <= 0)
        {
            e.GetComponent<Battle_Enemy>().speedDown_timer = 0.3f;
            e.GetComponent<Battle_Enemy>().speed_debuff = playerBullet.repel/100;
        }
    }
}
