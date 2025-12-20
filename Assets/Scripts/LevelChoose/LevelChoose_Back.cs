using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelChoose_Back : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Back);
    }

    void Back()
    {
        SceneManager.LoadSceneAsync("WeaponChoose");
    }
}
