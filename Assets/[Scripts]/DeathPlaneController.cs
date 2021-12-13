// DeathPlaneController.cs
// Lucas Dunster 101230948
// DLM: 12/12/21
// Kills player and deactivates other colliders that touch it

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private PlayerBehaviour player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = playerSpawnPoint.position;
            player.DecrementPlayerLives();
        }
        else
        {
            other.gameObject.SetActive(false);
        }

    }
}
