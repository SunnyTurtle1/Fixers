using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    static CursorController _instance;
    public static CursorController Instance { get { return _instance; } }

    public List<CursorAnimation> cursorAnimationList;



    public CursorAnimation cursorAnimation;

    private int currentFrame;
    private float frameTimer;
    private int frameCount;

    public enum CursorType
    {
        Arrow,
        Grab
    }

    public void Start()
    {
        SetActiveCursorAnimation(cursorAnimationList[0]);
        Init();
        
    }
    
    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0f)
        {
            frameTimer += cursorAnimation.frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorAnimation.textureArray[currentFrame],cursorAnimation.offset, CursorMode.Auto);
        }
               
        //if (gameObject.CompareTag("Wall")) SetActiveCursorAnimation(cursorAnimationList[1]);         
              
    }

    public void SetActiveCursorAnimation(CursorAnimation cursorAnimation)
    {
        this.cursorAnimation = cursorAnimation;
        currentFrame = 0;
        frameTimer = cursorAnimation.frameRate;
        frameCount = cursorAnimation.textureArray.Length;
    }

    [System.Serializable]
    public class CursorAnimation
    {
        public CursorType cursorType;
        public Texture2D[] textureArray;
        public float frameRate;
        public Vector2 offset;

    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@CursorManager");
            if (go == null)
            {
                go = new GameObject { name = "@CursorManager" };
                go.AddComponent<CursorController>();
            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<CursorController>();
        }
        
    }
       
}
