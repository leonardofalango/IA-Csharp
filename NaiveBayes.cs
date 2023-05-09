public class NaiveBayes
{
    public float[][] X { get; set; }
    public float[] y { get; set; }
    public void Fit(float[][] X, float[] y)
    {
        this.X = X;
        this.y = y;
    }
}

public class MultinomialNaiveBayes
{
    public float[][] X { get; set; }
    public float[] y { get; set; }
    public float[] PriorProbabilities { get; private set; }
    public float[] ProbabilityClass0 { get; private set; }
    public float[] ProbabilityClass1 { get; private set; }
    public void Fit(float[][] X, float[] y)
    {
        this.X = X;
        this.y = y;

        // Fitting is getting the probabilities

        
        // Prior Probability
        float[] classesCount = new float[2];
        
        // transforming into a zero array
        for (int i = 0; i < classesCount.Length; i++)
            classesCount[i] = 0;
        
        for (int i = 0; i < y.Length; i++)
            classesCount[(int)y[i]] += 1;

        for (int i = 0; i < classesCount.Length; i++)
            classesCount[i] = classesCount[i] / X.Length;
        PriorProbabilities = classesCount;
        // Finished Prior

        // Getting Probabilities
        float[] probabilityClass0 = new float[X[0].Length];
        float[] probabilityClass1 = new float[X[0].Length];
        int countClass0 = 0;
        int countClass1 = 0;


        // Class 0
        for (int i = 0; i < y.Length; i++)
        {
            if (y[i] == 0)
            {
                for (int x = 0; x < X[0].Length; x++)
                    probabilityClass0[x] += X[i][x];
                countClass0++;
                System.Console.WriteLine("class0");
            }
            if (y[i] == 1)
            {
                for (int x = 0; x < X[0].Length; x++)
                    probabilityClass1[x] += X[i][x];
                countClass1++;   
                System.Console.WriteLine("class0");
            }
        }

        // Calculatin prob
        for (int i = 0; i < X[0].Length; i++)
        {
            probabilityClass0[i] /= countClass0;
            probabilityClass1[i] /= countClass1;
        }

        ProbabilityClass0 = probabilityClass0;
        ProbabilityClass1 = probabilityClass1;

    }

    public float SinglePredict(float[] features)
    {
        float pred = 0;

        return pred;
    }

}