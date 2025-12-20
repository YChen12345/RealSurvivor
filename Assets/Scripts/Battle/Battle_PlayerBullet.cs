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
                for (int i = 0; i < data.bd.emyList.Count; i++)
                {
                    if (uf.Distance2(this.gameObject, data.bd.emyList[i]) < playerBullet.range)
                    {
                        data.bd.emyList[i].GetComponent<Battle_Enemy>().enemy.blood -= playerBullet.attack;
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
                for(int i = 0; i < data.bd.emyList.Count; i++)
                {
                    if(uf.Distance2(this.gameObject, data.bd.emyList[i]) < playerBullet.range)
                    {
                        data.bd.emyList[i].GetComponent<Battle_Enemy>().enemy.blood -= playerBullet.attack;
                        data.bd.emyList[i].GetComponent<Battle_Enemy>().enemy.defence -= playerBullet.trans;
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
}
