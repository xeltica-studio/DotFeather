using System;
using System.Collections.Generic;
using System.Drawing;

namespace DotFeather
{
    /// <summary>
    /// Abstract scene class.
    /// </summary>
    public abstract class Scene
    {
        /// <summary>
        /// Get a root container of this scene.
        /// </summary>
        public Container Root { get; } = new Container();

        /// <summary>
        /// Get a random generator.
        /// </summary>
        public Random Random { get; private set; } = new Random();

        /// <summary>
        /// Get or set background color.
        /// </summary>
        public Color? BackgroundColor { get; set; }

        /// <summary>
        /// Get or set window title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Initialize the random generator.
        /// </summary>
        /// <param name="seed">Seed value. If not specified, using a default constructor of <see cref="Random"/> to initialize. </param>
        public void Randomize(int? seed = null)
        {
            Random = seed is int s ? new Random(s) : new Random();
        }

        /// <summary>
        /// Called when the scene starts.
        /// </summary>
        public virtual void OnStart(Router router, GameBase game, Dictionary<string, object> args) { }

        /// <summary>
        /// Called when updating frame of the scene.
        /// </summary>
        public virtual void OnUpdate(Router router, GameBase game, DFEventArgs e) { }

        /// <summary>
        /// Called when the scene is disposed.
        /// </summary>
        public virtual void OnDestroy(Router router) { }
    }
}