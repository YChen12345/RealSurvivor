using UnityEngine;

public class Battle_Drop : MonoBehaviour
{
    public int did;
    GameObject player;
    public GameObject avatar;
    Battle_Info data;
    Drop drop;
    IUF uf;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        drop = data.drops.drops[did];
        avatar.GetComponent<SpriteRenderer>().sprite = uf.LoadResource<Sprite>("Drop", did);
        player = data.bd.player;
        data.unpicked++;
    }

    // Update is called once per frame
    void Update()
    {
        switch (drop.mode)
        {
            case 0:
                data.unpicked--;
                Destroy(this.gameObject);
                break;
            case 1:
                if (uf.Distance2(this.gameObject, player) < drop.distance)
                {
                    //GetComponent<Rigidbody2D>().linearVelocity = uf.Direction2(this.gameObject, player) * drop.speed;
                    uf.ObjMoveTo(this.gameObject, player.transform.position, drop.speed);
                }
                if (uf.Distance2(this.gameObject, player) < 0.1f*drop.speed)
                {
                    data.bd.gold += drop.gold;
                    data.bd.treasureNum += drop.treasure;
                    player.GetComponent<Battle_Player>().hd_.blood += drop.heal;
                    data.unpicked--;
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
