using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float hp = 100;
    //攻击触发区域
    public Collider2D AttackTrigger;
    //动画
    private Animator ani;
    //是否在地面
    private bool isGround;
    //是否收到攻击
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

            //转身
            this.transform.localScale = new Vector3(horizontal > 0 ? 1 : -1, 1, 1);
            //移动
            this.transform.Translate(Vector2.right * horizontal * 1 * Time.deltaTime);
            //动画
            ani.SetBool("IsRun", true);

        }
        else
        {
            ani.SetBool("IsRun", false);
        }

        //跳跃
        if (Input.GetKeyDown(KeyCode.Space)&&isGround)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150);
        }
        //攻击 U拳
        if(Input.GetKeyUp(KeyCode.U) && horizontal == 0 && isGround)
        {
            ani.SetTrigger("Punch");
            AudioManager.Instance.PlaySound("attack");
            //this.Attack();//在animation攻击的第一帧上加动画事件
        }
        //攻击 I踢
        if (Input.GetKeyUp(KeyCode.I) && horizontal == 0 && isGround)
        {
            ani.SetTrigger("K");
            AudioManager.Instance.PlaySound("attack");

        }
        //判断是否收到伤害
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
    //发生碰撞
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
    //结束碰撞
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
