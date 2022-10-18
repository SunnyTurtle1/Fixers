using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    
    static ResourceManager _instance;
    public static ResourceManager Instance { get { return _instance; } }

    private GameObject obj1;
    private GameObject obj2;
    private bool isdc = false;
    private bool next = false;
    private float frameTimer = 0.2f;
    private float currentTimer;

    private void Start()
    {
        Init();
        obj1 = Resources.Load<GameObject>("Prefabs/click1");
        obj2 = Resources.Load<GameObject>("Prefabs/click2");
        

    }
    
    private void Update()
    {
        GameObject obj1Clone = GameObject.Find("click1(Clone)");
        GameObject obj2Clone = GameObject.Find("click2(Clone)");
        currentTimer += Time.deltaTime;
        

        if (MousePick.Instance.IsDoubleClick)
        {
            Vector3 a = MousePick.Instance.destination;
            a.y = 1;
            obj1.transform.position = a;
            obj2.transform.position = a;
            
           
            isdc = true;
            MousePick.Instance.IsDoubleClick = false;                       
        }
        
        
            if (isdc && next == false)
            {
                Instantiate(obj1);
                isdc = false;
                currentTimer = 0;
            }
            if (obj1Clone != null && currentTimer >= frameTimer)
            {
                Destroy(obj1Clone);
                next = true;                
            }

            if (next && isdc == false)
            {                
                Instantiate(obj2);
                next = false;
                currentTimer = 0;              
            }

            if (obj2Clone != null && currentTimer >= frameTimer)
            {
                Destroy(obj2Clone);                
                currentTimer = 0;
                //if (MousePick.Instance.destination == MousePick.Instance.transform.position) isdc = false;
                if (MousePick.Instance.isMove) isdc = true;
                else isdc = false;
            }
            

    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@ResourceManager");
            if (go == null)
            {
                go = new GameObject { name = "@ResourceManager" };
                go.AddComponent<ResourceManager>();
            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<ResourceManager>();
        }

    }
}
