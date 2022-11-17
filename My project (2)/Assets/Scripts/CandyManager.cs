using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CandyManager : MonoBehaviour
{
    void Start()
    {
       

        transform.DOLocalRotate(new Vector3(0,180,0),1f).SetLoops(-1,LoopType.Incremental);
        
    }

    
}
