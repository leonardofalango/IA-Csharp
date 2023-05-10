public class KNN
{
    public float[][] X { get; set; }
    public float[] y { get; set; }
    public int K { get; set; }

    public void Fit(float[][] X, float[] y, int k = 0)
    {
        this.X = X;
        this.y = y;

        if (k == 0)
            K = (int)Math.Sqrt(X.Length);
            
        else
            K = k;
    }

    public float PredictSingleL1(float[] x)
    {
        float[] y;

        float[] dist = new float[X.Length];

        float[] minDist = new float[K];
        for(int i = 0; i < K; i++)
            minDist[i] = float.PositiveInfinity;

        int[] indexDist = new int[K];
        int index = 0;
        
        float[] distances = new float[K];
        
        for (int i = 0; i < X.Length; i++)
        {
            dist[i] = 0;
            for (int j = 0; j < X[0].Length; j++)
                dist[i] += Math.Abs(X[i][j] - x[j]);

            if (dist[i] < minDist.Min(e => e))
            {
                index = Array.IndexOf(minDist, minDist.Max());
                minDist[index] = dist[i];
                indexDist[index] = i;
            }            
        }

        // foreach (var item in minDist)
        //     System.Console.Write(item + " ");
        // System.Console.WriteLine("\n");
        // foreach (var item in indexDist)
        //     System.Console.Write(item + " ");

        return 0;
    }

    public float PredictSingleL2(float[] X)
    {
        float y = 0;
        return y;
    }

    public float[] Predict(float[][] X)
    {
        float[] y = new float[X.Length];
        return y;
    }

}