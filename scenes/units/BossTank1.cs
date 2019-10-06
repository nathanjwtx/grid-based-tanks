using Godot;
using GC = Godot.Collections;
using System;
using System.Collections.Generic;

public class BossTank1 : EnemyMain
{
    private PathFollow2D _follow;
    private Path2D _path;
    private RayCast2D _inRange;

    private Dictionary<Player, float> PlayerDistances;
    public override void _Ready()
    {
        PlayerDistances = new Dictionary<Player, float>();
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

    public void _on_Target(GC.Dictionary players)
    {
        // if (base._target is null)
        // {
            // Random r = new Random();
            // // GD.Print(players[playerList[r.Next(0, 2)]]);
            // base._target = playerList[r.Next(0, players.Count)];
            // barrel = GetNode<Sprite>("Barrel");
        // }
        Player newTarget = null;
        List<float> Distances = new List<float>();
        float distance = 0;
        foreach (Player p in players.Keys)
        {
            float d = GetGlobalPosition().DistanceSquaredTo(p.GetGlobalPosition());
            if (!PlayerDistances.ContainsKey(p))
            {
                PlayerDistances.Add(p, d);
            }
            if (distance == 0 || d < distance)
            {
                if (newTarget != null)
                {
                    newTarget.GetNode<Sprite>("Reticle").Visible = false;
                }
                newTarget = p;
                distance = d;
                base._target = newTarget;
                newTarget.GetNode<Sprite>("Reticle").Visible = true;
                barrel = GetNode<Sprite>("Barrel");
                GD.Print($"Closest player: {newTarget.Name}");
            }
        }
        Distances.Sort();

    }
}
