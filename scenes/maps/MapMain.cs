using Godot;
using System;

public class MapMain : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    // private void _on_Shoot(string message, string bullet)
    // {
    //     GD.Print(message);
    public void _on_Shoot(int BulletSpeed, Player target)
    {
        GD.Print();
        var b = new ProjectileMain("Beige", BulletSpeed);
        GD.Print(b.ProjType);
        Shooting(b);
        b.Start(GetNode<Position2D>("Barrel/BulletStart").GlobalPosition, _target.GlobalPosition - GlobalPosition);
    }
}
