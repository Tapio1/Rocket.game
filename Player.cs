using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Signal]
	public delegate void AddScoreEventHandler();

	[Export]
	public float up = - 500;
	public float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _PhysicsProcess(double delta)
	{
		Vector2 myVelocity = Velocity;
		myVelocity.Y += Gravity*(float)delta;

		if(Input.IsActionPressed("GoUp"))
		{
			myVelocity.Y = up;
		}

		Velocity = myVelocity;
		MoveAndSlide();
	}

	public void OnCollision(Rid areaRid, Node2D area, long areaShapeIndex, long localShapeIndex){
		
		GD.Print(areaShapeIndex);
		GD.Print(area.GetParent().Name);
		area.GetParent().QueueFree();
		if(areaShapeIndex == 2){
			EmitSignal(SignalName.AddScore);
		}
	}	

}