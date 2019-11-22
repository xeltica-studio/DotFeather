namespace DotFeather
{
	/// <summary>
	/// A sprite with texture-animation feature.
	/// </summary>
	public class AnimatingSprite : Sprite, IUpdatable
	{
		/// <summary>
		/// Get an array of textures to animate.
		/// </summary>
		public Texture2D[] Textures { get; }

		/// <summary>
		/// Get whether this sprite is animating.
		/// </summary>
		public bool IsAnimating { get; private set; }

		/// <summary>
		/// Get and set loop times. If -1, animation loops infinity, and if 0, animation won't loop.
		/// </summary>
		public int LoopTimes { get; set; }

		/// <summary>
		/// Get and set animation time in frame.
		/// </summary>
		public int Duration { get; set; }

		/// <summary>
		/// Initialize a new instance of <see cref="AnimatingSprite"/> class by parameters.
		/// </summary>
		/// <param name="textures">An array of texture.</param>
		/// <param name="loopTimes">Loop times. If -1, animation loops infinity, and if 0, animation won't loop.</param>
		/// <param name="duration">Animation time in frame.</param>
		public AnimatingSprite(Texture2D[] textures, int loopTimes, int duration) : base(textures[0])
		{
			Textures = textures;
			LoopTimes = loopTimes;
			Duration = duration;
		}

		/// <summary>
		/// Start the animation.
		/// </summary>
		public void StartAnimating()
		{
			currentIndex = 0;
			count = 0;
			loopCount = 0;
			IsAnimating = true;
		}

		/// <summary>
		/// Stop the animation.
		/// </summary>
		public void StopAnimating()
		{
			IsAnimating = false;
		}

		public void OnUpdate(GameBase game)
		{
			Texture = Textures[currentIndex];

			if (IsAnimating)
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
							StopAnimating();
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
