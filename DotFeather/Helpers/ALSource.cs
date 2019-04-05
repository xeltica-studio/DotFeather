using OpenTK.Audio.OpenAL;
namespace DotFeather.Helpers
{
    public class ALSource : OpenTKManagedHandleBase<int>
    {
        public override int GenerateHandle() => AL.GenSource();
        public override void DisposeHandle() => AL.DeleteSource(Handle);
    }
}
