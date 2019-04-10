namespace FpWorkshop
{
  public class Step01_NamesAndVariables
  {
    public static void Run()
    {
      // Challenge 1 --------------------------------------
      var a = 42;

      Help.Ensure(a == 42);

      // Challenge 2 --------------------------------------
      var b = 75;
      
      // Why can't we say `var b` like `let b` in F#?
      b = 99;

      Help.Ensure(b == 99);

      // Challenge 3 --------------------------------------
      var c = 21;

      c = c + 1;

      Help.Ensure(c == 22);

      // Challenge 4 --------------------------------------
      long d = 42; // For reference, no change needed here

      Help.Ensure(d is long);

      // Challenge 5 --------------------------------------
      string e = "Hello";

      e = e + " FP";

      Help.Ensure(e == "Hello FP");

      // Challenge 6 --------------------------------------
      var f = new Foobar();

      Help.Ensure(f.WhatAmI == 0);
    }

    class Foobar
    {
      public int WhatAmI { get; set; }
    }
  }
}
