using SimpleMonteCarloSWD63A_2026_2027;

MonteCarloDriver driver = new MonteCarloDriver(new CoinTossGame());

// The driver can be used with any ISimulateable -- example, create your own ISimulateable AssignmentSimulation
// MonteCarloDriver driver2 = new MonteCarloDriver(new AssignmentSimulation());

int[] simulationSizes = [100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000];

foreach (int n in simulationSizes)
{
    driver.RunSimulations(n);

    var mu_estimate = driver.EstimateExpectedValue();

    Console.WriteLine($"The estimated mean using {n} simulations is {mu_estimate}. The absolute error is: {Math.Abs(mu_estimate - (-0.125))}");
}