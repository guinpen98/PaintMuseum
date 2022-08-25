using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    //カーソルの画像を指定
    [SerializeField] private Sprite CursorImgBlue;
    [SerializeField] private Sprite CursorImgRed;
    [SerializeField] private Sprite CursorImgYellow;
    [SerializeField] private Sprite CursorImgGreen;
    [SerializeField] private Sprite CursorImgPink;
    [SerializeField] private Sprite CursorImgWhite;

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

    //画像
    private Image Mouse_Image;
    [SerializeField] private GameObject Mouse_Image_obj;
    //Canvasの変数
    private Canvas canvas;
    //キャンバス内のレクトトランスフォーム
    private RectTransform canvasRect;
    //マウスの位置の最終的な格納先
    private Vector2 MousePos;

    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを画面内にロックする。
        Cursor.lockState = CursorLockMode.Locked;
        // マウスカーソルを消去する
        Cursor.visible = false;

        //HierarchyにあるCanvasオブジェクトを探してcanvasに入れいる
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //canvas内にあるRectTransformをcanvasRectに入れる
        canvasRect = canvas.GetComponent<RectTransform>();

        //Canvas内にあるMouseImageを探してMouse_Imageに入れる
        Mouse_Image = Mouse_Image_obj.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
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
                Mouse_Image_obj.gameObject.SetActive(true);

                //カーソルのロックを解除
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                
                //フラグの変更
                isCursorChange = false;
                panel.SetActive(false);
                //オブジェクトを見えなくする
                colorPallet.SetActive(false);
                isColorParettePhase = false;
                Mouse_Image_obj.gameObject.SetActive(false);

                // カーソルを画面内にロックする
                Cursor.lockState = CursorLockMode.Locked;
                
            }
        }


        //マウスカーソルの画像の表示
        if (isCursorChange)
        {
            //CanvasのRectTransform内にあるマウスの位置をRectTransformのローカルポジションに変換する,canvas.worldCameraはカメラ,出力先はMousePos
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out MousePos);
            //Mouse_Imageを表示する位置にMousePosを使う
            Mouse_Image.GetComponent<RectTransform>().anchoredPosition = new Vector2(MousePos.x + 25, MousePos.y + 35);
            switch (colorname)
            {
                case "Blue":
                    Mouse_Image.sprite = CursorImgBlue;
                    //Cursor.SetCursor(aa, hotSpot, CursorMode.Auto);
                    //Cursor.SetCursor(CursorImgBlue, hotSpot, CursorMode.Auto);
                    break;
                case "Red":
                    Mouse_Image.sprite = CursorImgRed;
                    //Cursor.SetCursor(CursorImgRed, Vector2.zero, CursorMode.Auto);
                    break;
                case "Yellow":
                    Mouse_Image.sprite = CursorImgYellow;
                    //Cursor.SetCursor(CursorImgYellow, Vector2.zero, CursorMode.Auto);
                    break;
                case "Green":
                    Mouse_Image.sprite = CursorImgGreen;
                    //Cursor.SetCursor(CursorImgGreen, Vector2.zero, CursorMode.Auto);
                    break;
                case "Pink":
                    Mouse_Image.sprite = CursorImgPink;
                    //Cursor.SetCursor(CursorImgPink, Vector2.zero, CursorMode.Auto);
                    break;
                case "White":
                    Mouse_Image.sprite = CursorImgWhite;
                    //Cursor.SetCursor(CursorImgWhite, Vector2.zero, CursorMode.Auto);
                    break;
                /*default:
                    Mouse_Image.sprite = CursorImgWhite;
                    //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    break;*/
            }
        }
        else
        {
            //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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

    
}
