using Godot;
using System;

public class EnemyUnit2 : EnemyMain
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private PathFollow2D _follow;
    private Path2D _path;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // _path = GetParent().GetNode<Path2D>("Path2D");
        // _follow = GetParent().GetNode<PathFollow2D>("Path2D/PathFollow2D");
        // _follow.Loop = true;
        // _follow.Rotate = true;
        // Movement(_follow);
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
