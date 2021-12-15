class ArrayHandle
{
    public int[] CreateOrderedArray(int arrSize)
    {
        int[] result = new int[arrSize];
        for (int i = 0; i < arrSize; i++) result[i] = i + 1;

        return result;
    }

    public void RandomizeArray(ref int[] arr)
    {
        Random rand = new();
        int randomIndex, swap;
        for (int i = 0; i < arr.Length; i++)
        {
            randomIndex = rand.Next(arr.Length);

            swap = arr[i];
            arr[i] = arr[randomIndex];
            arr[randomIndex] = swap;
        }
    }

    public bool ArrayIsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++) if (arr[i] < arr[i - 1]) return false;
        return true;
    }

    public void PrintArray(int[] arr)
    {
        foreach (int num in arr) Console.Write($"{num} ");
    }
}
