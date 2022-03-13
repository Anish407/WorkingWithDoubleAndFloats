// See https://aka.ms/new-console-template for more informati
List<(string sizeName, int share)> shares = new List<(string size, int share)>();
string input = string.Empty;


do
{
    Console.WriteLine("Enter a Sample, S: 50.. PRESS c to exit");
    input = Console.ReadLine() ?? throw new Exception("Nulls not allowed");
    var data = input.Split(':');

    if (!input.Equals("c"))
        shares.Add((data[0], Int32.Parse(data[1])));

} while (input != "c");

if (shares.Sum(i => i.share) != 100)
{
    return;
    Console.WriteLine("Sum is  not 100");
}

Console.WriteLine("Enter total quantities");
double total = double.Parse(Console.ReadLine() ?? throw new Exception("Nulls not allowed"));

//List<int> shares = new List<int>() { 25, 20, 10, 45 };

void AdjustDistribution(SampleeDistributorModel result)
{
    result.roundedPercentage -= 1;
}



double calculatedTotal = 0;
List<SampleeDistributorModel> result = new List<SampleeDistributorModel>();

do
{
    result = shares.Select(x => SampleDistributor.CaclulateShare(total, x)).ToList();
    calculatedTotal = result.Sum(i => i.roundedPercentage);

    if (total == calculatedTotal) break;

    if (calculatedTotal < total)
    {
        var obj =  result.Where(i => i.decimalPart < 0.5).OrderByDescending(i => i.decimalPart).FirstOrDefault();

        obj.roundedPercentage += 1;
    }
    else
    {
        var obj = result.Where(i => i.decimalPart > 0.5).OrderByDescending(i => i.decimalPart).LastOrDefault();
        obj.roundedPercentage -= 1;
    }

    calculatedTotal = result.Sum(i => i.roundedPercentage);

} while (total != calculatedTotal);

Console.WriteLine("--------- Size distributions are --------------");
result.ForEach(i => Console.WriteLine($"Size Name:{i.sizeName}, Percentage: {i.roundedPercentage}"));












Console.WriteLine("---------------------------------------------");
