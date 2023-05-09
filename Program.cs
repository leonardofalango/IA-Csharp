
StreamReader sr = new StreamReader("data/gender_classification.csv");
// Removing first line
sr.ReadLine();

List<float[]> valuesX = new List<float[]>();
List<float> valuesY = new List<float>();
float[] aux;
float value;

while (!sr.EndOfStream)
{
    string line = sr.ReadLine();
    string[] data = line.Split(",");
    aux = new float[data.Length - 1];

    for (int i = 0; i < data.Length; i++)
    {
        if (i == data.Length - 1) // the target value
        {
            value = data[i][0] == 'M'? 1 : 0;
            valuesY.Add(value);
        }

        else
        {
            if (data[i] != "1" && data[i] != "0")
                continue;
            value = float.Parse(data[i]);
            aux[i] = value;
        }
    }
    valuesX.Add(aux.ToArray()); // To copy array

}

MultinomialNaiveBayes nb = new MultinomialNaiveBayes();
nb.Fit(valuesX.ToArray(), valuesY.ToArray());

System.Console.WriteLine("PriorProb: ");
foreach(var item in nb.PriorProbabilities)
    System.Console.Write(item + " ");

System.Console.WriteLine("\nClass0: ");
foreach(var item in nb.ProbabilityClass0)
    System.Console.Write(item + " ");

System.Console.WriteLine("\nClass1: ");
foreach(var item in nb.ProbabilityClass1)
    System.Console.Write(item + " ");