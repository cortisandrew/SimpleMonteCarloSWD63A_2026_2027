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

    public double EstimateVariance()
    {
        double mu_estimate = EstimateExpectedValue();

        return
            _results!.Sum(
                x => Math.Pow(x - mu_estimate, 2.0)) /
                (_results!.Count - 1);
    }

    public double EstimateStandardDeviation()
    {
        return Math.Sqrt(EstimateVariance());
    }

    public double RMSE(double? standardDeviation = null)
    {
        if (_results == null || _results.Count == 0)
        {
            throw new InvalidOperationException("To estimate the expected value, you need to run some simulations");
        }

        standardDeviation ??= EstimateStandardDeviation();

        return standardDeviation.Value / Math.Sqrt(_results.Count);
    }

    public int RequiredSimulations(double maxRMSE, 
                                   double? standardDeviation = null)
    {
        // If standard deviation is not passed as a parameter, estimate it from _results
        standardDeviation ??= EstimateStandardDeviation();

        return (int)Math.Ceiling(
                Math.Pow(standardDeviation.Value, 2.0) /
                Math.Pow(maxRMSE, 2.0));
    }
}
