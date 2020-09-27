using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotate : MonoBehaviour
{
    [HideInInspector]public float ytimer;
    public float yHeight;
    public float Rot;
    public float ySpeed;
    public float rotspeed;
    [HideInInspector]public float rottimer;

    // Start is called before the first frame update
    void Start()
    {
        ytimer = 0f;
        rottimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 30;
        ytimer = ytimer + ySpeed;
        Vector3 pos = transform.position;
        pos.y = (yHeight *(Mathf.Sin(ytimer * 2)));
        transform.position = pos;
        rottimer = rottimer + rotspeed;
        Quaternion rot = transform.rotation;
        rot.z = (Rot * (Mathf.Sin(rottimer * 2)));
        transform.rotation = rot;
    }
}
