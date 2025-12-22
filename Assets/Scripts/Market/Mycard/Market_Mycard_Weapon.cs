using UnityEngine;
using UnityEngine.UI;
public class Market_Mycard_Weapon : MonoBehaviour
{
    public GameObject mycard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisPlayWeapon);
    }

    void DisPlayWeapon()
    {
        mycard.GetComponent<Market_Mycard>().state = 1;
    }
}
