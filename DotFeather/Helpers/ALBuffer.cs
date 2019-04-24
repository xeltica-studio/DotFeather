using OpenTK.Audio.OpenAL;
namespace DotFeather
{
    public class ALBuffer : OpenTKManagedHandleBase<int>
    {
        public override int GenerateHandle() => AL.GenBuffer();
        public override void DisposeHandle() => AL.DeleteBuffer(Handle);
    }
}
