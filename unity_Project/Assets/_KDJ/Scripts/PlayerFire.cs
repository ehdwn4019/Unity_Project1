using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;  //총알 프리팹 
    public GameObject firePoint;       //총알 발사위치 

    LineRenderer lr;
    public float rayTime = 0.3f;
    float curTime = 0.0f;
    public float fireTime;

    RaycastHit hit;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        //게임 오브젝트는 활성화 비활성화 -> SetActive()함수 사용
        //컴포넌트는 enabled 속성 사용 

    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
        FireRay();
        if (lr.enabled) ShowRay();

    }

    private void ShowRay()
    {
        curTime += Time.deltaTime;

        if (curTime > fireTime)
        {
            lr.enabled = false;
            curTime = 0.0f;
        }
    }

    //총알발사 
    private void Fire()
    {
        //마우스 왼쪽 버튼 or 왼쪽 컨트롤 키 
        if (Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);

            bullet.transform.position = firePoint.transform.position;

        }


    }

    //레이저 발사 
    private void FireRay()
    {
        
        //마우스 왼쪽 버튼 or 왼쪽 컨트롤 키 
        if (Input.GetButtonDown("Fire1"))
        {
            
            //라인렌더러 컴포넌트 활성화
            lr.enabled = true;
            //라인 시작점,끝점
            Vector3 pos = transform.position;
            lr.SetPosition(0, transform.position);
            //lr.SetPosition(1, transform.position + Vector3.up * 10);
            //라인의 끝점은 충돌된 지점으로 변경한다.

            //Ray로 충돌처리 
            Ray ray = new Ray(transform.position, Vector3.up);
            RaycastHit hitInfo; //Ray와 충돌된 오브젝트의 정보를 담는다 
            //Ray랑 충돌된 오브젝트가 있다.
            if (Physics.Raycast(ray, out hitInfo))
            {
                //레이저의 끝점 지정
                lr.SetPosition(1, hitInfo.point);
                
                //디스트로이존의 탑과는 충돌처리 되지 않도록 한다 
                if(hitInfo.collider.name !="Top")
                {
                    Destroy(hitInfo.collider.gameObject);
                }

                ////충돌된 오브젝트 삭제
                /////프리팹으로 만든 오브젝트 같은경우는 생성될때 클론으로 생성된다
                //if(hitInfo.collider.name.Contains =="Enemy")
                //{
                //    Destroy(hitInfo.collider.gameObject);
                //}
            }
            else
            {
                lr.SetPosition(1, transform.position + Vector3.up * 10);
            }

        }
        
       
        
    }

    

}
