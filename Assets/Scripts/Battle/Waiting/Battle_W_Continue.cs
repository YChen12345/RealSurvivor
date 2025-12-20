using UnityEngine;
using UnityEngine.UI;
public class Battle_W_Continue : MonoBehaviour
{
    public GameObject WAITINGPAGE;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ContinueGame);
    }

    void ContinueGame()
    {
        Time.timeScale = 1;
        WAITINGPAGE.SetActive(false);
    }
}
