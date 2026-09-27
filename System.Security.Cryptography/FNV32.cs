using System.Runtime.CompilerServices;

namespace System.Security.Cryptography;

public class FNV32 : FNVHash
{
	public override byte[] Hash => BitConverter.GetBytes((uint)hash);

	public override int HashSize => 32;

	public FNV32()
		: base(16777619uL, 2166136261uL)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint GetHash(ReadOnlySpan<char> text)
	{
		return S3Launcher.FNV.FNV32(text);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint GetHash(string text)
	{
		return S3Launcher.FNV.FNV32(text);
	}
}
