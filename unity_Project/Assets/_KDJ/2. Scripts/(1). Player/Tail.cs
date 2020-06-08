using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{

    public GameObject target;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        //타겟 방향 구하기(벡타의 뺄셈)
        //방향 = 타겟 - 자기자신 
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
