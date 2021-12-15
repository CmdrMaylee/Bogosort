using System.Diagnostics;

ArrayHandle ArrHandl = new();
Stopwatch sw = new();

int attempts = 0, millionAttempts = 0;
int[] sortThis = ArrHandl.CreateOrderedArray(12);
ArrHandl.RandomizeArray(ref sortThis);

sw.Start();
while (!ArrHandl.ArrayIsSorted(sortThis))
{
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
Console.WriteLine($"\nThe list is sorted!\nElapsed time: {sw.Elapsed}\n#Attempts: {attempts:N0}");
Console.ReadLine();
