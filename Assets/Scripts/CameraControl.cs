using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //跟随的目标
    public Transform target;
    //相机左右边界
    public float MaxX;
    public float MinX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //获取相机位置
        Vector3 v = transform.position;
        v.x=target.position.x;
        //边界判断
        if(v.x > MaxX)
        {
            v.x = MaxX;
        }
        if(v.x < MinX)
        {
            v.x = MinX;
        }
        //记得把值赋值回去
        transform.position = v;
    }
}
