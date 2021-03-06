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

namespace ProveAA.Map {
	class GameMap {
		public GlobalGameMap globalMap;
		GameCell[,] map;

		public byte SizeY => (byte)map.GetLength(0);
		public byte SizeX => (byte)map.GetLength(1);

		public GameMap(Windows.GameWindow window) {
			globalMap = new GlobalGameMap();

			map = new GameCell[Game.Settings.map_sizeY, Game.Settings.map_sizeX];
			for (byte i = 0; i < map.GetLength(0); ++i) {
				window.MazeGrid.RowDefinitions.Add(new RowDefinition());
				for (byte j = 0; j < map.GetLength(1); ++j) 
					map[i, j] = new GameCell();
			}
			for (byte j = 0; j < map.GetLength(1); ++j)
				window.MazeGrid.ColumnDefinitions.Add(new ColumnDefinition());
		}

		public void NewLevel(Creature.Player player) {
			ClearMap();
			RandomFill(player);
			player.ChangeToMaze();
		}

		public void OutputMap(Windows.GameWindow window) {
			for (byte i = 0; i < map.GetLength(0); ++i)
				for (byte j = 0; j < map.GetLength(1); ++j) {
					Grid.SetRow(map[i, j].imageCell, i);
					Grid.SetColumn(map[i, j].imageCell, j);
					Grid.SetZIndex(map[i, j].imageCell, 0);
					window.MazeGrid.Children.Add(map[i, j].imageCell);

					Grid.SetRow(map[i, j].imageContent, i);
					Grid.SetColumn(map[i, j].imageContent, j);
					Grid.SetZIndex(map[i, j].imageContent, 1);
					window.MazeGrid.Children.Add(map[i, j].imageContent);
				}
			for (int i = 0; i < Game.Settings.handSize; ++i)
				window.CardsGrid.ColumnDefinitions.Add(new ColumnDefinition());

			for (byte i = 0; i < map.GetLength(0); ++i)
				for (byte j = 0; j < map.GetLength(1); ++j)
					map[i, j].IsWall = !map[i, j].IsWall;
			for (byte i = 0; i < map.GetLength(0); ++i)
				for (byte j = 0; j < map.GetLength(1); ++j)
					map[i, j].IsWall = !map[i, j].IsWall;
		}

		void ClearMap() {
			for (byte i = 0; i < map.GetLength(0); ++i)
				for (byte j = 0; j < map.GetLength(1); ++j)
					map[i, j].RefillValue();
			for (byte i = 1; i < map.GetLength(0) - 1; ++i)
				for (byte j = 1; j < map.GetLength(1) - 1; ++j)
					map[i, j].IsWall = false;
		}

		void RandomFill(Creature.Player player) {
			globalMap.RecreateLevel(this, player);
		}

		public GameCell this[byte a, byte b] {
			get {
				if (a < 0 || a >= SizeY || b < 0 || b >= SizeX)
					return null;
				return map[a, b];
			}
			set => map[a, b] = value;
		}
	}
}

