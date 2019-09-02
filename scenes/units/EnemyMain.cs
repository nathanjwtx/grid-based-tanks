using Godot;
using System;

public class EnemyMain : KinematicBody2D
{

    [Export] public int Speed;

    private PathFollow2D _follow;

    // _collision set from EnemyUnit
    public RayCast2D _collision;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        GD.Print(GetParent().Name);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        _follow.SetOffset(_follow.GetOffset() + Speed * delta);       
        Position = new Vector2();
    }
    public void Movement(PathFollow2D pathFollow2D)
    {
        GD.Print("called");
        _follow = pathFollow2D;
        _follow.Loop = true;
        _follow.Rotate = true;
    }

    public void Colliding()
    {
        var spaceState = GetWorld2d().DirectSpaceState;
        var result = spaceState.IntersectRay(GlobalPosition,
                                             new Vector2(GlobalPosition.x + _collision.CastTo.x, GlobalPosition.y),
                                             new Godot.Collections.Array { this },
                                             CollisionMask);
        if (result.Count > 0)
        {
            if (result["collider"].ToString() == "Player")
            {
                Speed = 0;
            }
        }
        else
        {
            Speed = 50;
        }
    }
}
