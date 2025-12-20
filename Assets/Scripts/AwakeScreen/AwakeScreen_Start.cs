using UnityEngine;
using UnityEngine.SceneManagement;

public class AwakeScreen_Start : MonoBehaviour
{
    PlayerData pd;
    IUF uf;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        uf = new Functions();
        PlayerPrefs.SetInt("Start", 1);
        int newGame = PlayerPrefs.GetInt("New",0);
        if (newGame == 0)
        {
            PlayerPrefs.SetInt("New", 1);
            pd.Init();
            uf.SaveStructToJson<PlayerData>(pd, "Data/PlayerData");
        }    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3|| Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadSceneAsync("StartScreen");
        }
    }
}
