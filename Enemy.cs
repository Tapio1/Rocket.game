using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	public float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//var velocity = new Vector2(-90,30);

		Vector2 myVelocity = Velocity;
		myVelocity.Y += Gravity*(float)delta;

		//Position += velocity*(float)delta;

		Velocity = myVelocity;
		MoveAndSlide();
	}

}
