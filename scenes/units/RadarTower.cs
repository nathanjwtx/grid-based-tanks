using Godot;
using System;

public class RadarTower : StaticBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    private int _rotationSpeed;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _rotationSpeed = 10;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Area2D radarCone = GetNode<Area2D>("RadarCone");
        radarCone.Rotate(0.0005f);
    }
    private void _on_RadarCone_area_entered(object area)
    {
        GD.Print("Player spotted");
    }
}


