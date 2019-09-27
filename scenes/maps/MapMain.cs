using Godot;
using System;
using System.Reflection;

public class MapMain : Node2D
{

    public override void _Ready()
    {
        // Connect("Shoot", this, "_on_Shoot");
    }


    public void _on_Shoot(int bulletSpeed, PackedScene bulletType, Player player, Vector2 muzzlePos)
    {
        PackedScene projScene = (PackedScene) ResourceLoader.Load("res://scenes/projectiles/ProjectileMain.tscn");

        ProjectileMain z = (ProjectileMain) projScene.Instance();
        z.Setup(bulletSpeed, bulletType);
        z.Start(muzzlePos, player.GlobalPosition - muzzlePos);
        AddChild(z);
    }
}
