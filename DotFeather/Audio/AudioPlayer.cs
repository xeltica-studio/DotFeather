using System;
using System.Threading.Tasks;
using OpenTK.Audio;

namespace DotFeather.Audio
{
    public class AudioPlayer : IDisposable
    {
        public AudioPlayer()
        {
            ctx = new AudioContext();
        }

        public static Task PlayInstantlyAsync(IAudioSource source)
        {
            return Task.Run(() =>
            {
                using (var ap = new AudioPlayer())
                {

                }
            });
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        private readonly AudioContext ctx;
    }
}
