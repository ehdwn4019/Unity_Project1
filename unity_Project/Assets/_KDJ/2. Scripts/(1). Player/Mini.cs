using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : MonoBehaviour
{
    //public GameObject mini;
    //public GameObject bulletFactory;
    //public float bulletSpeed=5.0f;

    public GameObject clone;
    public GameObject bulletFactory;
    public float fireTime = 3.0f;
    float curTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //mini.SetActive(false);

        //bullet = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateClone();
        AutoFire();
        //MINI();
        //
        //Debug.Log("1");
        
    }

    private void CreateClone()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            clone.SetActive(true);
        }
    }

    private void AutoFire()
    {
        //클론이 액티브 상태일때 자동발사 하기
        if(clone.activeSelf==true)
        {
            curTime += Time.deltaTime;
            if(curTime>fireTime)
            {
                curTime = 0.0f;

                GameObject bullet1 = Instantiate(bulletFactory);
                bullet1.transform.position = GameObject.Find("Mini").transform.position;
                GameObject bullet2 = Instantiate(bulletFactory);
                bullet2.transform.position = GameObject.Find("Mini1").transform.position;
                //bullet1.transform.position = clone.transform.Find("Mini").position;
                //bullet1.transform.position = clone.transform.GetChild(0).position;
                //GameObject[] bullet = new GameObject[clone.transform.childCount];
                //
                //for (int i = 0; i < clone.transform.childCount; i++)
                //{
                //    bullet[i] = Instantiate(bulletFactory);
                //    bullet[i].transform.position = clone.transform;
                //}

            }
        }
    }



    //void MINI()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        mini.SetActive(true);
    //        GameObject bullet = Instantiate(bulletFactory);
    //        //bullet.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    //        bullet.transform.position = transform.position;
    //       
    //    }
    //}
    //
    //IEnumerator MINI()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //}
}
