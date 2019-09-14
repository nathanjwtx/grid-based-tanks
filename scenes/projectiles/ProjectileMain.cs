using Godot;
using System;

public class ProjectileMain : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public int Speed;
    [Export] public float Lifetime;
    private Vector2 _velocity;
    private Timer _timer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _timer = GetNode<Timer>("Lifetime");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        this.Position += _velocity * delta;
    }

    public void Start(Vector2 position, Vector2 direction)
    {
        Position = position;
        Rotation = direction.Angle();

        _velocity = direction * Speed;
    }


}
