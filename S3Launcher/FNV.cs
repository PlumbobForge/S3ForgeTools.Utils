using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace S3Launcher;

public static class FNV
{
	public const ulong Prime64 = 1099511628211uL;
	public const ulong Offset64 = 14695981039346656037uL;

	public const uint Prime32 = 16777619u;
	public const uint Offset32 = 2166136261u;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint FNV32(ReadOnlySpan<char> value)
	{
		uint hash = Offset32;
		for (int i = 0; i < value.Length; i++)
		{
			char c = value[i];
			byte b = (byte)(c is >= 'A' and <= 'Z' ? c + 32 : c);
			hash *= Prime32;
			hash ^= b;
		}
		return hash;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint FNV32(ReadOnlySpan<byte> bytes)
	{
		uint hash = Offset32;
		for (int i = 0; i < bytes.Length; i++)
		{
			byte b = bytes[i];
			if (b is >= (byte)'A' and <= (byte)'Z') b = (byte)(b + 32);
			hash *= Prime32;
			hash ^= b;
		}
		return hash;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint FNV32(string value) => value != null ? FNV32(value.AsSpan()) : Offset32;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong FNV64(ReadOnlySpan<char> value)
	{
		ulong hash = Offset64;
		for (int i = 0; i < value.Length; i++)
		{
			char c = value[i];
			byte b = (byte)(c is >= 'A' and <= 'Z' ? c + 32 : c);
			hash *= Prime64;
			hash ^= b;
		}
		return hash;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong FNV64(ReadOnlySpan<byte> bytes)
	{
		ulong hash = Offset64;
		for (int i = 0; i < bytes.Length; i++)
		{
			byte b = bytes[i];
			if (b is >= (byte)'A' and <= (byte)'Z') b = (byte)(b + 32);
			hash *= Prime64;
			hash ^= b;
		}
		return hash;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong FNV64(string value) => value != null ? FNV64(value.AsSpan()) : Offset64;
}
