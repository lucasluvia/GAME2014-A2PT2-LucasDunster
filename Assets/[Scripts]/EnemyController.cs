using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LOS enemyLOS;
    [SerializeField] private float runForce;
    [SerializeField] private Transform playerSpawnPoint;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enemyLOS = GetComponent<LOS>();
    }

    void Update()
    {
        if (HasLOS())
        {
            rigidbody.AddForce(Vector2.left * runForce * transform.localScale.x);
        }

    }

    private bool HasLOS()
    {
        if (enemyLOS.colliderList.Count > 0)
        {
            if (enemyLOS.collidesWith.gameObject.name == "Player")
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = playerSpawnPoint.position;
        }
    }
}
