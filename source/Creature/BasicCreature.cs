﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ProveAA.Interface;
using ProveAA.Support;
using ProveAA.Game;


namespace ProveAA.Creature {
	class BasicCreature {
		public readonly Stat armor;
		public readonly Stat attack;
		public readonly Bar hitPoints;
		public readonly Bar manaPoints;

		protected Grid imageGridLeftTopCorner;
		protected Grid imageGridMaze;

		public BasicCreature() {
			imageGridLeftTopCorner = new Grid();
			imageGridMaze = new Grid();
			Grid.SetZIndex(imageGridLeftTopCorner, 10);
			Grid.SetZIndex(imageGridMaze, 10);
			armor = new Stat();
			attack = new Stat();
			hitPoints = new Bar();
			manaPoints = new Bar();
		}
	}
}
