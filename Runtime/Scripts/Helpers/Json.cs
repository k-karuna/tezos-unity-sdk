﻿using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TezosSDK.Helpers
{

	internal class SnakeCaseNamingPolicy : JsonNamingPolicy
	{
		public override string ConvertName(string name)
		{
			var buf = new List<char>();
			var abbreviation = 0;

			for (var i = 0; i < name.Length; i++)
			{
				if (name[i] <= 90 && name[i] >= 65)
				{
					if (abbreviation == 0 && i > 0)
					{
						buf.Add('_');
					}

					abbreviation++;
					buf.Add((char)(name[i] + 32));
				}
				else
				{
					if (abbreviation > 1)
					{
						buf.Insert(buf.Count - 1, '_');
					}

					abbreviation = 0;
					buf.Add(name[i]);
				}
			}

			return new string(buf.ToArray());
		}
	}

	public static class JsonOptions
	{
		public static readonly JsonSerializerOptions DefaultOptions = new()
		{
			AllowTrailingCommas = true,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			MaxDepth = 100_000,
			NumberHandling = JsonNumberHandling.AllowReadingFromString,
			PropertyNamingPolicy = new SnakeCaseNamingPolicy()
		};
	}

}