using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class touchdetector : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject Guide;
   public void OnPointerDown(PointerEventData pointerEventData)
    {

        
        Guide.SetActive(false);
    }

   
}
