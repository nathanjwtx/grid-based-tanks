using Godot;
using System;

public class EnemyMain : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public int Speed;

    private PathFollow2D _follow;
    
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
}
