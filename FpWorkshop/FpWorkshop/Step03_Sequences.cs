using System;
using System.Collections.Generic;
using System.Linq;

namespace FpWorkshop
{
  public class Step03_Sequences
  {
    public static void Run()
    {
      // Challenge 1 --------------------------------------
      // What's your intuition on arrays? In other words, why use it over other enumerables?
      var anArray = new[] {1, 3, 5};

      Help.Ensure(anArray.SequenceEqual(new [] {1, 3, 5}));

      // Challenge 2 --------------------------------------
      Help.Ensure(anArray[2] == 5);

      // Challenge 3 --------------------------------------
      // What's your intuition on lists? In other words, why use it over other enumerables?
      var aList = new List<int> { 7, 11, 13, 17 };

      Help.Ensure(aList.SequenceEqual(new List<int> { 7, 11, 13, 17 }));

      // Challenge 4 --------------------------------------
      // What's your intuition on sets? In other words, why use it over other enumerables?
      var aSet = new HashSet<int> {1, 2, 3, 7 };

      Help.Ensure(aSet.SequenceEqual(new HashSet<int> {1, 2, 3, 7 }));

      // Challenge 5 --------------------------------------
      // Seq in F# is very very similar to an IEnumerable in C#.
      // What's your intuition on IEnumerables? In other words, why use it over more specific types?
      var anEnumerable = Enumerable.Range(25, 100);

      Help.Ensure(anEnumerable.First() == 25);

      // NOTE: From now on we'll use IEnumerable because it's the preferred
      // type of LINQ

      // Challenge 6 --------------------------------------
      Help.Ensure(new [] { 42 }.First() == 42);

      // Challenge 7 --------------------------------------
      // In C# you can approximate tail with Skip 1, in F# this is the same as `Seq.drop 1`
      Help.Ensure(new [] { 1, 2, 3, 4 }.Skip(1).SequenceEqual(new [] { 2, 3, 4 }));

      // Challenge 8 --------------------------------------
      var r1 = new[] {"hi", "howdy", "yo", "sup", "hello"}.Where(StartsWithH);

      Help.Ensure(r1.SequenceEqual(new[] {"hi", "howdy", "hello"}));

      // Challenge 9 --------------------------------------
      var noYo = new[] {"hi", "howdy", "yo", "sup", "hello"}
        .Where(x => x != "yo");

      Help.Ensure(noYo.SequenceEqual(new[] { "hi", "howdy", "sup", "hello" }));

      // Challenge 10 --------------------------------------
      // Can't be done in C#

      // Challenge 11 --------------------------------------
      // `Select` is LINQ's version of `map`
      var allIncremented = new[] {0, 1, 2, 3}
        .Select(x => x + 1);

      Help.Ensure(allIncremented.SequenceEqual(new[] {1, 2, 3, 4}));

      // Challenge 12 --------------------------------------
      // `SelectMany` is C#'s version of `collect`
      var doubled = new[] {1, 2, 3}
        .SelectMany(Double);

      Help.Ensure(doubled.SequenceEqual(new [] { 1, 1, 2, 2, 3, 3 }));

      // Challenge 13 --------------------------------------
      // `collect` is super powerful. It can even be used to do a sort of
      // `map` and `filter` in one step
      var exclaimOnlyStartsWithH =
        new [] {"hi", "howdy", "yo", "sup", "hello" }
          .SelectMany(v => StartsWithH(v) ? new [] {v + "!"} : new string[] {});

      Help.Ensure(exclaimOnlyStartsWithH.SequenceEqual(new [] {"hi!", "howdy!", "hello!" }));

      // Challenge 14 --------------------------------------
      // `Aggregate` is the LINQ version of fold
      var sum = new[] {1, 2, 3, 4}.Aggregate(0, (a, b) => a + b);

      Help.Ensure(sum == 10);

      // Challenge 15 --------------------------------------
      // the `0` was the initial value, or the value used if given an empty list
      var a1 = Enumerable.Empty<int>().Aggregate(0, (a, b) => a + b);
      Help.Ensure(a1 == 0);

      var a2 = new [] {1, 2, 3}.Aggregate(100, (a, b) => a + b);
      Help.Ensure(a2 == 106);

      // Challenge 16 --------------------------------------
      // the result type can be different from the elements' type!
      Func<string, int> stringLen = x => x.Length;

      var totalStringLen = new[] {"good", "day", "mate"}
        .Aggregate(0, (result, aStr) => result + stringLen(aStr));

      Help.Ensure(totalStringLen == 11);
    }

    private static bool StartsWithH(string x) => x.StartsWith("h");
    private static IEnumerable<T> Double<T>(T x) => new[] {x, x};
  }
}
