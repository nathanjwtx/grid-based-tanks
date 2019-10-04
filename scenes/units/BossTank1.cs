using Godot;
using GC = Godot.Collections;
using System;
using System.Collections.Generic;

public class BossTank1 : EnemyMain
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
        if (body is Player player)
        {
            base._target = player;
            barrel = GetNode<Sprite>("Barrel");
        }
    }
	
	private void _on_Radar2_body_exited(object body)
	{
        base._target= null;
        base.targetAcquired = false;
	}

    public void _on_Target(GC.Array players)
    {
        // if (base._target is null)
        // {
            // Random r = new Random();
            // // GD.Print(players[playerList[r.Next(0, 2)]]);
            // base._target = playerList[r.Next(0, players.Count)];
            // barrel = GetNode<Sprite>("Barrel");
        // }
        Player closest;
        List<float> Distances = new List<float>();
        float distance = -1.0f;
        Dictionary<Player, float> PlayerDistances = new Dictionary<Player, float>();
        foreach (Player p in players)
        {
            float d = GetGlobalPosition().DistanceSquaredTo(p.GetGlobalPosition());
            PlayerDistances.Add(p, d);
            if (d > distance)
            {
                closest = p;
                distance = d;
                base._target = p;
                barrel = GetNode<Sprite>("Barrel");
            }
        }
        Distances.Sort();

    }
}
