using System.Collections;
using System.Collections.Generic;
using Dreamteck;
using Dreamteck.Splines;
using UnityEngine;
using DG.Tweening;
using Cinemachine;



public class PlayerController : MonoBehaviour
{

    float Horizontal;
    [SerializeField] float _Speed;
    Animator _Animator;
    Rigidbody _RigidBody;

    private SplineFollower _spline;

    [SerializeField] Transform DetectTransform;
    [SerializeField] private float DetectionRange = 1;
    [SerializeField] LayerMask Layer;
    [SerializeField] Animator anim;



    [SerializeField] float playerSize = 1f;
    [SerializeField] AudioSource CandyPickUpSFX;
    [SerializeField] AudioClip PickUpClip;


    [SerializeField] CinemachineVirtualCamera VirtualCam;
    CinemachineTransposer Transposer;

    [SerializeField] Material mat;
    [SerializeField] Color ClaimColor;
    [SerializeField] Color defaultColor;



    [SerializeField] Material matEnemy;
    [SerializeField] Material matBoss;
    [SerializeField] Color ClaimColorEnemy;
    [SerializeField] Color defaultColorEnemy;


    [SerializeField] GameObject Enemy;




    [Header("Enemy Controller")]

    [SerializeField] Animator LittleEnemyAnimator;



    Collider[] colliders;

    public static PlayerController instance;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.6f, 0f, 0f, 0.2f);
        Gizmos.DrawSphere(DetectTransform.position, DetectionRange);

    }
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        _spline = GetComponentInParent<SplineFollower>();
        Transposer = VirtualCam.GetCinemachineComponent<CinemachineTransposer>();
    }




    void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");
        transform.localPosition += new Vector3(Horizontal * _Speed, 0, 0) * Time.deltaTime;



    }


    private void Update()
    {
        transform.localScale = new Vector3(playerSize, playerSize, playerSize);

        colliders = Physics.OverlapSphere(DetectTransform.position, DetectionRange, Layer);
        foreach (var hit in colliders)
        {
            if (hit.CompareTag("CandyToplu"))
            {
                hit.GetComponent<BoxCollider>().enabled = false;
                playerSize += 0.8f;
                Transposer.m_FollowOffset.y += 0.7f;
                Transposer.m_FollowOffset.z += 0.3f;

                CandyPickUpSFX.PlayOneShot(PickUpClip, 0.5f);
                var seq = DOTween.Sequence();
                var seq2 = DOTween.Sequence();
                seq.Append(hit.transform.DOLocalJump(new Vector3(transform.position.x, transform.position.y, transform.position.z), 2, 1, 0.2f))
                .Join(hit.transform.DOScale(1.10f, 0.2f))
                .Insert(0.2f, hit.transform.DOScale(0f, 0.2f));
                seq.AppendCallback(() => { hit.transform.localRotation = Quaternion.Euler(0, 0, 0); });
                seq2.Append(mat.DOColor(ClaimColor, "_EmissionColor", 0.15f)).Insert(0.15f, mat.DOColor(defaultColor, "_EmissionColor", 0.15f));
                Destroy(hit.gameObject, 2f);
            }

            if (hit.CompareTag("Candy"))
            {
                hit.GetComponent<BoxCollider>().enabled = false;
                playerSize += 0.15f;
                Transposer.m_FollowOffset.y += 0.3f;
                Transposer.m_FollowOffset.z += 0.1f;

                CandyPickUpSFX.PlayOneShot(PickUpClip, 0.5f);
                var seq = DOTween.Sequence();
                var seq2 = DOTween.Sequence();
                seq.Append(hit.transform.DOLocalJump(new Vector3(transform.position.x, transform.position.y, transform.position.z), 2, 1, 0.2f))
                .Join(hit.transform.DOScale(1.10f, 0.2f))
                .Insert(0.2f, hit.transform.DOScale(0f, 0.2f));
                seq.AppendCallback(() => { hit.transform.localRotation = Quaternion.Euler(0, 0, 0); });
                seq2.Append(mat.DOColor(ClaimColor, "_EmissionColor", 0.15f)).Insert(0.15f, mat.DOColor(defaultColor, "_EmissionColor", 0.15f));
                Destroy(hit.gameObject, 2f);
            }

            if (hit.CompareTag("LittleEnemy"))
            {

                var seq = DOTween.Sequence();
                seq.Append(matEnemy.DOColor(ClaimColorEnemy, "_EmissionColor", 0.2f)).Insert(0.2f, mat.DOColor(defaultColor, "_EmissionColor", 0.2f));
                hit.transform.GetComponent<Animator>().SetTrigger("Punch");
                hit.transform.GetComponent<Collider>().enabled = false;
                playerSize -= 0.4f;
            }


        }
    }

    public void HitEnemy()
    {
        var seq = DOTween.Sequence();
        seq.Append(matBoss.DOColor(ClaimColorEnemy, "_EmissionColor", 0.1f)).Join(Enemy.transform.DOShakeScale(0.1f, 1));
        seq.Append(matBoss.DOColor(defaultColorEnemy, "_EmissionColor", 0.1f)).OnComplete(() =>
        {
            Enemy.transform.DOScale(6, 1f);

        });

    }
    
}





