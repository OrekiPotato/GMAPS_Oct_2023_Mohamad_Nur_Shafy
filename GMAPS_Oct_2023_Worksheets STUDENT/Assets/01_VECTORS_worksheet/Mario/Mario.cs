using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new Vector3(0,4);
        moveDir = new Vector3(1, 0f);
        moveDir = moveDir.normalized * -1f;

        rb.AddForce(moveDir * 5f);

        gravityNorm = gravityDir.normalized * -1f;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(gravityDir, moveDir, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(gravityDir,gravityNorm,Color.red);

        DebugExtension.DebugArrow(moveDir.normalized, moveDir, Color.blue);

    }
}


