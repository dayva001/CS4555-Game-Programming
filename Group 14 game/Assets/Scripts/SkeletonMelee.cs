using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class SkeletonMelee : MonoBehaviour
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
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    private Rigidbody rigidBody;
    public bool canPatrol = true;
    public bool canChase = true;
    public GameObject firepoint;
    public int damage = 5;

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
        UpdateDownedPlayers();
    }

    void UpdateDownedPlayers()
    {
        for (int i = 0; i < player.Count; i++)
        {
            if (player[i].tag == "Downed")
            {
                player.Remove(player[i]);
            }
        }
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
            alreadyAttacked = true;
            agent.isStopped = true;
            Invoke(nameof(ResetAttack), animator.runtimeAnimatorController.animationClips[1].length);
        }
    }
    private Transform NearestPlayer()
    {
        Transform nearestPlayer = player[0];
        if(player.Count == 1)
            return nearestPlayer;
        for (int i = 0; i < player.Count; i++)
        {
            if (player[0].tag != "Downed" && Vector3.Distance(transform.position, player[i].position) < Vector3.Distance(transform.position, nearestPlayer.position))
                nearestPlayer=player[i];
        }
        return nearestPlayer;
    }
    private void RaycastAttack()
    {
        print("attacking");
        RaycastHit hit;
        if (Physics.Raycast(firepoint.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            if (hit.transform.tag == "Player")
            {
                hit.transform.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        agent.isStopped = false;
        RaycastAttack();
    }
}
