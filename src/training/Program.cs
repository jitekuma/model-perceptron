/*
 1. Declare the List W is zero vector in IList
 2. Delcare a List of IList called inputs. Which we will use to store the trainign inputs.
 3. Declare the IList of integer type which will be used to tore the y value of each inupt line. Call it yvalue
4. Read a line from console. Its a comma seperated line and the last value in the line should be -1 or +1. This last value is the the y value.
5. Add a new List in the inputs. The first element is 1 followed by all the elements read in previous line except the last element which is either -1 or 1. Store last element in yvalue list.
6. Now do below steps in loop which can run maximum 1000 times.
6.1 Store the value of W in a tempW List.
6.2 Do this once for each element in the inputs 
6.2.1 multiply y vlaue of that input with the value returned by dot method of matrix multiplication. Dot(W, this input). if the value is less than and equal to zero do 6.2.2 otherwsie go for next input value
6.2.2 update W to old W + y value of that input * input
7. If thier was no change in W in the current itteration. Terminate the outer loop.
8. Print the value of each element in W
 */
using System.Globalization;

var inputs = new List<IList<int>>();
var yValues = new List<int>();

int? featureCount = null;

while (true)
{
    var line = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(line))
    {
        break;
    }

    var values = line
        .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
        .Select(value => int.Parse(value, CultureInfo.InvariantCulture))
        .ToList();

    if (values.Count < 2)
    {
        Console.WriteLine("Each row must contain at least one feature and a label.");
        continue;
    }

    var yValue = values[^1];

    if (yValue is not (-1 or 1))
    {
        Console.WriteLine("The last value must be -1 or 1.");
        continue;
    }

    var features = values.Take(values.Count - 1).ToList();

    if (featureCount is null)
    {
        featureCount = features.Count;
    }
    else if (features.Count != featureCount)
    {
        Console.WriteLine($"Each row must contain exactly {featureCount} features.");
        continue;
    }

    // Add the bias input as the first element.
    inputs.Add([1, .. features]);
    yValues.Add(yValue);
}

if (inputs.Count == 0)
{
    Console.WriteLine("No training data was provided.");
    return;
}

var weights = Enumerable
    .Repeat(0, inputs[0].Count)
    .ToList();

const int maxIterations = 1000;

for (var iteration = 0; iteration < maxIterations; iteration++)
{
    var previousWeights = weights.ToList();
    var updates = 0;

    for (var i = 0; i < inputs.Count; i++)
    {
        var prediction = Dot(weights, inputs[i]);
        var yValue = yValues[i];

        if (yValue * prediction <= 0)
        {
            updates++;
            for (var j = 0; j < weights.Count; j++)
            {
                weights[j] += yValue * inputs[i][j];
            }
        }
    }

    if (updates == 0)
    {
        break;
    }
}

Console.WriteLine(string.Join(",", weights));

static int Dot(IList<int> vector1, IList<int> vector2)
{
    if (vector1.Count != vector2.Count)
    {
        throw new ArgumentException("Vectors must have the same number of elements.");
    }

    var result = 0;

    for (var i = 0; i < vector1.Count; i++)
    {
        result += vector1[i] * vector2[i];
    }

    return result;
}