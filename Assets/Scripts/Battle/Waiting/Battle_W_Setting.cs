using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_Setting : MonoBehaviour
{
    public GameObject SETTINGPAGE;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GameSetting);
    }

    void GameSetting()
    {
        SETTINGPAGE.SetActive(true);
    }
}
