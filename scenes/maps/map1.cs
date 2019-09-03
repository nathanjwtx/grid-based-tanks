using Godot;
using System;
using System.Collections.Generic;

public class map1 : Node2D
{
    private EnemyUnit2 _enemyUnit2;
    private EnemyUnit1 _enemyUnit1;
    private EnemyMain _newEnemy;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // PackedScene enemy = (PackedScene) ResourceLoader.Load("res://scenes/units/EnemyUnit2.tscn");
        // _enemyUnit2 = (EnemyUnit2) enemy.Instance();
        // _enemyUnit2.Visible = true;
        // PathFollow2D pathFollow2D = GetNode<PathFollow2D>("Path2D/PathFollow2D");
        // pathFollow2D.AddChild(_enemyUnit2);
        // _enemyUnit2.Call("Movement", pathFollow2D);

        PackedScene enemy2 = (PackedScene) ResourceLoader.Load("res://scenes/units/EnemyUnit1.tscn");
        _enemyUnit1 = (EnemyUnit1) enemy2.Instance();
        _enemyUnit1.Visible = true;
        PathFollow2D pathFollow2D1 = GetNode<PathFollow2D>("Path2D2/PathFollow2D");
        pathFollow2D1.AddChild(_enemyUnit1);
        _enemyUnit1.Call("Movement", pathFollow2D1);
    }

    public override void _PhysicsProcess(float delta)
    {
        _enemyUnit2.Colliding();
        // _enemyUnit1.Colliding();
    }

}
