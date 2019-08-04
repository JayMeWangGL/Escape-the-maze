using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public enum EnemyState
    {
        idle,
        run,
        attack,
        death
    }
    //初始状态
    public EnemyState CurrentState = EnemyState.idle;

    //动画控制器
    private Animator _animator;

    //玩家
    private Transform Player;

    //导航
    private NavMeshAgent agent;

   private PlayerController playercontroller;
    //敌人属性
    private float health = 100.0f;
    public float power = 5.0f;
    public float currentHealth;

    
    void Start()
    {
        currentHealth = health;
        _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;
        playercontroller = gameObject.GetComponent<PlayerController>();
    }

    public float GetHealthRate()
    {
        return (float)currentHealth / (float)health;
    }

    //受到攻击
    public void Attacked(float damage)
    {
        currentHealth -= damage;
        
    }

    
    void Update()
    {

        float distance = Vector3.Distance(Player.position, transform.position);
        switch (CurrentState)
        {
            case EnemyState.idle:
                if (distance > 3 && distance <= 10 && currentHealth>0)
                {
                    CurrentState = EnemyState.run;
                }
                if (distance < 3 && currentHealth > 0)
                {
                    CurrentState = EnemyState.attack;
                    

                }
                if (currentHealth <= 0)
                {
                    CurrentState = EnemyState.death;
                }
                _animator.Play("Idle");
                agent.isStopped = true;
                break;

            case EnemyState.run:
                if (distance > 10 && currentHealth > 0)
                {
                    CurrentState = EnemyState.idle;
                }
                if (distance < 3 && currentHealth > 0)
                {
                    CurrentState = EnemyState.attack;
                }
                if (currentHealth <= 0)
                {
                    CurrentState = EnemyState.death;
                }
                _animator.Play("Run");
                agent.isStopped = false;
                agent.SetDestination(Player.position);
                break;
            case EnemyState.attack:
                if (distance >= 3 && currentHealth > 0)
                {
                    CurrentState = EnemyState.run;
                }
                if (currentHealth <= 0)
                {
                    CurrentState = EnemyState.death;
                }
                _animator.Play("Attack(1)");
                agent.isStopped = false;
                agent.SetDestination(Player.position);
                
                break;

            case EnemyState.death:
                
                _animator.Play("Death Shooting");
                break;
        }
        
    }
}
