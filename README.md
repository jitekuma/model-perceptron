# model-perceptron

A learning project that implements a simple perceptron using .NET 10.

## Projects

- `src/matrixhelper` - Generic dot-product helper.
- `src/training` - Trains perceptron weights from labeled input.
- `src/inference` - Uses trained weights to classify input values.

## Requirements

- .NET 10 SDK
- PowerShell

## Training

Training input must be comma-separated. The final value on each line must be the label `-1` or `1`.

Create a file named `training-data.txt`:

Run the training project and save the generated weights to `weights.txt`:


The resulting `weights.txt` contains one comma-separated line, for example:

The first weight is the bias weight. The remaining weights correspond to the input features.

## Inference

Inference input must contain one comma-separated feature vector per line. Do not include labels.

Create a file named `inputs.txt`:

Set the `WEIGHTS` environment variable to the weights file and pipe the inputs to the inference project:

Example output:

Each output line contains the original input values followed by the predicted label.

## Running from the project directory

From the repository root:

Train the model:

## SUM example

SUM is not linearly seperable so not a good example. 

## A+B> 1000 

Is a good example. Achive 100% accuracy with just 10% of training data.