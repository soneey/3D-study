using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo : MonoBehaviour
{
    private void Start()
    {

    }

    private void Update()
    {
        mouseFunction();
        //transform.position += transform.forward * Time.deltaTime;//전방으로 이동

        //transform.position += Rotation * transform.position;  // ??
        //transform.position += Vector3.forward * Time.deltaTime;
        //transform.position += transform.rotation * Vector3.forward * Time.deltaTime;
        //transform.position += transform.TransformDirection(Vector3.forward);
    }
    private void mouseFunction()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.lockState == CursorLockMode.None)//마우스가 보이고 조절가능한 상태
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            { 
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    //스크립트를 가진 "오브젝트 기준" 회전값을 기준으로 방향
    //transform.up;//down
    //transform.forward;//back
    //transform.right;//left

    //글로벌 포지션 기준으로 방향
    //Vector3.up;
    //Vector3.forward;
    //Vector3.right;
}
