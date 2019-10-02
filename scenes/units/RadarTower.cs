using Godot;
using Godot.Collections;
using System;
// using System.Collections.Generic;

public class RadarTower : StaticBody2D
{
    [Signal] delegate void Target ();
    [Export] public float RotationSpeed;

    private Dictionary<Player, Vector2> EnemyRange;

    private float _rotationSpeed;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _rotationSpeed = RotationSpeed;
        EnemyRange = new Dictionary<Player, Vector2>();
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
            if (EnemyRange.ContainsKey(p))
            {
                EnemyRange[p] = p.GetGlobalPosition();
            }
            else
            {
                EnemyRange.Add(p, p.GetGlobalPosition());
            }
            EmitSignal("Target", EnemyRange);
        }
    }
}



