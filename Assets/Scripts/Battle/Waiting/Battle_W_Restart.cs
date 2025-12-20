using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_Restart : MonoBehaviour
{
    public GameObject CONFIRM;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        CONFIRM.SetActive(true);
    }
}
