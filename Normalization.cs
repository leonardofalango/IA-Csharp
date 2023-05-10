public static class Normalization
{
    private static float[] mean_;
    public static float[] Mean
    {
        get { return mean_; }
        set { mean_ = value; }
    }
    
    private static float[] max;
    public static float[] Max
    {
        get { return max; }
        set { max = value; }
    }
    
    public static float[] Normalize(float[] arr)
    {
        float[] returnArr = new float[arr.Length];

        for (int i = 0; i < arr.Length; i++)
            returnArr[i] = (arr[i] - mean_[i]) / max[i];


        return returnArr;
    }

    public static float[][] Norm(float[][] matrix)
    {
        float[][] returnArr = new float[matrix.Length][];

        max = new float[matrix[0].Length];
        mean_ = new float[matrix[0].Length];

        for (int j = 0; j < matrix[0].Length; j++)
        {
            float maxValue = float.MinValue;
            float mean = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                mean += matrix[i][j];

                if (maxValue < matrix[i][j])
                    maxValue = matrix[i][j];
            }
            mean /= matrix.Length;

            max[j] = maxValue;
            mean_[j] = mean;
        }

        float[] aux = new float[matrix[0].Length];
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
                aux[j] = (matrix[i][j] - mean_[j]) / max[j];

            returnArr[i] = aux.ToArray();
        }


        return returnArr;
    }

    public static float[] GetTarget(float[][] data, int index=-1)
    {
        if (index == -1)
            index = data[0].Length - 1;

        if (index < 0 || index > data[0].Length)
            return new float[1];
        
        float[] target = new float[data.Length];
        for (int i = 0; i < data.Length; i++)
            target[i] = data[i][index];

        return target;        
    }

    public static float[][] GetFeatures(float[][] data)
    {
        float[][] features = new float[data.Length][];
        float[] aux = new float[data[0].Length];

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[0].Length - 1; j++)
                aux[j] = data[i][j];
            features[i] = aux.ToArray();
        }

        return features;
    }
}
