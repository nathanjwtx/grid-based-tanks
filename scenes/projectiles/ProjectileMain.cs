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
     
    }

    public void Setup(string projType, int speed)
    {
        GD.Print("New Projectile");
        ProjType = projType;
        Speed = speed;
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        this.Position += _velocity * delta;
    }

    public void Start(Vector2 position, Vector2 direction)
    {
        GlobalPosition = position;
        Rotation = direction.Angle();
        // GD.Print(direction);

        _velocity = new Vector2(_speed, 0).Rotated(Rotation).Normalized() * Speed;
    }
    private void _on_AutoExplode_timeout()
    {
        QueueFree();
    }

}



