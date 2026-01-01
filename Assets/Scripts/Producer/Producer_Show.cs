using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class Producer_Show : MonoBehaviour
{
    public GameObject text;
    public GameObject center;
    public List<GameObject> displayList = new List<GameObject>();
    public List<float> display_timer = new List<float>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject t = GameObject.Instantiate(text, text.transform.parent);
            t.transform.position = center.transform.position;
            displayList.Add(t);
            display_timer.Add(5*i);
            t.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < display_timer.Count; i++)
        {
            display_timer[i] += Time.deltaTime;
            if (display_timer[i] > 10)
            {
                displayList[i].transform.Translate(Vector2.up * Time.deltaTime * 3);
            }
            if (display_timer[i] > 18)
            {
                displayList[i].transform.position = center.transform.position;
                display_timer[i] = 3;
            }
        }
    }
}
