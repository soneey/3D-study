using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Cams//미리 정의되어야만 하는 데이터
{
    MainCam,
    SubCam1,
    SubCam2,
    SubCam3,
}

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] List<Camera> listCam;
    [SerializeField] List<Button> listBtns;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    void Start()
    {
        //int enumCount = System.Enum.GetValues(typeof(Cams)).Length;
        //int intEnum = (int)Cams.MainCam;
        //Cams enumData = (Cams)intEnum;//인트를 이넘으로

        //string stringEnum = Cams.MainCam.ToString();
        //enumData = (Cams)System.Enum.Parse(typeof(Cams), stringEnum);//스트링을 이넘으로

        switchCamera(Cams.MainCam);
        initBtns();
    }

    private void initBtns()//람다식을 통해 데이터 전달
    {
        //listBtns[0].onClick.AddListener(() => switchCamera(0));
        //listBtns[1].onClick.AddListener(() => switchCamera(1));
        //listBtns[2].onClick.AddListener(() => switchCamera(2));
        //listBtns[3].onClick.AddListener(() => switchCamera(3));
        int count = listBtns.Count;
        for (int iNum = 0; iNum < count; iNum++)//람다식이 for문을 만났을때 조건이되는 변수가 계속 변하는게 
            //그 변하는 데이터의 주소를 계속 전달하기 때문에 문제를 야기
        {
            int num = iNum;
            listBtns[num].onClick.AddListener(() => switchCamera(num));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            switchCamera(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            switchCamera(3);
        }
    }


    //기능:매개변수로 전달받은 카메라는 켜주고, 나머지 카메라는 꺼줍니다.
    private void switchCamera(Cams _value)
    {
        int count = listCam.Count;
        int findNum = (int)_value;
        for (int iNum = 0; iNum < count; iNum++)
        {
            Camera cam = listCam[iNum];
            //if (iNum == findNum)
            //{
            //    cam.enabled = true;
            //}
            //else
            //{
            //    cam.enabled = false;
            //}
            cam.enabled = iNum == findNum;
        }
    }
    private void switchCamera(int _value)
    {
        int count = listCam.Count;
        for (int iNum = 0; iNum < count; iNum++)
        {
            Camera cam = listCam[iNum];
            cam.enabled = iNum == _value;
        }
    }
}
