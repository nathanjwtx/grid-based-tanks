using Godot;
using System;

public class EnemyUnit1 : EnemyMain
{
    private PathFollow2D _follow;
    private Path2D _path;
    private RayCast2D _inRange;

    public override void _Ready()
    {
        base._collision = GetNode<RayCast2D>("Ray_Collision");
        Speed = 30;
    }


    private void _on_Radar2_body_entered(object body)
    {
        // Speed = 0;
        // GD.Print("player");
        if (body is Player player)
        {
            base._target = player;
        }
    }
}
