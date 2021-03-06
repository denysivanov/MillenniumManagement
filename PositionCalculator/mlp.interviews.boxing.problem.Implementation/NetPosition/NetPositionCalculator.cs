﻿using System.Collections.Generic;
using System.Linq;
using mlp.interviews.boxing.problem.Interface.Entity;
using mlp.interviews.boxing.problem.Interface.Interfaces;

namespace mlp.interviews.boxing.problem.Implementation.NetPosition
{
    public class NetPositionCalculator : INetPositionCalculator
    {
        private readonly IOutputRecordConverter _outputRecordConverter;

        public NetPositionCalculator(IOutputRecordConverter outputRecordConverter)
        {
            _outputRecordConverter = outputRecordConverter;
        }

        public List<OutputRecord> Calculate(List<TestRecord> testResords)
        {
            var returnResults = new List<Interface.Entity.OutputRecord>();

            foreach (var trader in TraderDistinct(testResords))
            {
                foreach (var symbol in TraderSymbolDistinct(testResords, trader))
                {
                    returnResults.Add(NetPosition(testResords, trader, symbol));
                }
            }
            
            return returnResults;
        }

        private  OutputRecord NetPosition(List<TestRecord> testResords, string trader, string symbol)
        {
            var quantity = Quantity(testResords, trader, symbol);
            return _outputRecordConverter.Convert(trader, symbol, quantity);
        }

        private static int Quantity(List<TestRecord> testResords, string trader, string symbol)
        {
            return testResords.Where(x => x.Trader == trader & x.Symbol == symbol).Sum(y => y.Quantity);
        }

        private static IEnumerable<string> TraderSymbolDistinct(List<TestRecord> testResords, string trader)
        {
            return testResords.Where(x => x.Trader == trader).Select(y => y.Symbol).Distinct();
        }

        private static IEnumerable<string> TraderDistinct(List<TestRecord> testResords)
        {
            return testResords.Select(x => x.Trader).Distinct();
        }
    }
}