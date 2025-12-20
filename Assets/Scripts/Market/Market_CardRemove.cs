using UnityEngine;

public class Market_CardRemove : MonoBehaviour
{
    IUF uf = new UIFunctions();
    public GameObject canvas;
    public GameObject removePlace;
    public GameObject removePage;
    public Market_Info data;
    Vector3 originScaling;
    Vector3 originPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = GameObject.Find("Market").GetComponent<Market_Info>();
        originScaling=removePlace.transform.localScale;
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (uf.InArea(this.transform.position, uf.Area(removePlace))){
            removePlace.transform.localScale = originScaling*1.1f;
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
            removePlace.transform.localScale = originScaling;
        }
    }
}
