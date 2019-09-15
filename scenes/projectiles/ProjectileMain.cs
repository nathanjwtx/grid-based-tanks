using Godot;
using System;

public class ProjectileMain : Area2D
{
    private Vector2 _velocity;
    private string _projType;
    private int _speed;

    public string ProjType
    {
        get { return _projType; }
        private set { _projType = value; }
    }
    
    public int Speed
    {
        get { return _speed; }
        private set { _speed = value; }
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // _timer = GetNode<Timer>("Lifetime");
    }

    public ProjectileMain(string projType, int speed)
    {
        GD.Print("New Projectile");
        ProjType = projType;
        Speed = speed;
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

        _velocity = new Vector2(_speed, 0).Rotated(direction.Rotated(0f).Angle());
    }


}
