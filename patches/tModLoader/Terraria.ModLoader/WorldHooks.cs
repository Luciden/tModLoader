﻿using System.Collections.Generic;
using Terraria.World.Generation;

namespace Terraria.ModLoader
{
	public static class WorldHooks
	{
		internal static readonly IList<ModWorld> worlds = new List<ModWorld>();

		internal static void Add(ModWorld modWorld)
		{
			worlds.Add(modWorld);
		}

		internal static void Unload()
		{
			worlds.Clear();
		}

		public static void PostWorldGen()
		{
			foreach (ModWorld modWorld in worlds)
			{
				modWorld.PostWorldGen();
			}
		}

		public static void ModifyWorldGenTasks(List<GenPass> passes, ref float totalWeight)
		{
			foreach (ModWorld modWorld in worlds)
			{
				modWorld.ModifyWorldGenTasks(passes, ref totalWeight);
			}
		}

		public static void PreWorldGen()
		{
			foreach (ModWorld modWorld in worlds)
			{
				modWorld.PreWorldGen();
			}
		}
	}
}