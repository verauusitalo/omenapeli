using Godot;
using System;

public class Apple : Area2D
{
    [Signal] public delegate void Collected();

    public override void _Ready()
    {
        Connect("body_entered", this, nameof(OnBodyEntered));
    }

    private void OnBodyEntered(Node body)
    {
        if (body is Player)
        {
            EmitSignal(nameof(Collected));
            QueueFree(); // remove the apple
        }
    }
}
