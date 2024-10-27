using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction for both horizontal and vertical movement
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
		// Update the X velocity based on left/right input
		if (direction.X != 0)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			// Decelerate X velocity
			velocity.X = Mathf.MoveToward(velocity.X, 0, (float)Speed * (float)delta); // Explicitly cast to float
		}

		// Update the Y velocity based on up/down input
		if (direction.Y != 0)
		{
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			// Decelerate Y velocity
			velocity.Y = Mathf.MoveToward(velocity.Y, 0, (float)Speed * (float)delta); // Explicitly cast to float
		}

		// Assign the updated velocity
		Velocity = velocity;

		// Move the character
		MoveAndSlide();
	}
}
