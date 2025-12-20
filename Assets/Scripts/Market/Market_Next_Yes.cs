using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Market_Next_Yes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Yes);
    }

    void Yes()
    {
        SceneManager.LoadSceneAsync("CardScreen");
    }
}
