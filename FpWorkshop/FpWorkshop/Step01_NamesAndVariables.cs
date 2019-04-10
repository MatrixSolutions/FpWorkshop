namespace FpWorkshop
{
  public class Step01_NamesAndVariables
  {
    public static void Run()
    {
      // Challenge 1 --------------------------------------
      var a = ReplaceMe.__<int>();

      Help.Ensure(a == 42);

      // Challenge 2 --------------------------------------
      var b = 75;
      
      //var b = 99; Question: why does this work in F# but not C#?

      Help.Ensure(b == ReplaceMe.__<int>());

      // Challenge 3 --------------------------------------
      var c = 21;

      c = c + 1;

      Help.Ensure(c == ReplaceMe.__<int>());

      // Challenge 4 --------------------------------------
      long d = 42; // For reference, no change needed here

      Help.Ensure(d is long);

      // Challenge 5 --------------------------------------
      string e = "Hello";

      e = e + " FP";

      Help.Ensure(e == ReplaceMe.__<string>());
    }
  }
}
