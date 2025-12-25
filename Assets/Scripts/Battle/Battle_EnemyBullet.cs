using UnityEngine;

public class Battle_EnemyBullet : MonoBehaviour
{
    public int bid;
    public Vector2 dir;
    GameObject player;
    Battle_Info data;
    EnemyBullet enemyBullet;
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
        enemyBullet.Init();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        GetComponent<Rigidbody2D>().linearVelocity = dir*enemyBullet.speed;
        s = GetComponent<Rigidbody2D>().linearVelocity.magnitude * t;
        if (uf.Distance2(this.gameObject, player) < enemyBullet.range)
        {
            player.GetComponent<Battle_Player>().hd_.blood -= enemyBullet.attack;
            player.GetComponent<Battle_Player>().hd_.defence -= enemyBullet.trans;
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
}
