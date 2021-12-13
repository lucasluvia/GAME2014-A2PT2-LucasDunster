using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(PolygonCollider2D))]
public class LOS : MonoBehaviour
{
    [Header("LOS Collider Information")]
    public Collider2D collidesWith;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliderList;

    public PolygonCollider2D LOSCollider;

    void Start()
    {
        LOSCollider = GetComponent<PolygonCollider2D>();
    }

    void FixedUpdate()
    {
        Physics2D.GetContacts(LOSCollider, contactFilter, colliderList);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        collidesWith = otherCollider;
    }
}
