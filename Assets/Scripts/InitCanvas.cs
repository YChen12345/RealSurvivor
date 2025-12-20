using UnityEngine;
using UnityEngine.UI;

public class InitCanvas: MonoBehaviour
{
    public int mode;
    Canvas canvas;
    private void Awake()
    {
        canvas = this.gameObject.GetComponent<Canvas>();
        if (mode == 0)
        {
            if (canvas.worldCamera != null)
            {
                canvas.worldCamera = Camera.main;
            }
        }
    }
    // Start is called before the first frame update
   /* void Start()
    {
        CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();

        // 设置 UI Scale Mode
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        // 设置相关参数
        scaler.referenceResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height); // 设置参考分辨率
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 0.5f; // 设置宽高匹配比例
    }*/
}
