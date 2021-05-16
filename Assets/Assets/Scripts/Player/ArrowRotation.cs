using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    Rigidbody2D rb;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb.simulated)
        {
            return;
        }
        Vector3 dir = (transform.position + (Vector3)rb.velocity.normalized) - transform.position;
        transform.rotation = Quaternion.LookRotation(dir, (sr.flipY ? Vector3.down : Vector3.up));
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z, 0, transform.rotation.eulerAngles.x + 90));

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            rb.velocity = Vector2.zero;
            transform.SetParent(other.transform);
            rb.simulated = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.velocity);
    }
}
