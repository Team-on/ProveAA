﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveAA.Interface {
	interface ICardContent {
		bool CardUsed(Creature.Player player);

		Uri GetImageForCard();
		Uri GetImageForCell();
	}
}
