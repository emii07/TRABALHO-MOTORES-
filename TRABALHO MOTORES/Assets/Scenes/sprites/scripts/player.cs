using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   public float velocidade = 10f;
     public float focaPulo = 20f;
   
       public bool noChao = false;
     
   
     private Rigidbody2D _rigidbody2D;
     private SpriteRenderer  spriteRenderer; 
    
    void Start()
     {
           _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
           spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      }

    void OnCollisionStay2D(Collision2D collision)
    
    {
        if (collision.gameObject.tag == "chao")
        {
            noChao = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
       {
           if (collision.gameObject.tag == "chao")
           {
               noChao = false;
           }
       } 
    void Update()
       { 
           if(Input.GetKey(KeyCode.LeftArrow))
           {
               gameObject.transform.position += new Vector3(-velocidade*Time.deltaTime,0,0);
               //rigidbody2D.AddForce(new Vector2(-velocidade,0));
               spriteRenderer.flipX = true;
               Debug.Log("LeftArrow");
           }
           
           
           if(Input.GetKey(KeyCode.RightArrow))
           {
               gameObject.transform.position += new Vector3(velocidade*Time.deltaTime,0,0);
               //rigidbody2D.AddForce(new Vector2(velocidade,0));
               spriteRenderer.flipX = false;
               Debug.Log("RightArrow");
           }

           if (Input.GetKeyDown(KeyCode.Space) && noChao == true)
           {
               _rigidbody2D.AddForce(new Vector2(0, 1) * focaPulo,ForceMode2D.Impulse);

               Debug.Log("Jump");
           }

     


       }
}

