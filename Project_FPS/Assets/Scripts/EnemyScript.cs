using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private GameObject Player;
    private NavMeshAgent agent;
    public float attackRange;
    public float enemySpeed;
    public int enemyHealth;
    public Animator animator;

    public BodyPartScript[] AllBodyParts;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.transform.position);

        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) < attackRange)
        {
            animator.SetBool("Attack", true);
            agent.speed = 0f;
        }
        else
        {
            animator.SetBool("Attack", false);
            agent.speed = enemySpeed;
        }
    }

    public void TakeDamage()
    {
        enemyHealth -= 1;
        animator.SetTrigger("Hit");
        if (enemyHealth == 0)
        {
            foreach (var item in AllBodyParts)
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().AddForce(-transform.forward * 2000f);
                item.GetComponent<Rigidbody>().AddForce(0,2000f,0);
            }
            Destroy(gameObject,5f);

            agent.enabled = false;
            animator.enabled = false;
            this.enabled = false;
        }
    }
}
