using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject target;
    public float speed=3.0f;
    public GameObject bulletFactory;
    public GameObject firePoint;
    public float fireTime = 1.0f;
    float curTime = 0.0f;
    public float fireTime1 = 1.5f;
    float curTime1 = 0.1f;
    public int bulletMax = 10;



    // Start is called before the first frame update
    void Start()
    {

    }

    

    // Update is called once per frame
    void Update()
    {
        AutoFire1();
        AutoFire2();
        

       
    }

    //플레이어를 향해서 총알발사
    private void AutoFire1()
    {
        if(target!=null)
        {
            curTime += Time.deltaTime;

            if (curTime > fireTime)
            {

                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.position = firePoint.transform.position;
                Vector3 dir = target.transform.position - transform.position;
                dir.Normalize();
                //총구의 방향 줜환 
                bullet.transform.up = dir;
                curTime = 0.0f;
                //transform.Translate(dir * speed * Time.deltaTime);

            }
        }
        
    }

    //회전 총알발사 
    private void AutoFire2()
    {
        if (target != null)
        {
            curTime1 += Time.deltaTime;

            if (curTime1 > fireTime1)
            {
                for(int i=0; i<bulletMax; i++)
                {
                    GameObject bullet = Instantiate(bulletFactory);
                    bullet.transform.position = firePoint.transform.position;
                    float angle = 360.0f / bulletMax;
                    Vector3 dir = target.transform.position - transform.position;
                    dir.Normalize();
                    //총구의 방향 줜환 
                    bullet.transform.eulerAngles = new Vector3(0, 0, i * angle);
                }
                
                curTime1 = 0.0f;
                //transform.Translate(dir * speed * Time.deltaTime);

            }
        }
    }
}
