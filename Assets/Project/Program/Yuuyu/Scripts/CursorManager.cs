using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    //�J�[�\���̉摜���w��
    [SerializeField] private Sprite CursorImgBlue;
    [SerializeField] private Sprite CursorImgRed;
    [SerializeField] private Sprite CursorImgYellow;
    [SerializeField] private Sprite CursorImgGreen;
    [SerializeField] private Sprite CursorImgPink;
    [SerializeField] private Sprite CursorImgWhite;

    //�J�[�\���̉摜�̕ύX�t���O
    private bool isCursorChange=false;

    //�J���[�p���b�g��ʂ̕ύX�t���O
    private bool isColorParettePhase = false;
    //�F�̎���
    [SerializeField] public string colorname;
    //�J�������擾
    [SerializeField] public Camera camera_object;
    //���C�L���X�g�������������̂��擾������ꕨ
    private RaycastHit hit;

    //����̃{�^�����������ۂ̉�ʂ̕ύX
    [SerializeField] public GameObject panel;

    //�J���[�p���b�g�̃I�u�W�F�N�g
    [SerializeField] public GameObject colorPallet;

    //�J�[�\���̃X�|�b�g�_�̐ݒ�
    private Vector2 hotSpot = new Vector2(0,0);

    //�摜
    private Image Mouse_Image;
    [SerializeField] private GameObject Mouse_Image_obj;
    //Canvas�̕ϐ�
    private Canvas canvas;
    //�L�����o�X���̃��N�g�g�����X�t�H�[��
    private RectTransform canvasRect;
    //�}�E�X�̈ʒu�̍ŏI�I�Ȋi�[��
    private Vector2 MousePos;

    // Start is called before the first frame update
    void Start()
    {
        // �}�E�X�J�[�\������ʓ��Ƀ��b�N����B
        Cursor.lockState = CursorLockMode.Locked;
        // �}�E�X�J�[�\������������
        Cursor.visible = false;

        //Hierarchy�ɂ���Canvas�I�u�W�F�N�g��T����canvas�ɓ��ꂢ��
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //canvas���ɂ���RectTransform��canvasRect�ɓ����
        canvasRect = canvas.GetComponent<RectTransform>();

        //Canvas���ɂ���MouseImage��T����Mouse_Image�ɓ����
        Mouse_Image = Mouse_Image_obj.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        //�����key�������ƃJ�[�\�����ς��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isColorParettePhase == false)
            {
                
                //�t���O�̕ύX
                isCursorChange = true;
                isColorParettePhase = true;

                colorname = "White";
                //�I�u�W�F�N�g������
                panel.SetActive(true);
                colorPallet.SetActive(true);
                Mouse_Image_obj.gameObject.SetActive(true);

                //�J�[�\���̃��b�N������
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                
                //�t���O�̕ύX
                isCursorChange = false;
                panel.SetActive(false);
                //�I�u�W�F�N�g�������Ȃ�����
                colorPallet.SetActive(false);
                isColorParettePhase = false;
                Mouse_Image_obj.gameObject.SetActive(false);

                // �J�[�\������ʓ��Ƀ��b�N����
                Cursor.lockState = CursorLockMode.Locked;
                
            }
        }


        //�}�E�X�J�[�\���̉摜�̕\��
        if (isCursorChange)
        {
            //Canvas��RectTransform���ɂ���}�E�X�̈ʒu��RectTransform�̃��[�J���|�W�V�����ɕϊ�����,canvas.worldCamera�̓J����,�o�͐��MousePos
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out MousePos);
            //Mouse_Image��\������ʒu��MousePos���g��
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


        //�}�E�X�̍��N���b�N�������ꂽ�Ƃ�
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
