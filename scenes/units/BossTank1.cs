using Godot;
using System;

public class BossTank1 : EnemyMain
{
    private PathFollow2D _follow;
    private Path2D _path;
    private RayCast2D _inRange;

    public override void _Ready()
    {
        base._collision = GetNode<RayCast2D>("Ray_Collision");
        Speed = 30;
        // Connect("ReceiveTarget", this, "_on_ReceiveTarget");
    }


    private void _on_Radar2_body_entered(object body)
    {
        // Speed = 0;
        // GD.Print("player");
        if (body is Player player)
        {
            base._target = player;
			// base.BulletType = "BulletBeige1";
            barrel = GetNode<Sprite>("Barrel");
        }
    }
	
	private void _on_Radar2_body_exited(object body)
	{
        base._target= null;
        base.targetAcquired = false;
	}

    public void _on_Target(Vector2 targetPos)
    {
        GD.Print(targetPos);
    }
}
