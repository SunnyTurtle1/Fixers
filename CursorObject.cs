using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    //[SerializeField] private CursorController.CursorType cursorType;

    //마우스가 오브젝트 안으로 들어가면 커서가 손 모양으로 바뀜
    private void OnMouseEnter()
    {
        CursorController.Instance.SetActiveCursorAnimation(CursorController.Instance.cursorAnimationList[1]);
        Debug.Log("성벽 터치");
    }

    private void OnMouseExit()
    {
        CursorController.Instance.SetActiveCursorAnimation(CursorController.Instance.cursorAnimationList[0]);
    }
}
