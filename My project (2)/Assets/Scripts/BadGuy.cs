using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class BadGuy : MonoBehaviour
{
    [SerializeField] bool isFinished = true;
   
    [SerializeField] Vector3 randomDestination;
    Rigidbody rb;
    NavMeshAgent navmeshAgent;
    Animator anim;
    [SerializeField] GameObject EmptyBasket,FullBasket;




    void Start()
    {
        anim = GetComponent<Animator>();
        navmeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (this.gameObject.CompareTag("Scared"))
        {
            
            EmptyBasket.SetActive(true);
            FullBasket.SetActive(false);
            anim.SetBool("Goofy",true);
            navmeshAgent.speed = 8;
            Destroy(this.gameObject,3f);
        }

        if (isFinished)
        {
            randomDestination = RandomVector();
        }
        

        if (transform.position.x != randomDestination.x && transform.position.z != randomDestination.z)
        {
            
            navmeshAgent.SetDestination(randomDestination);
            isFinished = false;
        }

        else
        {
            isFinished = true;
        }
    }
    public Vector3 RandomVector()
    {
        Vector3 newDestination = new Vector3(Random.Range(-27, 30), 0, Random.Range(-30, -25));
        return newDestination;
    }





}
