using Godot;
using System;
using System.Collections.Generic;

public class Map1 : MapMain
{
    private EnemyUnit1 _enemyUnit1;
    private EnemyMain _newEnemy;
    private PackedScene _bullet;
    private Node _enemyPaths;
    private EnemyBeige _enemyBeige1;
    private PackedScene _eb1_ps;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _eb1_ps = (PackedScene) ResourceLoader.Load("res://scenes/units/EnemyBeige.tscn");
        _enemyBeige1 = (EnemyBeige) _eb1_ps.Instance();
        _enemyPaths = GetNode<Node>("EnemyPaths");
        PathFollow2D enemyBeige1_pf = _enemyPaths.GetNode<PathFollow2D>("eb1_path/eb1_pf2D");
        enemyBeige1_pf.AddChild(_enemyBeige1);
        _enemyBeige1.Call("Movement", enemyBeige1_pf);
        _enemyBeige1.Connect("Shoot", this, "_on_Shoot");

        _enemyBeige1.AddToGroup("enemyUnits");
    }

    public override void _PhysicsProcess(float delta)
    {
        // _enemyUnit1.Colliding();
    }

    private void _on_Shoot(PackedScene projectile)
    {
        GD.Print(projectile.ResourceName);

    }

}
