using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject EnermyPre;
    private float timer;//¼ÆÊ±Æ÷
    private float CD = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > CD)
        {
            CD = Random.Range(1, 4);
            timer = 0;
            Instantiate(EnermyPre, transform.position, Quaternion.identity);

        }
    }
}
