using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMovement : MonoBehaviour
{
    public float yHeight;
    public float timer;
    public float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + ySpeed;
        Vector3 pos = transform.position;
        pos.y = transform.position.y + (yHeight * (Mathf.Sin(timer * 2)));
        transform.position = pos;
    }
}
