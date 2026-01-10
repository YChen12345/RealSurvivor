using UnityEngine;

public class Battle_Enemy : MonoBehaviour
{
    public int eid;
    public GameObject seed;
    public GameObject drop;
    public GameObject avatar;
    public GameObject avatar_fade;
    public GameObject blood_hurt;
    public GameObject blood_dead;
    public GameObject bullet;
    public GameObject warning;
    public GameObject display;
    public GameObject effectFigure;
    GameObject player;
    Battle_Info data;
    public Enemy enemyfigure;
    public Enemy enemy_last;
    public Enemy enemy;
    Sprite avatarSprite_normal;
    Sprite avatarSprite_hurt;
    IUF uf;
    IAnim animplayer = new AnimationPlayer();
    float t;
    int atk_state;
    float hurt_timer;
    int behurt;
    public float hitBack_timer;
    public float hitBack_speed;
    public float speedDown_timer;
    public float speed_debuff;
    public int beCritical;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        player = data.bd.player;
        animplayer.SetFrameTime(0.1f);
        string rootRoute = "Emy/EmyAnim/" + eid + "/";
        animplayer.SetSprites(rootRoute + "Stay");
        animplayer.SetSprites(rootRoute + "Move");
        animplayer.SetSprites(rootRoute + "Atk");
        avatarSprite_normal = uf.LoadResource<Sprite>("Emy/Emy", eid);
        avatarSprite_hurt = uf.LoadResource<Sprite>("Emy/EmyHurt", eid);
        avatar.GetComponent<SpriteRenderer>().sprite = avatarSprite_normal;
        avatar_fade.GetComponent<SpriteRenderer>().sprite = avatarSprite_normal;
        float height = uf.Area(avatar).height / 2;
        avatar.transform.localPosition = new Vector2(0, height * avatar.transform.localScale.y);
        warning.transform.localPosition = new Vector2(0, 3.0f*height * avatar.transform.localScale.y);
        display.transform.localPosition = new Vector2(0, 2.2f*height * avatar.transform.localScale.y);
        enemyfigure = data.enemies.enemies[eid];
        enemy = enemyfigure;
        enemy_last = enemy;
        warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndHitBack();
        //Move();
        Anim();
        BeHurt();
        BeHeal();
        WarningAndAtk();
        Dead();
    }
    void WarningAndAtk()
    {
        if (uf.Distance2(this.gameObject, player) < enemy.atkdistance || atk_state == 1)
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
        else if (atk_state != 1)
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
        if (atk_state == 1)
        {
            warning.SetActive(true);
        }
        else
        {
            warning.SetActive(false);
        }
    }
    void Anim()
    {
        if(atk_state == 1)
        {
            animplayer.AnimPlay(avatar, 2, Time.deltaTime);
        }
        else
        {
            if (GetComponent<Rigidbody2D>().linearVelocity.magnitude < 0.01f)
            {
                animplayer.AnimPlay(avatar, 1, Time.deltaTime);
            }
            else
            {
                animplayer.AnimPlay(avatar, 1, Time.deltaTime);
            }
        }
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
        p.GetComponent<Battle_EnemyBullet>().enemyBullet.Set(enemy);
        p.SetActive(true);
    }
    void BeHurt()
    {
        if (behurt == 1)
        {
            hurt_timer += Time.deltaTime;
            //avatar.GetComponent<SpriteRenderer>().sprite = avatarSprite_hurt;
            avatar.GetComponent<SpriteRenderer>().color = Color.red;
            if (hurt_timer > 0.3f)
            {
                hurt_timer = 0;
                behurt = 0;
            }
        }
        else
        {
            //avatar.GetComponent<SpriteRenderer>().sprite = avatarSprite_normal;
            avatar.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (enemy_last.blood > enemy.blood)
        {
            int hurtvalue = enemy_last.blood - enemy.blood;
            int hurtvalue_1 = enemy_last.defence - enemy.defence;
            int df = enemy_last.defence;
            enemy_last.blood = enemy.blood;
            enemy_last.defence = enemy.defence;
            behurt = 1;
            Effect_blood_hurt();
            GameObject f = GameObject.Instantiate(effectFigure, display.transform.position, Quaternion.identity);
            f.transform.parent = null;
            f.GetComponent<Battle_EffectFigure>().value = hurtvalue;
            if (df > 0)
            {
                f.GetComponent<Battle_EffectFigure>().value_1 = hurtvalue_1;
                if (beCritical == 0)
                {
                    f.GetComponent<Battle_EffectFigure>().mode = 0;
                }
                else
                {
                    f.GetComponent<Battle_EffectFigure>().mode = 1;
                }
            }
            else
            {
                if (beCritical == 0)
                {
                    f.GetComponent<Battle_EffectFigure>().mode = 2;
                }
                else
                {
                    f.GetComponent<Battle_EffectFigure>().mode = 3;
                }
            }
            f.SetActive(true);
        }
    }
    void BeHeal()
    {
        if (enemy_last.blood < enemy.blood)
        {
            int hurtvlaue = enemy_last.blood - enemy.blood;
            enemy_last.blood = enemy.blood;
            GameObject f = GameObject.Instantiate(effectFigure, display.transform.position, Quaternion.identity);
            f.transform.parent = null;
            f.GetComponent<Battle_EffectFigure>().value = hurtvlaue;
            f.SetActive(true);
        }
    }

    void Dead()
    {
        if (data.state == 1)
        {
            Effect_Fade();
            data.bd.emyList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else if (enemy.blood <= 0)
        {
            Effect_Fade();
            Effect_blood_dead();
            GameObject d = GameObject.Instantiate(drop, this.transform.position, Quaternion.identity);
            d.GetComponent<Battle_Drop>().did = enemy.dropid;
            d.SetActive(true);
            data.bd.emyList.Remove(this.gameObject);
            data.bd.exp++;
            Destroy(this.gameObject);
        }
    }
    void Effect_Fade()
    {
        avatar_fade.transform.position = avatar.transform.position;
        avatar_fade.transform.parent = null;
        avatar_fade.SetActive(true);
    }
    void Effect_blood_hurt()
    {
        GameObject b = GameObject.Instantiate(blood_hurt,this.gameObject.transform.position,Quaternion.identity);
        b.transform.parent = null;
        b.SetActive(true);
    }
    void Effect_blood_dead()
    {
        GameObject b = GameObject.Instantiate(blood_dead, this.gameObject.transform.position, Quaternion.identity);
        b.transform.parent = null;
        b.SetActive(true);
    }
    void MoveAndHitBack()
    {
        if (hitBack_timer > 0)
        {
            hitBack_timer -= Time.deltaTime;
            GetComponent<Rigidbody2D>().linearVelocity = uf.Direction2(player, this.gameObject)*hitBack_speed;
        }
        else
        {
            MoveAndSpeedDown();
        }
    }
    void MoveAndSpeedDown()
    {
        speedDown_timer -= Time.deltaTime;
        if (speedDown_timer < 0)
        {
            speed_debuff = 0;
        }
        enemy.speed = enemyfigure.speed * (1-Mathf.Min(speed_debuff,0.9f));
        Move();
    }
}
