using System.Data;
using UnityEngine;

public class Battle_Camera : MonoBehaviour
{
    GameObject player;
    public float upEdge;
    public float downEdge;
    public float leftEdge;
    public float rightEdge;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rightEdge = 2.5f;
        leftEdge = -2.5f;
        upEdge = 3.9f;
        downEdge = -3.9f;
    }
    void Update()
    {
        transform.position = player.transform.position;
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector3(leftEdge, transform.position.y, 0);
        }
        if (transform.position.x > rightEdge)
        {
            transform.position = new Vector3(rightEdge, transform.position.y, 0);
        }
        if (transform.position.y < downEdge)
        {
            transform.position = new Vector3(transform.position.x, downEdge, 0);
        }
        if (transform.position.y > upEdge)
        {
            transform.position = new Vector3(transform.position.x, upEdge, 0);
        }
    }
}
