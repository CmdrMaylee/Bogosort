using System.Diagnostics;

ArrayHandle ArrHandl = new();
Stopwatch sw = new();

int attempts = 0, millionAttempts = 0, allButTwo = 0;
int[] sortThis = ArrHandl.CreateOrderedArray(11);
int[] referenceArr = ArrHandl.CreateOrderedArray(sortThis.Length);
ArrHandl.RandomizeArray(ref sortThis);

sw.Start();
while (!ArrHandl.ArrayIsSorted(sortThis))
{
    allButTwo += ArrHandl.ArrayAlmostSorted(sortThis, referenceArr);

    attempts++;
    if (attempts % 1000000 == 0)
    {
        Console.Clear();
        sw.Stop();
        attempts = 0;
        millionAttempts++;
        ArrHandl.PrintArray(sortThis);
        sw.Start();
    }
    ArrHandl.RandomizeArray(ref sortThis);
}
sw.Stop();
attempts += (millionAttempts * 1000000);

Console.Clear();
ArrHandl.PrintArray(sortThis);
Console.WriteLine($"\nThe list is sorted!\nElapsed time: {sw.Elapsed}\n#Attempts: {attempts:N0}\nCorrectly sorted, except for two numbers: {allButTwo}");
Console.ReadLine();
