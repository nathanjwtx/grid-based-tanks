using Godot;
using Godot.Collections;
using System;

public class EnemyBeige : EnemyMain
{
    // [Export] public BulletBeige1 Bullet;
    // public PathFollow2D _follow;
    private Path2D _path;
    private RayCast2D _inRange;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._collision = GetNode<RayCast2D>("Ray_Collision");
        // Speed = 50;
        Connect("Shoot", this, "_on_Shoot");
    }


    private void _on_Radar_body_entered(object body)
    {
        // Speed = 0;
        // GD.Print("player");
        // GD.Print(body.ToString());
        if (body is Player player)
        {
            base._target = player;
            // base.Projectile = Bullet;
            barrel = GetNode<Sprite>("Barrel");
        }
    }

    private void _on_Radar_body_exited(object body)
    {
        // GD.Print("exit");
        base._target = null;
    }

    // public void _on_Shoot(string enemyPos, string message)
    // {
    //     GD.Print();
    //     var b = new ProjectileMain("Beige", BulletSpeed);
    //     GD.Print(b.ProjType);
    //     Shooting(b);
    //     b.Start(GetNode<Position2D>("Barrel/BulletStart").GlobalPosition, _target.GlobalPosition - GlobalPosition);
    // }

}






