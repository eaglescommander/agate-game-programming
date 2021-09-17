using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Owl : Bird
{
    public CircleCollider2D ColliderExplosion;
    public Sprite fireSprite;
    public float radius;

    public void Explode()
    {
        if (State == BirdState.HitSomething)
        {
            GetComponent<CircleCollider2D>().radius = radius;
            ColliderExplosion.enabled = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<SpriteRenderer>().sprite = fireSprite;

            StartCoroutine(DestroyAfter(0.3f));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        _state = BirdState.HitSomething;
        Explode();
    }
    
}