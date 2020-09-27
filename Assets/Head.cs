using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    bool stomped = false;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            stomped = true;
            PolygonCollider2D boxCollider = transform.parent.gameObject.GetComponent<PolygonCollider2D>();
            BoxCollider2D jumpCollider = this.transform.gameObject.GetComponent<BoxCollider2D>();
            Rigidbody2D rigidbody = transform.parent.gameObject.GetComponent<Rigidbody2D>();
            SpriteRenderer spriteRenderer = transform.parent.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.black;
            boxCollider.enabled = false;
            jumpCollider.enabled = false;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
        


    }
    void OnBecameInvisible()
    {
        if(stomped == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
