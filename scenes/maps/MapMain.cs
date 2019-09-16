using Godot;
using System;

public class MapMain : Node2D
{

    // [Signal] delegate void Shoot ();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Connect("Shoot", this, "_on_Shoot");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    public void _on_Shoot(int bulletSpeed, string bulletType, Player player, Vector2 muzzlePos)
    {
        var projectile = (PackedScene) ResourceLoader.Load($"res://scenes/projectiles/ProjectileMain.tscn");
        var b = (ProjectileMain) projectile.Instance();
        b.Setup(bulletType, bulletSpeed);
        // PackedScene p = (PackedScene) ResourceLoader.Load($"res://scenes/projectiles/{bulletType}.tscn");

        b.Start(muzzlePos, player.GlobalPosition - GlobalPosition);
        AddChild(b);
    }
}
