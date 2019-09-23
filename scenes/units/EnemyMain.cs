using Godot;
using System;

public class EnemyMain : KinematicBody2D
{

    [Export] public int Speed;
    [Export] public int BulletSpeed;
    [Export] public float FireTime;
    [Export] public bool Moveable;
    [Export] public PackedScene BulletType;

    [Signal] delegate void Shoot ();
    
    public PathFollow2D _follow;

    // _collision set from EnemyUnit
    public RayCast2D _collision;
    public Player _target;
    public bool targetAcquired;
    public Sprite barrel;
    public PackedScene Projectile;
    // public string BulletType;

    public int TankSpeed { 
        get; 
        private set; 
        }

    public override void _Ready()
    {
        base._Ready();
        TankSpeed = Speed;
        GD.Print(Moveable);
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        if (Moveable)
        {
            _follow.SetOffset(_follow.GetOffset() + TankSpeed * delta);       
        }
        // Position = new Vector2();

    }

    public override void _Process(float delta)
    {
        Aiming(delta);
        if (targetAcquired & _target != null)
        {
            Vector2 targetDir = (_target.GlobalPosition - GlobalPosition).Normalized();
            Vector2 currentDir = new Vector2(1, 0).Rotated(barrel.GlobalRotation);
            barrel.GlobalRotation = currentDir.LinearInterpolate(targetDir, 50 * delta).Angle();
        }
    }

    public void Movement(PathFollow2D pathFollow2D)
    {
        // GD.Print("called");
        _follow = pathFollow2D;
        _follow.Loop = true;
        _follow.Rotate = true;
    }

    public void Aiming(float delta)
    {
        if (_target != null & !targetAcquired)
        {
            targetAcquired = true;
            // stop tank whilst shooting
            TankSpeed = 0;
            EmitSignal("Shoot", BulletSpeed, BulletType, _target, GlobalPosition);
            GetNode<Timer>("FireTimer").WaitTime = FireTime;
            GetNode<Timer>("FireTimer").Start();
            
        }
        else if (_target is null)
        {
            TankSpeed = Speed;
        }

    }

    public void Shooting(ProjectileMain projectile)
    {
        projectile.Position = barrel.GetPosition();
        // AddChild(projectile);
    }
    public void Colliding()
    {
        // var spaceState = GetWorld2d().DirectSpaceState;
        // var result = spaceState.IntersectRay(GlobalPosition,
        //                                      new Vector2(GlobalPosition.x + _collision.CastTo.x, GlobalPosition.y),
        //                                      new Godot.Collections.Array { this },
        //                                      CollisionMask);
        // if (result.Count > 0)
        // {
        //     if (result["collider"].ToString() == "Player")
        //     {
        //         GD.Print("Collision");
        //         Speed = 0;
        //     }
        // }
        // else
        // {
        //     Speed = 50;
        // }
        if (_collision.IsColliding())
        {
            GD.Print(_collision.GetCollider());
            Speed = 0;
        }
        else
        {
            Speed = 50;
        }
    }

    private void _on_FireTimer_timeout()
    {
        if (_target != null)
        {
            EmitSignal("Shoot", 100, BulletType, _target, GlobalPosition);
        }
    }
}


