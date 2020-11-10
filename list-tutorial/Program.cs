using System;
using System.Collections.Generic;

namespace list_tutorial
{
  class Program
  {
    static void WorkingWithStrings()
    {
      var names = new List<string> { "Serjo", "Ana", "Felipe" };
      foreach (var name in names)
      {
        Console.WriteLine($"Hello {name.ToUpper()}!");
      }
      Console.WriteLine();
      names.Add("Marina");
      names.Add("Bill");
      names.Remove("Ana");
      foreach (var name in names)
      {
        Console.WriteLine($"Hello {name.ToUpper()}!");
      }
      Console.WriteLine($"My name is {names[0]}");
      Console.WriteLine($"I've added {names[2]} to the list");
      Console.WriteLine($"The list has {names.Count} people in it");
      var index = names.IndexOf("Felipe");
      if (index == -1)
        Console.WriteLine($"When an item is not found, IndexOf return {index}");
      else Console.WriteLine($"The name {names[index]} is at index {index}");

      index = names.IndexOf("Not Found");
      if (index == -1) Console.WriteLine($"When an item is not found, indexOf return {index}");
      else Console.WriteLine($"The name {names[index]} is at index {index}");
      names.Sort();
      foreach (var name in names) Console.WriteLine($"Hello {name.ToUpper()}!");

    }
    static void Main(string[] args)
    {
      //   WorkingWithStrings();
      var fibonacciNumbers = new List<int> { 1, 1 };
      var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
      var previousTwo = fibonacciNumbers[fibonacciNumbers.Count - 2];
      fibonacciNumbers.Add(previous + previousTwo);
      foreach (var item in fibonacciNumbers) Console.WriteLine(item);
      while (fibonacciNumbers.Count < 20)
      {
        previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
        previousTwo = fibonacciNumbers[fibonacciNumbers.Count - 2];
        fibonacciNumbers.Add(previous + previousTwo);
      }
      foreach (var item in fibonacciNumbers) Console.WriteLine(item);
    }
  }
}
