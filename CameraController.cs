using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    /*  <ī�޶� ��Ʈ�ѷ� ��� ����>
     * 1. ���콺�� -> ����, �ܾƿ�
     * 2. ���� Ŭ�� -> ĳ���� -> ĳ���� ��ġ��
     * 3. ���� Ŭ�� -> ���� -> Ŭ���� ��ġ�� ��
     * 4. ȭ�� �׵θ��� ���콺 ��ġ�� -> ī�޶� �̵� (���̽�ƽó��)
     */

    private float wheelspeed = 20.0f;
    public Camera mainCamera;    
    public float CamMoveSpeed = 30.0f;
   
    public GameObject Target; //ȭ�� ���߾ӿ� ��ġ�� �� ���ӿ�����Ʈ
    Vector3 TargetPos;

    //ī�޶� ��ġ ������
    public float offsetX = 0.0f;
    public float offsetY = 10.0f;
    public float offsetZ = -10.0f;

    //���� �ܾƿ� ���� ����
    public float ZoomIn = 0.5f;
    public float ZoomOut = 100.0f;
       
       
    void Update()
    {       
         Zoom();
        
        //ī�޶� �� ����, �ܾƿ�            
    }

    private void FixedUpdate()
    {
        //����Ŭ��, ���콺 ȭ�� �׵θ� ��ġ�ÿ� �������Ʈ ������ -> ī�޶� ����
        TargetPos = new Vector3(Target.transform.position.x + offsetX,
                                Target.transform.position.y + offsetY,
                                Target.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CamMoveSpeed);
    }

    #region ����,�ܾƿ�
    private void Zoom()
    {        
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * wheelspeed;
        if (distance != 0)
            mainCamera.fieldOfView += distance;
        if (mainCamera.fieldOfView < ZoomIn)
            mainCamera.fieldOfView = ZoomIn;
        if (mainCamera.fieldOfView > ZoomOut)
            mainCamera.fieldOfView = ZoomOut;

        
    }
    #endregion ����,�ܾƿ�   

}
