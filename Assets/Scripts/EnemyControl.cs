using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //�õ�������ã�Ҫ��λ�ã�
    private PlayerControl player;
    //����
    private Animator ani;
    private float Speed = 1;
    //״̬
    private bool isAttack = false;
    private int hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();

        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hp <= 0 || hp <= 0)
        {
            Speed = 0;
            return;
        }
        //�ƶ�
        this.transform.Translate(Vector2.right * Speed * Time.deltaTime);
        //�������Ҿ���
        float dis = Vector2.Distance(transform.position, player.transform.position);
        //�������Enemy�ǹ���״̬
        if(isAttack)
        {
            ani.SetBool("IsAttack", true);
            Speed = 0;
        }
        else if(dis < 1)
        {
            ani.SetBool("IsAttack", false);
            ani.SetBool("IsReady", true);
            Speed = 1;

        }
        else
        {
            ani.SetBool("IsReady", false);//��������˳�1m����

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            isAttack = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isAttack = false;
        }
    }
    //����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Speed = 0;
            hp = 0;
            ani.SetTrigger("Die");
            Destroy(this.GetComponent<Collider2D>());//ɾ����ײ��
            Destroy(this.gameObject, 2f);
            //����û�и��壬������Ӹ�������
            gameObject.AddComponent<Rigidbody2D>();
            AudioManager.Instance.PlaySound("hit");


        }
    }
}
