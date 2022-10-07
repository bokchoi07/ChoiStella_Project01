using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectiles
{
    [SerializeField] public float moveSpeed = 1.0f;

    GameObject player;
    private void Start()
    {
        damage = 2;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        transform.up = player.transform.position - transform.position;
    }
}
