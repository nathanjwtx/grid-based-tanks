using Godot;
using System;
using System.Reflection;

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

    public void _on_Shoot(int bulletSpeed, PackedScene bulletType, Player player, Vector2 muzzlePos)
    {
        PackedScene projScene = (PackedScene) ResourceLoader.Load("res://scenes/projectiles/ProjectileMain.tscn");

        ProjectileMain z = (ProjectileMain) projScene.Instance();
        z.Setup(bulletSpeed, bulletType);
        z.Start(muzzlePos, player.GetGlobalPosition() - muzzlePos);
        AddChild(z);
    }
}
