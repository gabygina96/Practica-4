using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;
    private Shooter daño;
    private LifeBar player;
    public int vida = 3;
    public int muerte = 0;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        enemyAgent.SetDestination(playerTransform.position);
        Debug.Log("Distance to player: " +
            enemyAgent.remainingDistance);
        if (enemyAgent.remainingDistance <= 1f &&
            enemyAgent.hasPath)
        {
            enemyAnimator.SetFloat("Speed", 0f);
            enemyAnimator.SetBool("Punch", true);
        }
        else
            enemyAnimator.SetFloat("Speed", enemyAgent.speed);
    }

     void OnTriggerEnter(Collider colision){
        if (colision.tag == "Bullet") {
            muerte += 1;
            Destroy(colision.gameObject);
            if(vida == muerte){
                StartCoroutine ("removeEnemy");
            }
        }
    }
     IEnumerator removeEnemy(){
        enemyAnimator.SetTrigger("Dead");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
