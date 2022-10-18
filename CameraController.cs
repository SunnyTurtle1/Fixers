using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    /*  <카메라 컨트롤러 기능 구현>
     * 1. 마우스휠 -> 줌인, 줌아웃
     * 2. 더블 클릭 -> 캐릭터 -> 캐릭터 위치로
     * 3. 더블 클릭 -> 지형 -> 클릭한 위치로 줌
     * 4. 화면 테두리에 마우스 위치시 -> 카메라 이동 (조이스틱처럼)
     */

    private float wheelspeed = 20.0f;
    public Camera mainCamera;    
    public float CamMoveSpeed = 30.0f;
   
    public GameObject Target; //화면 정중앙에 위치한 빈 게임오브젝트
    Vector3 TargetPos;

    //카메라 위치 고정값
    public float offsetX = 0.0f;
    public float offsetY = 10.0f;
    public float offsetZ = -10.0f;

    //줌인 줌아웃 범위 설정
    public float ZoomIn = 0.5f;
    public float ZoomOut = 100.0f;
       
       
    void Update()
    {       
         Zoom();
        
        //카메라 휠 줌인, 줌아웃            
    }

    private void FixedUpdate()
    {
        //더블클릭, 마우스 화면 테두리 위치시에 빈오브젝트 움직임 -> 카메라 추적
        TargetPos = new Vector3(Target.transform.position.x + offsetX,
                                Target.transform.position.y + offsetY,
                                Target.transform.position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CamMoveSpeed);
    }

    #region 줌인,줌아웃
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
    #endregion 줌인,줌아웃   

}
