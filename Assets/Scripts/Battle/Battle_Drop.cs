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
        avatar.GetComponent<SpriteRenderer>().sprite = uf.LoadResource<Sprite>("Drop", did);
        player = data.bd.player;
    }

    // Update is called once per frame
    void Update()
    {
        switch (drop.mode)
        {
            case 0:
                Destroy(this.gameObject);
                break;
            case 1:
                if (uf.Distance2(this.gameObject, player) < drop.distance)
                {
                    uf.ObjMoveTo(this.gameObject, player.transform.position, drop.speed);
                }
                if (uf.Distance2(this.gameObject, player) < 0.1f*drop.speed)
                {
                    data.bd.gold += drop.gold;
                    data.bd.treasureNum += drop.treasure;
                    player.GetComponent<Battle_Player>().hd_.blood += drop.heal;
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
