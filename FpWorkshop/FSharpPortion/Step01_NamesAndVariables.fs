namespace FSharpPortion

  module Step01_NamesAndVariables =
    let run () =
      // Challenge 1 --------------------------------------
      let a = __

      ensure (a = 42)

      // Challenge 2 --------------------------------------
      let b = 75

      // What would happen if we just said `b = 99` like in C#?
      let b = 99

      ensure (b = __)

      // Challenge 3 --------------------------------------
      let c = 21

      c = c + 1 // What's not quite right here?

      ensure (c = __)

      // Challenge 4 --------------------------------------
      let d: int64 = __ // Any example of an `int64` will do

      ensure(d.GetType() = typeof<int64>)

      // Challenge 5 --------------------------------------
      let mutable e = "Hello"

      e <- e + " FP";

      ensure(e = __)

      // Challenge 5 (aside) ------------------------------
      let e: string ref = ref "Hello"

      e := !e + " FP";

      ensure(e = __)
