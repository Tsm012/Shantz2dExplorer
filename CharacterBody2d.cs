using Godot;

namespace Shantz2dExplorer;

public partial class CharacterBody2d : CharacterBody2D
{
	private const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;

		// Get the input direction for both horizontal and vertical movement
		var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		// Update the X velocity based on left/right input
		if (direction.X != 0)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			// Decelerate X velocity
			velocity.X = 0; // Explicitly cast to float
		}

		// Update the Y velocity based on up/down input
		if (direction.Y != 0)
		{
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			// Decelerate Y velocity
			velocity.Y = 0; // Explicitly cast to float
		}

		// Assign the updated velocity
		Velocity = velocity;

		// Move the character
		MoveAndSlide();
	}
}
