using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    //人物状态机

    public enum PlayerState
    {
        idle,
        run,
        death
    }
    
    private Animator _animator;
    //人物属性
    public float Health = 100.0f; //血量
    public float currentHealth;
    public float Power = 10.0f;//攻击力
    public float Defense = 10.0f;//防御

    public float moveSpeed = 2.0f;
    public float jumpPower = 0.0f;
    void Start()
    {
        currentHealth = Health;
        _animator = this.GetComponent<Animator>();


    }

    public void Attacked(float damage)
    {
        currentHealth -= damage;
        

    }

    void Update()
    {
        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
        //transform.Translate(h * Time.deltaTime * moveSpeed, 0, v * Time.deltaTime * moveSpeed );
        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        //transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));

        //状态转换

        if (currentHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetBool("isMove", true);

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                _animator.SetBool("isMove", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetBool("isJump", true);
                jumpPower = 0.05f;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _animator.SetBool("isJump", false);
                jumpPower = 0.0f;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = 5.0f;
                _animator.SetBool("isRun", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = 2.0f;
                _animator.SetBool("isRun", false);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _animator.SetBool("isAttack", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _animator.SetBool("isAttack", false);
            }
        }
        
        //if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    _animator.SetBool("isRun", true);
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    _animator.SetBool("isRun", false);
        //}
    }
}