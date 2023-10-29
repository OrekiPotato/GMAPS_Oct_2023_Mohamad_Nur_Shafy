using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);
        moveDir.Normalize();

        rb.AddForce(moveDir.ToUnityVector2() * force);

        gravityDir.Normalize();
        gravityNorm = gravityDir * gravityStrength;
        rb.AddForce(gravityNorm.ToUnityVector2());

        Vector3 moveDirVec3 = moveDir.ToUnityVector3();

        float angle = Vector3.SignedAngle(Vector3.right, moveDirVec3, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0,0,angle));
    }
}
