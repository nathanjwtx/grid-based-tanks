using Godot;
using System;

public class RadarTower : StaticBody2D
{
    [Signal] delegate void Target ();
    // Declare member variables here. Examples:
    // private int a = 2;
    private int _rotationSpeed;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _rotationSpeed = 10;
        // Connect("ReceiveTarget", this, "_on_ReceiveTarget");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Area2D radarCone = GetNode<Area2D>("RadarCone");
        radarCone.Rotate(0.0005f);
    }
    // private void _on_RadarCone_area_entered(object area)
    // {
    //     GD.Print("Player spotted");
    // }
    private void _on_RadarCone_body_entered(object body)
    {
        if (body is Player p)
        {
            GD.Print(p.GetGlobalPosition());
            EmitSignal("Target", p);
        }
    }
}



