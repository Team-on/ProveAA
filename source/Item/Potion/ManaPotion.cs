﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveAA.Item.Potion {
	class ManaPotion : BasicPotion {
		public override bool CardUsed(Creature.Player player) {
			player.manaPoints.Current += (byte)(player.manaPoints.Max * Game.Settings.potion_Mana_ManaPersent);
			return true;
		}

		public override Uri GetImageForCard() =>
			new Uri(Environment.CurrentDirectory + @"\img\potion\ManaCard.png", UriKind.Absolute);

		public override Uri GetImageForCell() =>
			new Uri(Environment.CurrentDirectory + @"\img\potion\ManaCell.png", UriKind.Absolute);
	}
}
