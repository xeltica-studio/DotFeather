namespace DotFeather
{
    public static class MiscUtility
    {
        public static void Swap<T>(ref T var1, ref T var2)
        {
            var tmp = var2;
            var2 = var1;
            var1 = tmp;
        }
	}
}
