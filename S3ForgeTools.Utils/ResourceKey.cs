using System;
using System.Collections.Generic;
using System.Globalization;
using s3pi.Interfaces;

namespace S3ForgeTools.Utils;

public class ResourceKey : AResourceKey
{
	public override List<string> ContentFields => null;

	public override int RecommendedApiVersion => 1;

	public ResourceKey(int APIversion, EventHandler handler)
		: base(APIversion, handler)
	{
	}

	public ResourceKey(int APIversion, EventHandler handler, IResourceKey basis)
		: this(APIversion, handler)
	{
		instance = basis.Instance;
		ResourceGroup = basis.ResourceGroup;
		ResourceType = basis.ResourceType;
	}

	public ResourceKey(int APIversion, EventHandler handler, uint resourceType, uint resourceGroup, ulong instance)
		: this(APIversion, handler)
	{
		Instance = instance;
		ResourceGroup = resourceGroup;
		ResourceType = resourceType;
	}

	public override AHandlerElement Clone(EventHandler handler)
	{
		return null;
	}

	private static uint ToHex8(ReadOnlySpan<char> hex)
	{
		if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
		{
			hex = hex.Slice(2);
		}
		return uint.Parse(hex, NumberStyles.HexNumber);
	}

	private static ulong ToHex16(ReadOnlySpan<char> hex)
	{
		if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
		{
			hex = hex.Slice(2);
		}
		return ulong.Parse(hex, NumberStyles.HexNumber);
	}

	public void SetTGI(string ResourceType, string ResourceGroup, string Instance)
	{
		SetTGI(ToHex8(ResourceType), ToHex8(ResourceGroup), ToHex16(Instance));
	}

	public void SetTGI(uint ResourceType, uint ResourceGroup, ulong Instance)
	{
		this.ResourceType = ResourceType;
		this.ResourceGroup = ResourceGroup;
		this.Instance = Instance;
	}
}
