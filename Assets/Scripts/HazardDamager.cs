using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class HazardDamager : MonoBehaviour
{
    [SerializeField] private float knockPower = 100f;
    [SerializeField] private float knockDuration = 0.4f;
    private Vector2 _pushDirection;


    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject player = other.gameObject;
        if (player.CompareTag(TagManager.Player))
        {
            player.GetComponent<PlayerStats>().TakeDamage(1);

            var direction = (player.transform.position - transform.position);

            KnockBack(knockDuration,direction, player);
            
           // player.GetComponent<Rigidbody2D>().velocity = direction * knockPower;
        }
    }
    
    private void KnockBack(float knockDuration, Vector2 knockBackDirection,GameObject player)
    {
        float timer = 0;
        while (knockDuration > timer)
        {
            timer += Time.deltaTime;
             
            player.GetComponent<Rigidbody2D>().AddForce(knockBackDirection * knockPower);
        }
    }
}
