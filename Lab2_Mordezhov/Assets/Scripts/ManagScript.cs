using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagScript : MonoBehaviour
{
    public Camera cam;

    public Transform stand;
    public Transform barrels;
    public LayerMask far_Plane;

    [Range(5f, 100f)]
    public float horizontal_speed = 1;
    [Range(5f, 100f)]
    public float vertical_speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, far_Plane))
        { 
            Vector3 dir = hit.point - transform.position;
            Vector3 xz = dir;
            xz.y = 0;

            stand.rotation = Quaternion.RotateTowards(stand.rotation, Quaternion.LookRotation(xz), horizontal_speed * Time.deltaTime);
            barrels.rotation = Quaternion.RotateTowards(barrels.rotation, Quaternion.LookRotation(dir), vertical_speed * Time.deltaTime);
        }

    }
}
