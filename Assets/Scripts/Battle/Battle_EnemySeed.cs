using UnityEngine;

public class Battle_EnemySeed : MonoBehaviour
{
    public int sid;
    public GameObject enemy;
    public GameObject avatar;
    GameObject player;
    Battle_Info data;
    IUF uf;
    float t;
    float generationTime;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        avatar.GetComponent<SpriteRenderer>().sprite = uf.LoadResource<Sprite>("Emy/EmySeed", sid);
        data.bd.seedList.Add(this.gameObject);
        player = data.bd.player;
        t = 0;
        generationTime = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > generationTime)
        {
            if (uf.Distance2(this.gameObject, player) < 0.5f)
            {
                Destroy(this.gameObject);
            }
            else
            {
                GameObject emy = GameObject.Instantiate(enemy, this.gameObject.transform.position, Quaternion.identity);
                emy.GetComponent<Battle_Enemy>().eid = sid;
                emy.SetActive(true);
                data.bd.emyList.Add(emy);
                data.bd.seedList.Remove(this.gameObject);
                Destroy(this.gameObject);
            }         
        }
        if (data.state == 1)
        {
            data.bd.seedList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
