using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatforms : MonoBehaviour
{
    private BoxCollider2D platformCollider;
    private Animator animator;

    void Start()
    {
        platformCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DoPlatformCycle());
        }
    }

    IEnumerator DoPlatformCycle()
    {
        //destroy
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("PlatformActive", false);
        yield return new WaitForSeconds(0.5f);
        platformCollider.enabled = false;
        //repair
        yield return new WaitForSeconds(4.0f);
        platformCollider.enabled = true;
        animator.SetBool("PlatformActive", true);
    }

}
