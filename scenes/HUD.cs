using Godot;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public class HUD : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private List<string> _players = new List<string>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _players.Add("Player1");
        _players.Add("Player2");
        _players.Add("Player3");
        
        UpdatePlayers();
    }

    protected void UpdatePlayers()
    {
        var rtl = GetNode<RichTextLabel>("RichTextLabel");

        string output = String.Empty;
        foreach (string player in _players)
        {
            output += player + "\n";
        }
        
        
        rtl.Text = output;


    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
