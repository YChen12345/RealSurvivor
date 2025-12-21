using UnityEngine;

public class Battle_Enemy : MonoBehaviour
{
    public int eid;
    public GameObject seed;
    public GameObject drop;
    public GameObject avatar;
    public GameObject bullet;
    public GameObject warning;
    public GameObject display;
    GameObject player;
    Battle_Info data;
    public Enemy enemyfigure;
    public Enemy enemy;
    IUF uf;
    float t;
    int atk_state;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        player = data.bd.player;
        avatar.GetComponent<SpriteRenderer>().sprite= uf.LoadResource<Sprite>("Emy", eid);
        float height = uf.Area(avatar).height / 2;
        avatar.transform.localPosition = new Vector2(0, height * avatar.transform.localScale.y);
        warning.transform.localPosition = new Vector2(0, 3.0f*height * avatar.transform.localScale.y);
        display.transform.localPosition = new Vector2(0, 2.2f*height * avatar.transform.localScale.y);
        enemyfigure.Init();
        enemy = enemyfigure;
        warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {     
        Move();
        if(uf.Distance2(this.gameObject, player) < enemy.atkdistance||atk_state==1)
        {
            t += Time.deltaTime;
            if (t > enemy.atkgap - 0.5f)
            {
                atk_state = 1;
            }
            else
            {
                atk_state = 0;
            }
        }
        else if(atk_state!=1)
        {
            t = 0;
            atk_state = 0;
        }
        if (t > enemy.atkgap)
        {
            t = 0;
            atk_state = 0;
            Attack();
        }
        if (atk_state==1)
        {
            warning.SetActive(true);
        }
        else
        {
            warning.SetActive(false);
        }
        Dead();
    }
    void Move()
    {
        switch (enemy.mode_move)
        {
            case 0:
                if (uf.Distance2(this.gameObject, player) < enemy.speed * 0.1f)
                {
                    uf.ObjMoveTo(this.gameObject, player.transform.position, enemy.speed);
                }
                else
                {
                    GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                }
                break;
            case 1:
                if (uf.Distance2(this.gameObject, player) > enemy.atkdistance)
                {
                    uf.ObjMoveTo(this.gameObject, player.transform.position, enemy.speed);
                }
                else
                {
                    GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                }    
                break;
            case 2:
                Vector2 dir00 = uf.Direction2(player, this.gameObject);
                Vector2 dir01 = uf.RotatedVector2(dir00,90);
                Vector2 aim = dir00*enemy.atkdistance*0.6f + dir01;
                uf.ObjMoveTo(this.gameObject, aim, enemy.speed);
                break;
            case 3:
                break;

        }
        uf.MoveLimitation(this.gameObject, data.map_width, data.map_height, Vector2.zero);
    }
    void Attack()
    {
        switch (enemy.mode_atk)
        {
            case 0:
                FireBullet(uf.Direction2(this.gameObject, player));
                break;
            case 1:
                FireBullet(uf.Direction2(this.gameObject, player));
                break;
            case 2:
                FireBullet(uf.Direction2(this.gameObject, player));
                break;
            case 3:
                FireBullet(uf.Direction2(this.gameObject, player));
                break;
            case 4:
                FireBullet(uf.Direction2(this.gameObject, player));
                break;

        }
    }
    void FireBullet(Vector2 dir)
    {
        GameObject p = GameObject.Instantiate(bullet, this.gameObject.transform.position, Quaternion.identity);
        p.GetComponent<Battle_EnemyBullet>().bid = eid;
        p.GetComponent<Battle_EnemyBullet>().dir = dir;
        p.SetActive(true);
    }

    void Dead()
    {
        if (enemy.blood <= 0)
        {
            GameObject d = GameObject.Instantiate(drop, this.transform.position, Quaternion.identity);
            d.GetComponent<Battle_Drop>().did = enemy.dropid;
            d.SetActive(true);
            data.bd.emyList.Remove(this.gameObject);
            data.bd.exp++;
            Destroy(this.gameObject);
        }
    }
}
