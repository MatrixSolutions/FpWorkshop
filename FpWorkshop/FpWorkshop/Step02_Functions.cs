using System;

namespace FpWorkshop
{
  public class Step02_Functions
  {
    public static T ITellYouWhatYouToldMe<T>(T x) => x;

    public static void Run()
    {
      // Challenge 1 --------------------------------------

      Help.Ensure(ITellYouWhatYouToldMe(42) == ReplaceMe.__<int>());

      // Challenge 2 --------------------------------------
      Func<int, int> echo = x => x;

      // I don't think there's a way to inline `x => x`...
      Help.Ensure(echo(42) == ReplaceMe.__<int>());

      // Challenge 3 --------------------------------------
      Func<int, int, int> myAdd = (a, b) => a + b;

      Help.Ensure(myAdd(2, 3) == ReplaceMe.__<int>());

      // Challenge 4 --------------------------------------
      Func<int, int> specialAdd = x => myAdd(4, x); // In C#, we need to re-wrap the function to build a new one

      Help.Ensure(specialAdd(2) == ReplaceMe.__<int>());

      // Challenge 4 (aside) ------------------------------
      // Functions that return functions are referred to as "curried" functions.
      // So, currying is possible in C# but not natural feeling
      // ♫ How many Funcs must a dev type out
      //   before they call it curried?
      //   the answer my friends is always one too many
      //   the answer is one too many ♫
      Func<int, Func<int, int>> myAddCurried = ReplaceMe.__<Func<int, Func<int, int>>>();

      var myNewSpecialAdd = myAddCurried(4);

      Help.Ensure(myNewSpecialAdd(2) == 6);

      // Challenge 5 --------------------------------------
      // Additional challenge -- can you define a version of `AlwaysReturnTheFirst` using a local variable?
      Help.Ensure(AlwaysReturnTheFirst<string, int>("foo")(42) == "foo");

      // Challenge 6 --------------------------------------
      // There's not really a great way to illustrate this in C#...

      // Challenge 7 --------------------------------------
      // We can define it in C# too! Though something's a little off...

      Let(5, a =>
      Let(6, b =>
      {
        Help.Ensure(a + b == 11);

        return "Why do we need a return here?";
      }));

      // Challenge 8 --------------------------------------
      // Compare the type we use here with the one F# infers for us
      Func<Func<int, int>, int, int, int> applyThenMultiply = (f, a, b) => f(a) * f(b);

      var addOne = myAddCurried(1);

      Help.Ensure(applyThenMultiply(addOne, 4, 5) == ReplaceMe.__<int>());

      // Challenge 9 --------------------------------------
      // This function's not built-in in C# but we've seen it before...
      Help.Ensure(applyThenMultiply(ReplaceMe.__<Func<int, int>>(), 7, 3) == (7 * 3));

      // Challenge 10 --------------------------------------
      Help.Ensure(applyThenMultiply(ReplaceMe.__<Func<int, Func<int, int>>>()(5), 7, 3) == (5 * 5));

      // No more challenges in this file
    }

    private static TResult Let<T, TResult>(T value, Func<T, TResult> body) =>
      ReplaceMe.__<TResult>();

    // Given this signature, how many possible implementations are there?
    private static Func<T2, T1> AlwaysReturnTheFirst<T1, T2>(T1 v) =>
      ReplaceMe.__<Func<T2, T1>>();
  }
}
