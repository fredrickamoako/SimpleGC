﻿using SimpleGC;

Console.WriteLine("***** Fun with System.GC *****");
Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
Console.WriteLine("This OS has {0} object generations. \n", (GC.MaxGeneration + 1));

Car refToMyCar = new Car("Zippy", 100);
Console.WriteLine(refToMyCar.ToString());

Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));
// Make a ton of objects for testing purposes.
object[] tonsOfObjects = new object[50000];
for (int i = 0; i < 50000; i++)
    tonsOfObjects[i] = new object();
// Collect only gen 0 objects.
GC.Collect(0, GCCollectionMode.Forced);
GC.WaitForPendingFinalizers();
// Print out generation of refToMyCar.
Console.WriteLine("Generation of refToMyCar is: {0}",
GC.GetGeneration(refToMyCar));
// See if tonsOfObjects[9000] is still alive.
if (tonsOfObjects[9000] != null)
{
    Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonsOfObjects[9000]));
}
else
    Console.WriteLine("tonsOfObjects[9000] is no longer alive.");
// Print out how many times a generation has been swept.
Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));
Console.Beep();