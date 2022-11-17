using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timeManager : MonoBehaviour
{
     [SerializeField]float TimeCount;
    [SerializeField] Text timeText;
    

    void Update()
    {
       
        timeText.text = TimeCount.ToString("00");
        
       TimeCount -= Time.deltaTime;
        if (TimeCount <= 0)
        {
            TimeCount =0;
            // Time.timeScale = 0;
        }
    }
}
