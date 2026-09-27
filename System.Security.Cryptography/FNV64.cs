using System.Runtime.CompilerServices;

namespace System.Security.Cryptography;

public class FNV64 : FNVHash
{
	public override byte[] Hash => BitConverter.GetBytes(hash);

	public override int HashSize => 64;

	public FNV64()
		: base(1099511628211uL, 14695981039346656037uL)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong GetHash(ReadOnlySpan<char> text)
	{
		return S3Launcher.FNV.FNV64(text);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong GetHash(string text)
	{
		return S3Launcher.FNV.FNV64(text);
	}
}
