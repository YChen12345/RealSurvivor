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
    public GameObject displayPage;
    IUF uf;
    int stop;
    float generateGapClock;
    public int win;
    public int hasboss;
    int end_state;
    void Start()
    {       
        stop = 0;
        uf = new Functions();
        data = GameObject.Find("Battle").GetComponent<Battle_Info>();
        generateGapClock = data.generateGapClock;
        player = data.bd.player;
        WAITINGPAGE.SetActive(false);
        BossGen();
    }

    // Update is called once per frame
    void Update()
    {
        if (data.state == 0)
        {
            if (data.bd.boss == null)
            {
                data.totaltime += Time.deltaTime;
            }
        }
        else
        {
            data.totaltime = data.clock;
        }
        EmyGenControl();     
        EndControl();
        PlayerLV();
        Stop();
        GameOver();
        if (data.settlement_state == 1)
        {
            SettlementControl();
        }
    }
    void BossGen()
    {
        int bossid = data.levels.levels[data.bd.wave].bossid;
        int boss_mode = data.levels.levels[data.bd.wave].boss_mode;
        if (boss_mode > 0)
        {
            float x = Random.Range(-data.map_width / 2, data.map_width / 2);
            float y = Random.Range(-data.map_height / 2, data.map_height / 2);
            GenSeed(new Vector2(x, y), bossid,1);
            hasboss = 1;
        }
    }
    void EmyGenControl()
    {
        data.generation_t += Time.deltaTime;
        if(data.genIndex< data.emyList.Count)
        {
            if (data.bd.emyList.Count < data.maxEmyInScreen)
            {
                if (data.generation_t > generateGapClock)
                {
                    data.generation_t = 0;
                    float x = 0;
                    float y = 0;
                    x = Random.Range(0, data.map_width*4/6);
                    y = Random.Range(0, data.map_height*4/6);
                    if (x- data.map_width/2 < player.transform.position.x - data.map_width/ 6)
                    {
                        x = x - data.map_width / 2;
                    }
                    else
                    {
                        x = x - data.map_width / 6;
                    }
                    if (y - data.map_height / 2 < player.transform.position.y - data.map_height / 6)
                    {
                        y = y - data.map_height / 2;
                    }
                    else
                    {
                        y = y - data.map_height / 6;
                    }
                    int id = data.emyList[data.genIndex];
                    data.genIndex++;
                    GenSeed(new Vector2(x, y), id);
                }
            }
            else
            {
                if (data.generation_t > 3 * generateGapClock)
                {
                    data.generation_t = 0;
                    float x = Random.Range(-data.map_width / 2, data.map_width / 2);
                    float y = Random.Range(-data.map_height / 2, data.map_height / 2);
                    int id = data.emyList[data.genIndex];
                    data.genIndex++;
                    GenSeed(new Vector2(x, y), id);
                }
            }
        }      
    }
    void EndControl()
    {
        Boss();
        if (data.totaltime >= data.clock)
        {
            BossEffect();
            if (end_state == 0)////
            {
                end_state = 1;
                data.state = 1;
                displayPage.SetActive(false);
                data.bd.exp += data.hd.extraexp;
                data.bd.gold += data.hd.extramoney;
                data.bd.gold += 25;
            }         
            if (data.unpicked > 0)
            {
                return;
            }
            else if (data.settlement_state == 0)
            {
                data.settlement_state = 1;
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
                if (data.bd.wave == data.levels.levels.Count-1)
                {
                    data.settlement = 4;
                }
            }
        }
    }
    void Boss()
    {
        if (data.levels.levels[data.bd.wave].boss_mode >0)//-------------------------------
        {
            if (hasboss == 1)
            {
                if (data.totaltime > 3)
                {
                    if (data.bd.boss == null)
                    {
                        data.totaltime = data.clock-3;
                        hasboss = 0;
                    }
                }
            }
        }      
    }
    void BossEffect()
    {
        int boss_mode = data.levels.levels[data.bd.wave].boss_mode;      
        if (data.bd.boss != null)
        {
            if (boss_mode == 2)
            {
                data.bd.mana = Mathf.Max(0, data.bd.mana - 5);
            }
            else if (boss_mode == 3)
            {
                data.bd.gold = 0;
            }
            else if (boss_mode == 4)
            {
                data.settlement_state = 2;
                uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
                loadingPage.SetActive(true);
                loadingPage.GetComponent<LoadingPage>().sceneName = "Lose";
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
        else
        {
            if (Time.timeScale == 1)
            {
                stop = 0;
            }
        }
    }
    void GenSeed(Vector2 pos,int id, int boss=0)
    {
        GameObject s = GameObject.Instantiate(emyseed,pos,Quaternion.identity);
        s.GetComponent<Battle_EnemySeed>().sid = id;
        s.GetComponent<Battle_EnemySeed>().boss = boss; 
        s.SetActive(true);
    }
    void PlayerLV()
    {
        if (data.bd.exp >= data.bd.heroLev * 10)
        {
            data.bd.exp = 0;
            data.bd.heroLev++;
            data.bd.awardNum++;
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
                    data.settlement_state = 2;
                    data.bd.wave++;
                    data.bd.ResetUsedCard();
                    uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
                    loadingPage.SetActive(true);
                    loadingPage.GetComponent<LoadingPage>().sceneName = "Market";
                }             
                break;
            case 4:
                if (data.page_state == 0)
                {
                    data.settlement_state = 2;
                    uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
                    loadingPage.SetActive(true);
                    loadingPage.GetComponent<LoadingPage>().sceneName = "Win";
                }
                break;
        }
    }
    void GameOver()
    {
        if (data.dead == 1)
        {
            if (data.settlement_state == 0)
            {
                data.settlement_state = 2;
                uf.SaveStructToJson<BattleData>(data.bd, "Data/BattleData");
                loadingPage.SetActive(true);
                loadingPage.GetComponent<LoadingPage>().sceneName = "Lose";
            }           
        }
    }
}
