using UnityEngine;
using UnityEngine.SceneManagement;
public class Battle_Manager : MonoBehaviour
{
    Battle_Info data;
    public GameObject WAITINGPAGE;
    public GameObject player;
    public GameObject emyseed;
    IUF uf;
    int stop;
    float generateGapClock;
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
        data.totaltime += Time.deltaTime;
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
        if (data.totaltime > data.clock)
        {
            data.state = 1;
            SceneManager.LoadSceneAsync("Market");
        }
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
}
