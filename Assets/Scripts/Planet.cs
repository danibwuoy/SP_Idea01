using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float gravity = -10;
    [SerializeField]
    private float bodyRotationSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGravity(Transform body)
    {
        Vector3 gravityDirection = (body.position - transform.position).normalized;
        Rigidbody rb = body.GetComponent<Rigidbody>();
        if (rb == null)
            return;
        rb.AddForce(gravityDirection * gravity);
        Quaternion targetRotation = Quaternion.FromToRotation(body.up, gravityDirection) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation,targetRotation,bodyRotationSpeed * Time.deltaTime);
    }

}
