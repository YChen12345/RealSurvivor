using UnityEngine;
using UnityEngine.SceneManagement;
public class Battle_Manager : MonoBehaviour
{
    Battle_Info data;
    public GameObject loadingPage;
    public GameObject WAITINGPAGE;
    public GameObject player;
    public GameObject emyseed;
    public GameObject treasurePage;
    public GameObject awardPage;
    IUF uf;
    int stop;
    float generateGapClock;
    public int settlement_state;
    void Start()
    {       
        stop = 0;
        generateGapClock = 1;
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        player = data.bd.player;
        WAITINGPAGE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (data.state == 0)
        {
            data.totaltime += Time.deltaTime;
        }
        else
        {
            data.totaltime = data.clock;
        }
        EmyGenControl();
        PlayerLV();
        EndControl();
        Stop();
        if (settlement_state == 1)
        {
            SettlementControl();
        }
    }
    void EmyGenControl()
    {
        data.generation_t += Time.deltaTime;
        if (data.bd.emyList.Count < data.maxEmyInScreen)
        {
            if (data.generation_t > generateGapClock)
            {
                data.generation_t = 0;
                float x = Random.Range(-data.map_width / 2, data.map_width / 2);
                float y = Random.Range(-data.map_height / 2, data.map_height / 2);
                int id = Random.Range(0, 6);
                GenSeed(new Vector2(x, y), id);
            }
        }
        else
        {
            data.bd.emyList.RemoveAt(0);
        }
    }
    void EndControl()
    {
        if (data.totaltime > data.clock)
        {
            if (settlement_state == 0)
            {
                settlement_state = 1;
                data.state = 1;
                if (data.bd.treasureNum > 0)
                {
                    data.settlement = 1;
                }
                else if (data.bd.awardNum > 0)
                {
                    data.settlement = 2;
                }
                else
                {
                    data.settlement = 3;
                }
            }
        }
    }
    void Stop()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stop == 0)
            {
                stop = 1;
                Time.timeScale = 0;
                WAITINGPAGE.SetActive(true);
            }
            else if (stop == 1)
            {
                stop = 0;
                Time.timeScale = 1;
                WAITINGPAGE.SetActive(false);
            }
        }
    }
    void GenSeed(Vector2 pos,int id)
    {
        GameObject s = GameObject.Instantiate(emyseed,pos,Quaternion.identity);
        s.GetComponent<Battle_EnemySeed>().sid = id;
        s.SetActive(true);
    }
    void PlayerLV()
    {
        if (data.bd.exp >= data.bd.heroLev * 10)
        {
            data.bd.exp = 0;
            data.bd.heroLev++;
        }
    }
    void SettlementControl()
    {
        switch (data.settlement)
        {
            case 0:
                break;
            case 1:
                if (data.page_state == 0)
                {
                    data.page_state = 1;
                    GameObject t = GameObject.Instantiate(treasurePage, treasurePage.transform.position, Quaternion.identity);
                    t.SetActive(true);
                }
                break;
            case 2:
                if (data.page_state == 0)
                {
                    data.page_state = 1;
                    GameObject a = GameObject.Instantiate(awardPage, awardPage.transform.position, Quaternion.identity);
                    a.SetActive(true);
                }                  
                break;
            case 3:
                if (data.page_state == 0)
                {
                    settlement_state = 2;
                    loadingPage.SetActive(true);
                    loadingPage.GetComponent<LoadingPage>().sceneName = "Market";
                }             
                break;
        }
    }
}
