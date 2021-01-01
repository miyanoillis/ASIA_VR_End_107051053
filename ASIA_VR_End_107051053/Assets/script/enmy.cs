
using UnityEngine.AI;
using UnityEngine;

public class enmy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nav;
    public Animator ani;
    public float cd = 2f;
    private float timer;

    [Header("speed") ,Range(0f,50f)]
    public float spd = 3;
    [Header("distance"), Range(0f, 50f)]
    public float spdstop = 1;


    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        //player = GameObject.Find("Player").transform;
        nav.speed = spd;
        nav.stoppingDistance = spdstop;
    }

    public void Update()
    {
        track();
        attack();
    }

    public void attack()
    {
        if(nav.remainingDistance < spdstop)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;
            pos.y = player.position.y;
            transform.LookAt(pos);

            if (timer >= cd)
            {
            ani.SetTrigger("atk");
                timer = 0;
            }
        }
    }

    public void track()
    {
        nav.SetDestination(player.position);
        ani.SetBool("walk" ,nav.remainingDistance> spdstop);
    }
}
