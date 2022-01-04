using System.Diagnostics;

ArrayHandle ArrHandl = new();
Stopwatch sw = new();

int attempts = 0, millionAttempts = 0, allButTwo = 0;
int arraySize = 11;
int[] sortThis = ArrHandl.CreateOrderedArray(arraySize);
int[] referenceArr = ArrHandl.CreateOrderedArray(sortThis.Length);
ArrHandl.RandomizeArray(ref sortThis);

sw.Start();
while (!ArrHandl.ArrayIsSorted(sortThis))
{
    allButTwo += ArrHandl.ArrayAlmostSorted(sortThis, referenceArr);

    attempts++;
    if (attempts % 4000000 == 0)
    {
        sw.Stop();
        Console.Clear();
        attempts = 0;
        millionAttempts++;
        ArrHandl.PrintArray(sortThis);
        Console.Write(Environment.NewLine + "Near-Misses: " + allButTwo);
        sw.Start();
    }
    ArrHandl.RandomizeArray(ref sortThis);
}
sw.Stop();
ulong finalCount = (ulong)(attempts += (millionAttempts * 1000000));

Console.Clear();
ArrHandl.PrintArray(sortThis);
Console.WriteLine($"\nThe list is sorted!\nElapsed time: {sw.Elapsed}\nNo. of Attempts: {finalCount:N0}\nNo. of times almost sorted(All numbers except 2): {allButTwo}");
Console.ReadLine();
