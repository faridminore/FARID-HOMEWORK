using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject CameraMain;
    [SerializeField] GameObject Guide;

    public void camerachanger()
    {
        Guide.SetActive(true);
        CameraMain.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
