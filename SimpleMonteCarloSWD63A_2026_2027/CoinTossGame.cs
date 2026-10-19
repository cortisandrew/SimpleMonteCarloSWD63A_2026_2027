using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMonteCarloSWD63A_2026_2027;

internal class CoinTossGame : ISimulateable
{
    public double Simulate()
    {
        // Probably better to use other PRNGs for dissertation or production environments
        bool headCoin1 =
            Random.Shared.NextDouble() < 0.5 ? false : true;
        bool headCoin2 =
            Random.Shared.NextDouble() < 0.5 ? false : true;

        // HH
        if (headCoin1 && headCoin2)
        {
            return 3.5;
        }
        // HT or TH
        else if (headCoin1 || headCoin2)
        {
            return -1;
        }
        // TT
        else
        {
            return -2;
        }
    }
}
