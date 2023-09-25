using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float hp = 100;
    //������������
    public Collider2D AttackTrigger;
    //����
    private Animator ani;
    //�Ƿ��ڵ���
    private bool isGround;
    //�Ƿ��յ�����
    private bool getHit;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            return;
        }
        //
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {

            //ת��
            this.transform.localScale = new Vector3(horizontal > 0 ? 1 : -1, 1, 1);
            //�ƶ�
            this.transform.Translate(Vector2.right * horizontal * 1 * Time.deltaTime);
            //����
            ani.SetBool("IsRun", true);

        }
        else
        {
            ani.SetBool("IsRun", false);
        }

        //��Ծ
        if (Input.GetKeyDown(KeyCode.Space)&&isGround)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150);
        }
        //���� Uȭ
        if(Input.GetKeyUp(KeyCode.U) && horizontal == 0 && isGround)
        {
            ani.SetTrigger("Punch");
            AudioManager.Instance.PlaySound("attack");
            //this.Attack();//��animation�����ĵ�һ֡�ϼӶ����¼�
        }
        //���� I��
        if (Input.GetKeyUp(KeyCode.I) && horizontal == 0 && isGround)
        {
            ani.SetTrigger("K");
            AudioManager.Instance.PlaySound("attack");

        }
        //�ж��Ƿ��յ��˺�
        if (getHit)
        {
            hp -= Time.deltaTime * 30;
            if(hp < 0)
            {
                AudioManager.Instance.StopSound();
                AudioManager.Instance.PlaySound("dead");
                ani.SetTrigger("Die");
                Destroy(GetComponent<Collider2D>());
            }
        }
    }
    //������ײ
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            ani.SetBool("IsJump", false);
        }
        if(collision.collider.tag == "Enemy")
        {
            getHit = true;
        }
    }
    //������ײ
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            ani.SetBool("IsJump", true);

        }
        if (collision.collider.tag == "Enemy")
        {
            getHit = false;
        }
    }
    public void Attack()
    {
        Invoke("AttackEnd", 0.1f);
        AttackTrigger.enabled = true;

    }
    public void AttackEnd()
    {
        AttackTrigger.enabled = false;

    }
    
}
