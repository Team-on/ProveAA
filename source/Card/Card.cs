﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProveAA.Interface;
using ProveAA.Support;
using ProveAA.Game;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProveAA.Creature;

namespace ProveAA.Card {
	class Card : Interface.ICellContent {
		Grid cardGrid;
		ICardContent cardContent;
		public static Windows.GameWindow window;

		public Card(ICardContent content) {
			cardContent = content;
		}

		public void AddToHand(Creature.Player player) {
			if (player.Cards.Count < 7) {
				player.Cards.Add(this);
				cardGrid = new Grid();
				cardGrid.MouseLeftButtonUp += (a, b) => {
					this.Use(player);
				};

				cardGrid.Children.Add(new TextBlock() { Text = "I am card, isnt it? \n " + cardContent.ToString().Substring(cardContent.ToString().LastIndexOf('.')+1) });

				Grid.SetColumn(cardGrid, player.Cards.Count - 1);
				window.CardsGrid.Children.Add(cardGrid);
			}
		}

		public void PlayerStepIn(Player player) {
			AddToHand(player);
		}

		public void Use(Creature.Player player) {
			cardContent.CardUsed(player);
			if (player.Cards[0] != this) {
				player.Cards.Remove(this);
				window.CardsGrid.Children.Remove(cardGrid);
				for (byte i = 0; i < player.Cards.Count; ++i)
					Grid.SetColumn(player.Cards[i].cardGrid, i);
			}
		}

		public Uri GetDisplayImage() {
			return cardContent.GetImageForCell();
		}
	}
}
