using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuiltyQueen
{
    internal static class ExtensionMethods
    {
        public static List<T> GetShuffled<T>(this List<T> cards)
        {
            return cards.OrderBy(x => new Guid()).ToList();
        }

        public static string GetString(this Rank rank)
        {
            return rank switch
            {
                Rank.Ace => "A",
                Rank.Queen => "Q",
                Rank.King => "K",
                Rank.Jack => "J",
                _ => ((int)rank).ToString(),
            };
        }

        public static string GetString(this Suit suit)
        {
            return suit switch
            {
                Suit.Spades => "♠",
                Suit.Hearts => "♥",
                Suit.Diamonds => "♦",
                Suit.Clubs => "♣",
                _ => "",
            };
        }

        public static bool In<T>(this T target, params T[] source)
        {
            return source.Contains(target);
        }

        public static string GetString(this List<Card> cards)
        {
            return string.Join(",", cards.Select(x => x.GetString()));
        }

        public static string GetString(this Card card)
        {
            return $"{card.Rank.GetString()}{card.Suit.GetString()}";
        }
    }
}
