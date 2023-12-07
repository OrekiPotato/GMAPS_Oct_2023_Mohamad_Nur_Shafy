using Collision;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        // Calculates the sprite radius based on its size.
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    // This checks for ball collisions between a point 
    public bool IsCollidingWith(float x, float y)
    {
        HVector2D otherPoint = new HVector2D(x, y);
        float distance = Util.FindDistance(Position, otherPoint);
        return distance <= Radius;
    }

    // This checks for ball collisions between another balls
    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        Position.x += displacementX;
        Position.y += displacementY;

        // Updates the position of the ball with the new calculated position.
        transform.position = new Vector2(Position.x,Position.y);
    }
}

