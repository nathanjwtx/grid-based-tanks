using Godot;
using GC = Godot.Collections;
using System;
using System.Collections.Generic;

public class RadarTower : StaticBody2D
{
    [Signal] delegate void Target ();
    [Export] public float RotationSpeed;

    private GC.Array Enemies;
    private float _rotationSpeed;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _rotationSpeed = RotationSpeed;
        Enemies = new GC.Array();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Area2D radarCone = GetNode<Area2D>("RadarCone");
        radarCone.Rotate(_rotationSpeed);
    }
    // private void _on_RadarCone_area_entered(object area)
    // {
    //     GD.Print("Player spotted");
    // }
    private void _on_RadarCone_body_entered(object body)
    {
        if (body is Player p)
        {
            if (!Enemies.Contains(p))
            {
                Enemies.Add(p);
            }
            EmitSignal("Target", Enemies);
        }
    }
}



