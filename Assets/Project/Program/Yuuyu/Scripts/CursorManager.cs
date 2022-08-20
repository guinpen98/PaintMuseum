using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    //�J�[�\���̉摜���w��
    [SerializeField] public Texture2D CursorImgBlue;
    [SerializeField] public Texture2D CursorImgRed;
    [SerializeField] public Texture2D CursorImgYellow;
    [SerializeField] public Texture2D CursorImgGreen;
    [SerializeField] public Texture2D CursorImgPink;
    [SerializeField] public Texture2D CursorImgWhite;

    [SerializeField] public int size;
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

    // Start is called before the first frame update
    void Start()
    {
        // �}�E�X�J�[�\������ʓ��Ƀ��b�N����B
        Cursor.lockState = CursorLockMode.Locked;
        // �}�E�X�J�[�\������������
        Cursor.visible = false;

        //aa= ResizeTexture(CursorImgBlue, size, size);
        //CursorImgBlue = aa;
    }

    // Update is called once per frame
    void Update()
    {

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

                //�J�[�\���̃��b�N��������������悤�ɂ���
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            else
            {
                //�t���O�̕ύX
                isCursorChange = false;
                panel.SetActive(false);
                //�I�u�W�F�N�g�������Ȃ�����
                colorPallet.SetActive(false);
                isColorParettePhase = false;

                // �J�[�\������ʓ��Ƀ��b�N���違�����Ȃ�����
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }


        //�}�E�X�J�[�\���̉摜�̕\��
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

    Texture2D ResizeTexture(Texture2D srcTexture, int newWidth, int newHeight)
    {
        var resizedTexture = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        Graphics.ConvertTexture(srcTexture, resizedTexture);
        return resizedTexture;
    }
}
