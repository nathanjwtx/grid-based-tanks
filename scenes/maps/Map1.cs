using Godot;
using System;
using System.Collections.Generic;

public class Map1 : MapMain
{
    private EnemyBeige _enemyUnit1;
    private EnemyMain _newEnemy;
    private PackedScene _bullet;
    private Node _enemyPaths;
    private EnemyBeige _enemyBeige1;
    private PackedScene _eb1_ps;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // _eb1_ps = (PackedScene) ResourceLoader.Load("res://scenes/units/EnemyBeige.tscn");
        // _enemyBeige1 = (EnemyBeige) _eb1_ps.Instance();
        // _enemyPaths = GetNode<Node>("EnemyPaths");
        // PathFollow2D enemyBeige1_pf = _enemyPaths.GetNode<PathFollow2D>("eb1_path/eb1_pf2D");
        // enemyBeige1_pf.AddChild(_enemyBeige1);
        // _enemyBeige1.Call("Movement", enemyBeige1_pf);
        // _enemyBeige1.Connect("Shoot", this, "_on_Shoot");

        // _enemyBeige1.AddToGroup("enemyUnits");
        _enemyUnit1 = GetNode<EnemyBeige>("EnemyPaths/eb1_path/eb1_pf2D/EnemyBeige1");
        _enemyUnit1._follow = GetNode<PathFollow2D>("EnemyPaths/eb1_path/eb1_pf2D");
        _enemyUnit1.Connect("Shoot", this, "_on_Shoot");
        BossTank1 bossTank1 = GetNode<BossTank1>("BossTank1");
        bossTank1.Connect("Shoot", this, "_on_Shoot");
    }

    public override void _PhysicsProcess(float delta)
    {
        // _enemyUnit1.Colliding();
    }

    // private void _on_Shoot(string message)
    // {
    //     GD.Print(message);

    // }
    // private void _on_EnemyBeige1_Shoot(string test, string test2)
    // {
    //     GD.Print(test);
    //     GD.Print(test2);
    // }
}



