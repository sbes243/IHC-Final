using System;
using System.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collisions;

public class colObj1 : MonoBehaviour
{
    private Renderer b17Rend;
    private Renderer b18Rend;
    private Renderer b19Rend;
    private Renderer b20Rend;
    private Vector3 bubble1Position;
    private Vector3 bubble2Position;

    private Material baseMat;

    private bool col1 = false;
    private bool col2 = false;
    private bool col3 = false;
    private bool col4 = false;

    collisionManager manager;

    private void Start()
    {
        manager = FindObjectOfType<collisionManager>();
    }
    private void Update()
    {
        if (col1 && col2)
        {
            // Calculate the vector from Bubble1 to Bubble2
            bubble1Position = GameObject.FindGameObjectWithTag("Hand1").transform.position;
            bubble2Position = GameObject.FindGameObjectWithTag("Hand2").transform.position;
            Vector3 vectorBetweenBubbles = bubble2Position - bubble1Position;

            // Calculate the angle between the vector and the horizontal axis (1, 0, 0)
            float angle = Vector3.SignedAngle(vectorBetweenBubbles, Vector3.right, Vector3.up);
            // Determine whether Bubble1 is higher or lower than Bubble2 along the Y-axis
            if (bubble1Position.y > bubble2Position.y)
            {
                // Bubble1 is higher, so make the angle positive
                angle = Mathf.Abs(angle);
            }
            else
            {
                // Bubble2 is higher, so make the angle negative
                angle = -Mathf.Abs(angle);
            }
            // Set the angle in your collision manager or perform any other action based on the angle
            manager.SetAngle(angle);
        }
        else
        {
            // If not both Bubbles are colliding, reset the angle in your collision manager
            manager.SetAngle(0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hand1"))
        {
            if (this.CompareTag("Bubble17"))
            {
                manager.obj1 = true;
            }
            if (this.CompareTag("Bubble18"))
            {
                manager.obj2 = true;
            }
            if (this.CompareTag("Bubble19"))
            {
                manager.obj3 = true;
            }
            if (this.CompareTag("Bubble20"))
            {
                manager.obj4 = true;
            }
        }
        if (collision.gameObject.CompareTag("Hand2"))
        {
            if (this.CompareTag("Bubble17"))
            {
                manager.obj1 = true;
            }
            if (this.CompareTag("Bubble18"))
            {
                manager.obj2 = true;
            }
            if (this.CompareTag("Bubble19"))
            {
                manager.obj3 = true;
            }
            if (this.CompareTag("Bubble20"))
            {
                manager.obj4 = true;
            }
        }
        if (collision.gameObject.CompareTag("Hand1"))
        {
            
            col1 = true;
        }
        if (collision.gameObject.CompareTag("Hand2"))
        {
          
            col2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hand1"))
        {
            if (this.CompareTag("Bubble17"))
            {
                manager.obj1 = false;
            }
            if (this.CompareTag("Bubble18"))
            {
                manager.obj2 = false;
            }
            if (this.CompareTag("Bubble19"))
            {
                manager.obj3 = false;
            }
            if (this.CompareTag("Bubble20"))
            {
                manager.obj4 = false;
            }
        }
        if (collision.gameObject.CompareTag("Hand2"))
        {
            if (this.CompareTag("Bubble17"))
            {
                manager.obj1 = false;
            }
            if (this.CompareTag("Bubble18"))
            {
                manager.obj2 = false;
            }
            if (this.CompareTag("Bubble19"))
            {
                manager.obj3 = false;
            }
            if (this.CompareTag("Bubble20"))
            {
                manager.obj4 = false;
            }
        }
        if (collision.gameObject.CompareTag("Hand1"))
        {
            col1 = false;
            manager.SetAngle(0f); // Reset the angle when Bubble1 exits
        }
        if (collision.gameObject.CompareTag("Hand2"))
        {
            col2 = false;
            manager.SetAngle(0f); // Reset the angle when Bubble2 exits
        }
    }

}
