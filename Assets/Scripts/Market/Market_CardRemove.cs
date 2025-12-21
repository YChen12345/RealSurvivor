using UnityEngine;

public class Market_CardRemove : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject canvas;
    public GameObject removePlace;
    public GameObject removePage;
    public Market_Info data;
   
    Vector3 originPosition;
    int state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (uf.InArea(this.transform.position, uf.Area(removePlace))){
            if (state == 0)
            {
                state = 1;
                removePlace.GetComponent<Market_RemovePlace>().state++;
            }       
            if (Input.GetMouseButtonUp(0))
            {
                GameObject r = GameObject.Instantiate(removePage, canvas.transform);
                r.GetComponent<Market_RemovePage>().rid = GetComponent<Market_Card>().cid;
                r.SetActive(true);
                this.gameObject.transform.position = originPosition;
            }
        }
        else
        {
            if(state == 1)
            {
                state = 0;
                removePlace.GetComponent<Market_RemovePlace>().state--;
            }
        }
    }
}
