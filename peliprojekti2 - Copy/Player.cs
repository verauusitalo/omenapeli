
using Godot;
using System;

public class Player : CharacterBody2D
{
    [Export] public float Speed = 200;

    public override void _PhysicsProcess(float Player)
    {
        Vector2 velocity = new Vector2();

        if (Input.IsActionPressed("ui_right")) velocity.x += 1;
        if (Input.IsActionPressed("ui_left")) velocity.x -= 1;
        if (Input.IsActionPressed("ui_down")) velocity.y += 1;
        if (Input.IsActionPressed("ui_up")) velocity.y -= 1;

        velocity = velocity.Normalized() * Speed;
        MoveAndSlide(velocity);
    }
}