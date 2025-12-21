using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingPage : MonoBehaviour
{
    public string sceneName;
    public Scene originScene;
    public GameObject maskLeft;
    public GameObject left;
    public GameObject maskRight;
    public GameObject right;
    public GameObject loading;
    int state;
    float unscaleTimer;
    float loadingTimer;
    float load_state;
    float ts;
    int x;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        originScene = SceneManager.GetActiveScene();
    }
    private void OnEnable()
    {
        loading.SetActive(false);
        state = 0;
        x = Camera.main.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledDeltaTime > 0.06f)
        {
            ts = 0.06f;
        }
        else
        {
            ts = Time.unscaledDeltaTime;
        }
        if (state == 0)
        {
            unscaleTimer += ts;
            x = (int)Mathf.SmoothStep(Camera.main.pixelWidth, -3f, unscaleTimer * Camera.main.pixelWidth / 3200f);
            if (x <= -3)
            {
                x = -3;
                unscaleTimer = 0;
                state = 1;
            }
        }
        if (state == 1)
        {
            if (load_state == 0)
            {
                load_state = 1;
                SceneManager.LoadSceneAsync(sceneName);
            }
            loadingTimer += ts;
            if (SceneManager.GetActiveScene() == originScene)
            {
                if (loadingTimer > 0.5f)
                {
                    loading.SetActive(true);
                }             
            }
            else
            {
                loading.SetActive(true);
                unscaleTimer += ts;
               
            }
            if (unscaleTimer > 0.5f)
            {
                loading.SetActive(false);
                unscaleTimer = 0;
                state = 2;
            }

        }
        if (state == 2)
        {
            unscaleTimer += ts;
            x = (int)Mathf.SmoothStep(-3f, Camera.main.pixelWidth, unscaleTimer * Camera.main.pixelWidth / 3200f);
            if (x >= Camera.main.pixelWidth)
            {
                Destroy(this.gameObject);
            }
        }
        maskLeft.GetComponent<RectTransform>().sizeDelta = new Vector2(Camera.main.pixelWidth - x, Camera.main.pixelHeight);
        maskRight.GetComponent<RectTransform>().sizeDelta = new Vector2(Camera.main.pixelWidth - x, Camera.main.pixelHeight);
    }
}
