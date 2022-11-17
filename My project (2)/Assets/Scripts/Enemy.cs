using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    bool playerDeath = false;
  
    [SerializeField] GameObject Player;
    
    Animator animatorEnemy;
    [SerializeField] Animator AnimatorPlayer;

    void Start()
    {
      
        animatorEnemy = GetComponent<Animator>();
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) < 7 && !playerDeath)
        {

            StartCoroutine(SizeCheck());
            animatorEnemy.SetBool("Walk", false);
            animatorEnemy.SetBool("Punch", true);
            AnimatorPlayer.SetBool("Punch", true);  //dayanir




        }
        else
        {
            AnimatorPlayer.SetBool("Punch", false);
            animatorEnemy.SetBool("Punch", false);
             //gelir
            
        }

    }
    IEnumerator SizeCheck()
    {

        if (Player.transform.localScale.x > 4.5f && Player.transform.localScale.y > 4.5f && Player.transform.localScale.z > 4.5f)
        {
        yield return new WaitForSeconds(6f);
            animatorEnemy.SetBool("Punch", false);  //Player Win
            animatorEnemy.SetBool("Death", true);
            AnimatorPlayer.SetBool("Punch", false);
            AnimatorPlayer.SetBool("Victory",true);
            UImanager.instance.hidejoystick();
            yield return new WaitForSeconds(5f);
            UImanager.instance.GameOver();
        }
        else
        {
            yield return new WaitForSeconds(4f);
            animatorEnemy.SetBool("Victory", true); //Player Death 
            AnimatorPlayer.SetBool("Punch", false);
            AnimatorPlayer.SetBool("Death", true);
            playerDeath = true;
            UImanager.instance.hidejoystick();
            yield return new WaitForSeconds(5f);
            UImanager.instance.GameOver();
        }
    }


    
}


