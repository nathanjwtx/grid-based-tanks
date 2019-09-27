using Godot;
using Godot.Collections;
using System;

public class EnemyBeige : EnemyMain
{
    private Path2D _path;
    private RayCast2D _inRange;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._collision = GetNode<RayCast2D>("Ray_Collision");
        // GD.Print(GetParent().Name);
    }


    private void _on_Radar_body_entered(object body)
    {
        if (body is Player player)
        {
            base._target = player;
            // base.BulletType = "BulletBeige1";
            barrel = GetNode<Sprite>("Barrel");
        }
    }

    private void _on_Radar_body_exited(object body)
    {
        // GD.Print("exit");
        base._target = null;
        base.targetAcquired = false;
    }

    // public void _on_Shoot(int bulletSpeed, string message)
    // {
    //     GD.Print(bulletSpeed);
    // //     var b = new ProjectileMain("Beige", BulletSpeed);
    // //     GD.Print(b.ProjType);
    // //     Shooting(b);
    // //     b.Start(GetNode<Position2D>("Barrel/BulletStart").GlobalPosition, _target.GlobalPosition - GlobalPosition);
    // }

}






