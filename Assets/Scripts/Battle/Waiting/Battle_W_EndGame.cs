using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_EndGame : MonoBehaviour
{
    public GameObject CONFIRM;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(EndGame);
    }

    void EndGame()
    {
        //Time.timeScale = 1;
        //SceneManager.LoadSceneAsync("Lose");
        CONFIRM.SetActive(true);
    }
}
