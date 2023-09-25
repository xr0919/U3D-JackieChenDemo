using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    //拿到玩家引用（要拿位置）
    private PlayerControl player;
    //动画
    private Animator ani;
    private float Speed = 1;
    //状态
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
        //移动
        this.transform.Translate(Vector2.right * Speed * Time.deltaTime);
        //计算和玩家距离
        float dis = Vector2.Distance(transform.position, player.transform.position);
        //如果现在Enemy是攻击状态
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
            ani.SetBool("IsReady", false);//假如玩家退出1m距离

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
    //死亡
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Speed = 0;
            hp = 0;
            ani.SetTrigger("Die");
            Destroy(this.GetComponent<Collider2D>());//删除碰撞器
            Destroy(this.gameObject, 2f);
            //本来没有刚体，打死后加刚体下落
            gameObject.AddComponent<Rigidbody2D>();
            AudioManager.Instance.PlaySound("hit");


        }
    }
}
