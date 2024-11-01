using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask background;

    [Range(10, 100)]
    public float forcelimit = 100;
    [Range(10, 300)]
    public float forceRate = 10;
    float force = 0;

    LineRenderer lineRenderer;
    Rigidbody rb;
    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);

        if (Physics.Raycast(ray, out hit, 100, background))
        {
            Vector3 p = hit.point;
            p.x = transform.position.x;

            Vector3 dir = (p - transform.position);
            dir.Normalize();
            lineRenderer.SetPosition(1, (transform.position + (dir * (force / 10 + 2))));

            if (Input.GetAxisRaw("Fire1") > 0)
            {
                if (force < forcelimit)
                    force += forceRate * Time.deltaTime;

            }
            else
            if (force > 0)
            {
                rb.AddForce(dir * force, ForceMode.Impulse);
                force = 0;
            }
        }

    }
}
