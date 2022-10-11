using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    Vector3 maxLeftPos = new (-26.2f, 1.48f, 14);
    Vector3 maxRightPos = new (26.5f, 1.48f, 14);

    bool speedCheckOne = true;
    bool speedCheckTwo = true;
    int currHealth;

    [SerializeField] public float moveSpeed = .2f;
    [SerializeField] float speedIncrease = .5f;
    [SerializeField] Health healthCS;

    private void Update()
    {
        currHealth = healthCS.GetHealth();

        if(currHealth <= 15 && speedCheckOne == true)
        {
            moveSpeed += speedIncrease;
            speedCheckOne = false;
        }
        if(currHealth <= 10 && speedCheckTwo == true)
        {
            moveSpeed += speedIncrease;
            speedCheckTwo = false;
        }
        /*if(healthCS.GetHealth() <= healthCS.GetMaxHealth() / 2 && isHalfHealth)
        {
            moveSpeed += speedIncrease;
            isHalfHealth = false;
            Debug.Log("move speed: " + moveSpeed);
        }*/

        Move();   
    }

    public void Move()
    {
        transform.position = Vector3.Lerp(maxLeftPos, maxRightPos, Mathf.PingPong(Time.time * moveSpeed, 1.0f));
    }
}
