// See https://aka.ms/new-console-template for more informati


public static class SampleDistributor
{
    public static SampleeDistributorModel CaclulateShare(double total, (string sizeName, int share) percentage )
    {
        double percentageDistribution = (percentage.share* total) / 100;
        double decimalPart2 = Math.Round(percentageDistribution, 2);
        double decimalPart = Math.Round((decimalPart2 - Math.Truncate(decimalPart2)), 2);
    
        double roundedPercentage = Math.Round(decimalPart2, 0, MidpointRounding.AwayFromZero);

        return new SampleeDistributorModel
        {
            decimalPart = decimalPart,
            roundedPercentage = roundedPercentage,
            percentageDistribution = percentageDistribution,
            sizeName= percentage.sizeName
        };
    }
}


public class SampleeDistributorModel
{
    public double percentageDistribution { get; set; }
    public double roundedPercentage { get; set; }
    public double decimalPart { get; set; }
    public string sizeName { get; set; }
}
