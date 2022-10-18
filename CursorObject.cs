using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorObject : MonoBehaviour
{
    //[SerializeField] private CursorController.CursorType cursorType;

    //���콺�� ������Ʈ ������ ���� Ŀ���� �� ������� �ٲ�
    private void OnMouseEnter()
    {
        CursorController.Instance.SetActiveCursorAnimation(CursorController.Instance.cursorAnimationList[1]);
        Debug.Log("���� ��ġ");
    }

    private void OnMouseExit()
    {
        CursorController.Instance.SetActiveCursorAnimation(CursorController.Instance.cursorAnimationList[0]);
    }
}
