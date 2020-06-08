using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    Material mat;
    public float scrollSpeed = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {

        mat=GetComponent<Renderer>().material;

       //mat = GetComponent<Material>();
       //offset = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //offset = offset * scrollSpeed * Time.deltaTime;
        //
        //BackGroundScroll();
        //
        //mat.GetTextureOffset("bg");
        //mat.SetTextureOffset("bg", offset);
        BackGroundScroll();
    }

    private void BackGroundScroll()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.Set(0, offset.y+(scrollSpeed*Time.deltaTime));
        mat.mainTextureOffset = offset;
    }
}
