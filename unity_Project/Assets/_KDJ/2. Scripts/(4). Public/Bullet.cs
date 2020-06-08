using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    GameObject player;
    GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
       player = GetComponent<GameObject>();
       boss = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        ////if (boss.transform.CompareTag("BOSS"))
        ////    transform.Translate(-transform.up* speed * Time.deltaTime);
        //if(player.transform.CompareTag("PLAYER")) transform.Translate(Vector3.up * speed * Time.deltaTime);
        ////
        //if (boss.transform.CompareTag("BOSS")) transform.Translate(Vector3.down * speed * Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    //IEnumerator BossBullet()
    //{
    //
    //}
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

    
}
