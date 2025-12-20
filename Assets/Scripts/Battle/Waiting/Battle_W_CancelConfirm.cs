using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle_W_CancelConfirm : MonoBehaviour
{
    public GameObject CONFIRM;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(CancelConfirm);
    }

    void CancelConfirm()
    {
        CONFIRM.SetActive(false);
    }
}
