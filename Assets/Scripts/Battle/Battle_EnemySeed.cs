using UnityEngine;
using UnityEngine.UI;

public class Battle_EnemySeed : MonoBehaviour
{
    public int sid;
    public GameObject enemy;
    public GameObject avatar;
    public GameObject black;
    GameObject player;
    Battle_Info data;
    IUF uf;
    float range;
    float t;
    float generationTime;
    void Start()
    {
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        Sprite sprite = uf.LoadResource<Sprite>("Emy/EmySeed", sid);
        avatar.GetComponent<SpriteRenderer>().sprite = sprite;
        black.GetComponent<SpriteRenderer>().sprite = sprite;
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
            GameObject emy = GameObject.Instantiate(enemy, this.gameObject.transform.position, Quaternion.identity);
            emy.GetComponent<Battle_Enemy>().eid = sid;
            emy.SetActive(true);
            data.bd.emyList.Add(emy);
            data.bd.seedList.Remove(this.gameObject);
            Destroy(this.gameObject);
           /* if (uf.Distance2(this.gameObject, player) < 0.5f)
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
            }     */    
        }
        if (data.state == 1)
        {
            data.bd.seedList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        range = t / generationTime;
        Color b = new Color(0, 0, 0, (1-range));
        black.GetComponent<SpriteRenderer>().color = b;
    }
}
