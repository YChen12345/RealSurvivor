using UnityEngine;

public class Battle_EnemyBullet : MonoBehaviour
{
    public int bid;
    public Vector2 dir;
    GameObject player;
    Battle_Info data;
    public EnemyBullet enemyBullet;
    public GameObject avatar;
    IUF uf;
    float s;
    float t;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        avatar.GetComponent<SpriteRenderer>().sprite = uf.LoadResource<Sprite>("EnemyBullet", bid);
        player = data.bd.player;
        //enemyBullet.Init();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        GetComponent<Rigidbody2D>().linearVelocity = dir*enemyBullet.speed;
        s = enemyBullet.speed * t;
        if (uf.Distance2(this.gameObject, player) < enemyBullet.range)
        {
            if(Random.Range(0f,1f)< player.GetComponent<Battle_Player>().hd_.dodge)
            {
                player.GetComponent<Battle_Player>().beDodge = 1;
            }
            else
            {
                HurtPlayer();
            }
            Destroy(this.gameObject);
        }
        if (s > enemyBullet.distance)
        {
            Destroy(this.gameObject);
        }
        if (data.state == 1)
        {
            Destroy(this.gameObject);
        }
    }
    void HurtPlayer()
    {
        if (player.GetComponent<Battle_Player>().hd_.defence > 0)
        {
            player.GetComponent<Battle_Player>().hd_.blood -= enemyBullet.attack;
            player.GetComponent<Battle_Player>().hd_.defence -= enemyBullet.trans;
        }
        else
        {
            player.GetComponent<Battle_Player>().hd_.blood -= enemyBullet.attack*2;
        }
        if (player.GetComponent<Battle_Player>().hd_.defence < 0)
        {
            player.GetComponent<Battle_Player>().hd_.defence = 0;
        }
    }
}
