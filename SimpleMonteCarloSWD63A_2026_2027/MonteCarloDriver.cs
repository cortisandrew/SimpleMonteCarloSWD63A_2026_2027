using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMonteCarloSWD63A_2026_2027;

public class MonteCarloDriver
{
    private ISimulateable _X;
    private List<double>? _results = null;

    public MonteCarloDriver(ISimulateable X)
    {
        _X = X;
    }

    public void RunSimulations(int n)
    {
        // create a new array based vector with initial capacity n
        _results = new List<double>(n);

        for (int i = 0; i < n; i++)
        {
            _results.Add(_X.Simulate());
        }
    }

    public double EstimateExpectedValue()
    {
        if ( _results == null || _results.Count == 0 )
        {
            throw new InvalidOperationException("To estimate the expected value, you need to run some simulations");
        }

        return _results.Average();  // Mean
    }

    // TODO: Add some methods to analyse the results in _results
}
