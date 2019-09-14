using Godot;
using System;

public class EnemyMain : KinematicBody2D
{

    [Export] public int Speed;

    [Signal] delegate void Shoot (string one, string two);
    
    private PathFollow2D _follow;

    // _collision set from EnemyUnit
    public RayCast2D _collision;
    public Player _target;
    private bool targetAcquired;
    public Sprite barrel;
    public PackedScene Projectile;

    public override void _Ready()
    {
        base._Ready();
        // GD.Print(GetParent().Name);
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        _follow.SetOffset(_follow.GetOffset() + Speed * delta);       
        // Position = new Vector2();
    }

    public override void _Process(float delta)
    {
        AimAndShoot(delta);
        if (targetAcquired & _target != null)
        {
            Vector2 targetDir = (_target.GlobalPosition - GlobalPosition).Normalized();
            Vector2 currentDir = new Vector2(1, 0).Rotated(barrel.GlobalRotation);
            barrel.GlobalRotation = currentDir.LinearInterpolate(targetDir, 5 * delta).Angle();
        }
    }

    public void Movement(PathFollow2D pathFollow2D)
    {
        // GD.Print("called");
        _follow = pathFollow2D;
        _follow.Loop = true;
        _follow.Rotate = true;
    }

    public void AimAndShoot(float delta)
    {
        if (_target != null & !targetAcquired)
        {
            GD.Print("targeted");
            targetAcquired = true;
            EmitSignal("Shoot", "hello", "Fire!");
            // EmitSignal("Shoot", "Fire!", _target.Position);
            GD.Print("after signal");
        }

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
}
