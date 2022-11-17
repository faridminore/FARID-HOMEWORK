using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class GoodGuyController : MonoBehaviour
{
    [SerializeField] GameObject[] Transforms;
    Animator anim;
    NavMeshAgent navMesh;
    GameObject Player;
    Transform currentTransform;
    int RandomNumber;

    void Start()
    {
        Transforms = GameObject.FindGameObjectsWithTag("House");
        RandomNumber = Random.Range(0,Transforms.Length);
        anim = GetComponent<Animator>();

        Player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!transform.CompareTag("Given"))
        {
            navMesh.SetDestination(Player.transform.position);
            anim.SetBool("Walk",true);
         
        if (Vector3.Distance(transform.position,Player.transform.position)< 3.5f)
        {
            anim.SetBool("Walk",false);
            
        }
            
            
        }
        else
        {
            anim.SetBool("Run",true);
            navMesh.speed = 9;
            navMesh.SetDestination(Transforms[RandomNumber].transform.position);


        }


        
    }

   
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("House"))
        {
            Destroy(this.gameObject);
            
        }
    }
}
