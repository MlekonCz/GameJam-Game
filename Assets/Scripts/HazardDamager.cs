using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class HazardDamager : MonoBehaviour
{
    [SerializeField] private float knockPower = 1500f;
    private Vector2 _pushDirection;


    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject player = other.gameObject;
        if (player.CompareTag(TagManager.Player))
        {
            player.GetComponent<PlayerStats>().TakeDamage();

            var direction = (player.transform.position - transform.position);

            StartCoroutine(KnockBack(0.2f,knockPower,direction, player));
            
           // player.GetComponent<Rigidbody2D>().velocity = direction * knockPower;
           // player.GetComponent<Rigidbody2D>().AddForce(direction * knockPower, ForceMode2D.Force);
        }
    }
    
    private IEnumerator KnockBack(float knockDuration, float knockBackPower, Vector2 knockBackDirection,GameObject player)
    {
        float timer = 0;
        while (knockDuration > timer)
        {
            timer += Time.deltaTime;
                
            player.GetComponent<Rigidbody2D>().AddForce(knockBackDirection * knockPower);
        }
        yield return 0;
    }
}
