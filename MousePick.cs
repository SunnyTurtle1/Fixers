using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePick : MonoBehaviour
{
    static MousePick _instance;
    public static MousePick Instance { get { return _instance; } }

    public float moveSpeed = 20.0f;       
    public float DoubleClickSecond = 0.25f;
    private bool IsOneClick = false;
    private double Timer = 0;    
    public bool isMove;
    public Vector3 destination;
    public bool IsDoubleClick = false;
    public Camera mainCamera;
    public float view = 60;


    void Start()
    {
        Init();
    }

    
    void Update()
    {       
        DoubleClicked();
        Move();
        Debug.Log(destination);

        Vector2 MousePosition = Input.mousePosition;

        if ((MousePosition.x <= 0) || (MousePosition.y <= 0)
             || (MousePosition.x >= Screen.width) || (MousePosition.y >= Screen.height))
        {
            MoveScreen(MousePosition);
        }
    }

    #region ����Ŭ�� �ν�
    public void DoubleClicked()
    {
        if (IsOneClick && ((Time.time - Timer) > DoubleClickSecond))
        {
            IsOneClick = false;
            IsDoubleClick = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!IsOneClick)
            {
                Timer = Time.time;
                IsOneClick = true;
                IsDoubleClick = false;
            }
            else if (IsOneClick && ((Time.time - Timer) < DoubleClickSecond))
            {
                Debug.Log("Double Click");
                //if (ResourceManager.Instance != null) ResourceManager.Instance.Destination(destination);
                IsDoubleClick = true;

                IsOneClick = false;
                
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    destination = hit.point;
                    isMove = true;
                    
                }
                
            }
        }
    }
    #endregion ����Ŭ�� �ν�

    #region �������Ʈ �̵�
    public void Move()
    {
        
        if (isMove)
        {
            bool isAlived = Vector3.Distance(destination, transform.position) <= 0.1f;
            if (isAlived)
            {
                isMove = false;
                                
            }
            else
            {
                //Vector3 direction = destination - transform.position;
                //transform.forward = direction;
                //transform.position += direction.normalized * moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);
                mainCamera.fieldOfView = view;
            }
        }
    }
    #endregion �������Ʈ �̵�


    #region ȭ��𼭸� �̵�
    private void MoveScreen(Vector2 MousePosition)
    {
        if (MousePosition.x <= 0)
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed;

        else if (MousePosition.y <= 0)
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * moveSpeed;

        else if (MousePosition.x >= Screen.width)
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed;

        else if (MousePosition.y >= Screen.height)
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed;

        else
            return;
    }
    #endregion ȭ�� �𼭸� �̵�

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("Target");
            if (go == null)
            {
                go = new GameObject { name = "Target" };
                go.AddComponent<MousePick>();
            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<MousePick>();
        }

    }

}
