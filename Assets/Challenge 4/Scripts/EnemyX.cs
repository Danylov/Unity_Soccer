using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private static float multiSpeed = 1.0f;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("PlayerGoal");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * multiSpeed * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "EnemyGoal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "PlayerGoal")
        {
            Destroy(gameObject);
        }
    }

    public static void IncreaseEnemySpeed()
    {
        multiSpeed *= 1.1f;
    } 
}
