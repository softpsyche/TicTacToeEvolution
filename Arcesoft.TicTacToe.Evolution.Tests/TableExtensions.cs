using Arcesoft.TicTacToe.Entities;
using Arcesoft.TicTacToe.Evolution.Environs;
using Arcesoft.TicTacToe.Evolution.Organisms;
using FluentAssertions;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Arcesoft.TicTacToe.Evolution.Tests
{
    internal static class TableExtensions
    {
        public static IEnumerable<T> CreateSetWithContainer<T>(this Table table, Container container)
            where T: class
        {
            return table.CreateSet(a => container.GetInstance<T>());
        }

        public static IEnumerable<Gene> ToGenes(this Table table)
        {
            return table.CreateSet(a => a.ToGene()).ToList();
        }

        public static IEnumerable<IPopulation> ToPopulations(this Table table,IInternalEvolutionFactory factory, EvolutionSettings evolutionSettings)
        {
            return table.CreateSet(a => factory.CreatePopulation(evolutionSettings)).ToList();
        }

        public static Gene ToGene(this TableRow tableRow)
        {
            return new Gene(
                tableRow[nameof(Gene.Turn)].ToEnumeration<Turn>(),
                Convert.ToInt32(tableRow[nameof(Gene.Priority)]),
                tableRow["Alleles"].Select(a => a.ToAllele()).ToArray());
        }
        public static IEnumerable<Allele> ToAlleles(this Table table)
        {
            List<Allele> alleleList = new List<Allele>();

            table.Rows.Count.Should().Be(3, "The table should have three rows");
            table.Rows[0].Count.Should().Be(3, "Each row in the table should have 3 entries");

            table.Rows.ForEach(a => 
            {
                a.Values.ForEach(b => alleleList.Add(String.IsNullOrWhiteSpace(b)? Allele.Empty: b.ToAllele()));
            });

            return alleleList;
        }

        public static IEnumerable<Move> ToPlausibleMoveList(this Table table)
        {
            var boardString = ToBoardString(table);
            List<Move> plausibleMoveList = new List<Move>();
            List<Move> xMoves = new List<Move>();
            List<Move> oMoves = new List<Move>();

            for (int i = 0; i < boardString.Length; i++)
            {
                switch (boardString[i])
                {
                    case BoardConstants.SquareXChar:
                        xMoves.Add((Move)i);
                        break;
                    case BoardConstants.SquareOChar:
                        oMoves.Add((Move)i);
                        break;
                }
            }

            Player curPlayer = Player.X;
            var totalMoves = xMoves.Count + oMoves.Count;
            for (int i = 0; i < totalMoves; i++)
            {
                if (curPlayer == Player.X)
                {
                    plausibleMoveList.Add(xMoves.First());
                    xMoves.Remove(xMoves.First());
                    curPlayer = Player.O;
                }
                else
                {
                    plausibleMoveList.Add(oMoves.First());
                    oMoves.Remove(oMoves.First());
                    curPlayer = Player.X;
                }

            }

            return plausibleMoveList;
        }

        public static IEnumerable<Move> ToMoves(this Table table)
        {
            return table.CreateSet((a) => a[0].ToEnumeration<Move>());
        }
        //private static IEnumerable<Move> ToMoves(string commaDelimitedMoves)
        //{
        //    return commaDelimitedMoves
        //        .Split(',')
        //        .Select(a => a.ToEnumeration<Move>());
        //}


        private static string ToBoardString(this Table table)
        {
            StringBuilder sb = new StringBuilder();

            table.Rows.Count.Should().Be(3, "The table should have three rows");
            table.Rows[0].Count.Should().Be(3, "Each row in the table should have 3 entries");

            table.Rows.ForEach(a => sb.Append(string.Concat(ToSquareValues(a.Values))));

            return sb.ToString();
        }
        private static IEnumerable<String> ToSquareValues(IEnumerable<string> values)
        {
            return values.Select(a => ToSquareValue(a));
        }
        private static string ToSquareValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return BoardConstants.SquareEmptyString;
            }
            else if (BoardConstants.SquareXString.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                return BoardConstants.SquareXString;
            }
            else if (BoardConstants.SquareOString.Equals(value, StringComparison.InvariantCultureIgnoreCase))
            {
                return BoardConstants.SquareOString;
            }
            else
            {
                throw new InvalidOperationException($"Unable to create square value for string because the value '{value}' is not a valid tic tac toe board value");
            }
        }
    }
}
