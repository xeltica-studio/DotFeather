using System;

namespace DotFeather
{
	public class SpriteAnimator : Component
	{
		/// <summary>
		/// Get an array of textures to animate.
		/// </summary>
		public Texture2D[] Textures { get; set; } = Array.Empty<Texture2D>();

		/// <summary>
		/// Get whether this sprite is animating.
		/// </summary>
		public bool IsPlaying { get; protected set; }

		/// <summary>
		/// Get and set loop times. If -1, animation loops infinity, and if 0, animation won't loop.
		/// </summary>
		public int LoopTimes { get; set; }

		/// <summary>
		/// Get and set animation time in frame.
		/// </summary>
		public int Duration { get; set; }

		public SpriteAnimator()
		{
			Play();
		}

		/// <summary>
		/// Play the animation.
		/// </summary>
		public void Play()
		{
			currentIndex = 0;
			count = 0;
			loopCount = 0;
			IsPlaying = true;
		}

		/// <summary>
		/// Stop the animation.
		/// </summary>
		public void Stop()
		{
			IsPlaying = false;
		}

		public override void OnUpdate()
		{
			var sprite = Element as Sprite ?? throw new InvalidOperationException($"{nameof(SpriteAnimator)} has to be attached to the {nameof(Sprite)} instance.");

			sprite.Texture = Textures[currentIndex];

			if (IsPlaying)
			{
				count++;
				if (count >= Duration)
				{
					count = 0;
					currentIndex++;
					if (currentIndex >= Textures.Length)
					{
						currentIndex--;
						loopCount++;
						if (LoopTimes != -1 && loopCount > LoopTimes)
						{
							Stop();
						}
						else
						{
							currentIndex = 0;
							count = 0;
						}
					}
				}
			}
		}

		private int currentIndex;
		private int loopCount;
		private int count;
	}
}
