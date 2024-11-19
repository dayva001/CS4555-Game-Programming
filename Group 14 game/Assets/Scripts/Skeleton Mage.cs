using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class SkeletonMage : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Transform> player;
    public LayerMask whatIsGround, whatIsPlayer;
    //Patroling
    public Vector3 walkPoint;
    public Vector3 walkDirection;
    public float walkPointRange;
    public bool walkPointSet;
    private Animator animator;
    public GameObject firingLocation;
    //Attacking
    public float timeBetweenAttacks = 1.5f;
    bool alreadyAttacked;
    public GameObject projectile;
    private Rigidbody rigidBody;
    public bool canPatrol = true;
    public bool canChase = true;

    //States
    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectsWithTag("Player").Select(go => go.transform).ToList();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange && canPatrol) Patroling();
        if (playerInSightRange && !playerInAttackRange && canChase) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
        SetAnimations();
    }

    private void SetAnimations()
    {

        if (agent.remainingDistance < 0.1f || rigidBody.velocity == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }
    }

    void Patroling()
    {
            if (!walkPointSet) SearchWalkPoint();
            if (walkPointSet)
                agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //walkpoint reached
            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
    }

    private void SearchWalkPoint()
    {

        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    void ChasePlayer()
    {
        Transform nearestPlayer = NearestPlayer();
        agent.SetDestination(nearestPlayer.position);
        Vector3 direction = (nearestPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(NearestPlayer().position);

        if (!alreadyAttacked)
        {
            //attack code here
            animator.SetTrigger("Attacking");
            StartCoroutine(InstantiateProjectileAfterAnimation());
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), animator.runtimeAnimatorController.animationClips[2].length);
        }
    }
    private IEnumerator InstantiateProjectileAfterAnimation()
    {
        agent.isStopped = true;
            yield return new WaitForSeconds(timeBetweenAttacks);
            Quaternion arrowAngle = Quaternion.LookRotation((NearestPlayer().transform.position + new Vector3(0f, 0.5f, 0f)) - firingLocation.GetComponent<Transform>().position);
            GameObject arrow = Instantiate(projectile, firingLocation.GetComponent<Transform>().position, arrowAngle);
    }
    private Transform NearestPlayer()
    {
        Transform nearestPlayer = player[0];
        for (int i = 0; i < player.Count; i++)
        {
            if (Vector3.Distance(transform.position, player[i].position) < Vector3.Distance(transform.position, nearestPlayer.position))
                nearestPlayer=player[i];
        }
        return nearestPlayer;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        agent.isStopped = false;
    }
}
