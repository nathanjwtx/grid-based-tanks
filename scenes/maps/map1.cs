using Godot;
using System;
using System.Collections.Generic;

public class map1 : Node2D
{
    private bool _mousePressed;
    private Vector2 _current;
    private TileMap _terrain;
    private Dictionary<string, int> _terrainValues = new Dictionary<string, int>();
    private List<int> _movement = new List<int>();
    private List<Vector2> _moves = new List<Vector2>();
    private EnemyUnit2 _enemyUnit2;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _mousePressed = false;
        _terrain = GetNode<TileMap>("terrain");
        _terrainValues.Add("grass", 20);
        _terrainValues.Add("straight", 10);
        _terrainValues.Add("bend", 10);
        _terrainValues.Add("cross", 10);
        _terrainValues.Add("tee", 10);
        PackedScene enemy = (PackedScene) ResourceLoader.Load("res://scenes/units/EnemyUnit2.tscn");
        _enemyUnit2 = (EnemyUnit2) enemy.Instance();
        _enemyUnit2.Visible = true;
        // _enemyUnit2.Speed = 50;
        PathFollow2D pathFollow2D = GetNode<PathFollow2D>("Path2D/PathFollow2D");
        pathFollow2D.AddChild(_enemyUnit2);
        _enemyUnit2.Call("Movement", pathFollow2D);
    }

    public override void _PhysicsProcess(float delta)
    {
        _enemyUnit2.Colliding();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (_mousePressed)
        {
            // GetTiles();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            if (@event.IsPressed())
            {
                _mousePressed = true;
                // GD.Print(true);
                // GetTiles();
            }
            else
            {
                _mousePressed = false;
                // GD.Print(false);
            }
        }
    }

    private void GetTiles()
    {
        Vector2 mp = GetViewport().GetMousePosition();
        Vector2 tile = new Vector2((float)(Math.Floor(mp.x / 64)), (float)Math.Floor(mp.y / 64));
        if (tile != _current)
        {
            _current = tile;
            // GD.Print(_current);
            int id = _terrain.GetCellv(_current);
            string tileType = _terrain.TileSet.TileGetName(id);
            int tileValue = _terrainValues[tileType.Left(tileType.Find("_"))];
            // GD.Print(CalculateMovement());
            // GD.Print(_moves.IndexOf(_current));
            if (_moves.IndexOf(_current) > -1)
            {
                // GD.Print("match");
                _moves.RemoveAt(_moves.Count - 1);
                _movement.RemoveAt(_movement.Count - 1);
            }
            else
            {
                // GD.Print("no match");
                _moves.Add(_current);
                _movement.Add(tileValue);
            }
            foreach (Vector2 v in _moves)
            {
                // GD.Print(v);
            }
            // GD.Print(CalculateMovement());
        }
    }

    private int CalculateMovement()
    {
        int total = 0;
        foreach (int s in _movement)
        {
            total += s;
        }
        return total;
    }

}
