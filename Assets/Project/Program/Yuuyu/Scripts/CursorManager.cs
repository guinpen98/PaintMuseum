using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    //カーソルの画像を指定
    [SerializeField] public Texture2D CursorImgBlue;
    [SerializeField] public Texture2D CursorImgRed;
    [SerializeField] public Texture2D CursorImgYellow;
    [SerializeField] public Texture2D CursorImgGreen;
    [SerializeField] public Texture2D CursorImgPink;
    [SerializeField] public Texture2D CursorImgWhite;

    [SerializeField] public int size;
    //カーソルの画像の変更フラグ
    private bool isCursorChange=false;

    //カラーパレット画面の変更フラグ
    private bool isColorParettePhase = false;
    //色の識別
    [SerializeField] public string colorname;
    //カメラを取得
    [SerializeField] public Camera camera_object;
    //レイキャストが当たったものを取得する入れ物
    private RaycastHit hit;

    //特定のボタンを押した際の画面の変更
    [SerializeField] public GameObject panel;

    //カラーパレットのオブジェクト
    [SerializeField] public GameObject colorPallet;

    //カーソルのスポット点の設定
    private Vector2 hotSpot = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを画面内にロックする。
        Cursor.lockState = CursorLockMode.Locked;
        // マウスカーソルを消去する
        Cursor.visible = false;

        //aa= ResizeTexture(CursorImgBlue, size, size);
        //CursorImgBlue = aa;
    }

    // Update is called once per frame
    void Update()
    {

        //特定のkeyを押すとカーソルが変わる
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isColorParettePhase == false)
            {
                //フラグの変更
                isCursorChange = true;
                isColorParettePhase = true;

                colorname = "White";
                //オブジェクトを可視化
                panel.SetActive(true);
                colorPallet.SetActive(true);

                //カーソルのロックを解除＆見えるようにする
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            else
            {
                //フラグの変更
                isCursorChange = false;
                panel.SetActive(false);
                //オブジェクトを見えなくする
                colorPallet.SetActive(false);
                isColorParettePhase = false;

                // カーソルを画面内にロックする＆見えなくする
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }


        //マウスカーソルの画像の表示
        if (isCursorChange)
        {
            switch (colorname)
            {
                case "Blue":
                    //Cursor.SetCursor(aa, hotSpot, CursorMode.Auto);
                    Cursor.SetCursor(CursorImgBlue, hotSpot, CursorMode.Auto);
                    break;
                case "Red":
                    Cursor.SetCursor(CursorImgRed, Vector2.zero, CursorMode.Auto);
                    break;
                case "Yellow":
                    Cursor.SetCursor(CursorImgYellow, Vector2.zero, CursorMode.Auto);
                    break;
                case "Green":
                    Cursor.SetCursor(CursorImgGreen, Vector2.zero, CursorMode.Auto);
                    break;
                case "Pink":
                    Cursor.SetCursor(CursorImgPink, Vector2.zero, CursorMode.Auto);
                    break;
                case "White":
                    Cursor.SetCursor(CursorImgWhite, Vector2.zero, CursorMode.Auto);
                    break;
                default:
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    break;
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }


        //マウスの左クリックが押されたとき
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                colorname = hit.collider.gameObject.name;
                Debug.Log(colorname);
            }
        }

    }

    Texture2D ResizeTexture(Texture2D srcTexture, int newWidth, int newHeight)
    {
        var resizedTexture = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        Graphics.ConvertTexture(srcTexture, resizedTexture);
        return resizedTexture;
    }
}
