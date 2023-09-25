using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //�����Ŀ��
    public Transform target;
    //������ұ߽�
    public float MaxX;
    public float MinX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ȡ���λ��
        Vector3 v = transform.position;
        v.x=target.position.x;
        //�߽��ж�
        if(v.x > MaxX)
        {
            v.x = MaxX;
        }
        if(v.x < MinX)
        {
            v.x = MinX;
        }
        //�ǵð�ֵ��ֵ��ȥ
        transform.position = v;
    }
}
