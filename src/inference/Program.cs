
/*
 1. Read the content from the text file at the path stored in env variable WEIGHTS
 2. the weights file contains a list of comma seperated values store it in weights List.
 3. Decalre a List called input and set the first element as 1.
 4. Read a comma seperated line from the Console and add elements in the input list.
 5. Use the matrichelper Dot method to get a dotproduct of  weights and input.
 6. print all the lements passed as input and +1 if if dot product was positive. -1 if dot product was negative or zero. Print it in one line with values seperated by comma
 */
using System.Globalization;
using matrixhelper;

var weightsPath = Environment.GetEnvironmentVariable("WEIGHTS");

if (string.IsNullOrWhiteSpace(weightsPath))
{
    Console.Error.WriteLine("The WEIGHTS environment variable is not set.");
    return;
}

if (!File.Exists(weightsPath))
{
    Console.Error.WriteLine($"Weights file not found: {weightsPath}");
    return;
}

var weights = File.ReadAllText(weightsPath)
    .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
    .Select(value => int.Parse(value, CultureInfo.InvariantCulture))
    .ToList();

var matrix = new Matrix<int>();
var expectedInputCount = weights.Count - 1;

while(true)
{
    var inputLine = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(inputLine))
    {
        break;
    }

    var input = inputLine
        .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
        .Select(value => int.Parse(value, CultureInfo.InvariantCulture))
        .ToList();

    if (input.Count != expectedInputCount)
    {
        Console.Error.WriteLine(
            $"Expected {expectedInputCount} input values, but received {input.Count}: {inputLine}");

        continue;
    }

    var inputWithBias = new List<int> { 1 };
    inputWithBias.AddRange(input);

    var dotProduct = matrix.Dot(weights, inputWithBias);
    var prediction = dotProduct > 0 ? 1 : -1;

    Console.WriteLine($"{string.Join(",", input)},{prediction}");
}