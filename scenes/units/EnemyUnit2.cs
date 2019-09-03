using Godot;
using Godot.Collections;
using System;

public class EnemyUnit2 : EnemyMain
{
    private PathFollow2D _follow;
    private Path2D _path;
    private RayCast2D _inRange;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._collision = GetNode<RayCast2D>("Ray_Collision");
        Speed = 50;
    }


    private void _on_Radar_body_entered(object body)
    {
        // Speed = 0;
        // GD.Print("player");
        GD.Print(body.ToString());
        if (body is Player player)
        {
            base._target = player;
        }
    }

    private void _on_Radar_body_exited(object body)
    {
        GD.Print("exit");
        base._target = null;
    }

}






