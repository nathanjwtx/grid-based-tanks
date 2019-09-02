using Godot;
using System;

public class EnemyUnit2 : EnemyMain
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private PathFollow2D _follow;
    private Path2D _path;
    private RayCast2D _collision;
    private RayCast2D _inRange;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // _path = GetParent().GetNode<Path2D>("Path2D");
        // _follow = GetParent().GetNode<PathFollow2D>("Path2D/PathFollow2D");
        // _follow.Loop = true;
        // _follow.Rotate = true;
        // Movement(_follow);
        _collision = GetNode<RayCast2D>("RayCast2D");
        // Speed = 50;
    }


    public void Colliding()
    {
        if (_collision.IsColliding())
        {
            if (_collision.GetCollider() is Player)
            {
                Speed = 0;
            }
        }
        else
        {
            Speed = 50;
        }
    }


    private void _on_Radar2_body_entered(object body)
    {
        Speed = 0;
        GD.Print("player");
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}


