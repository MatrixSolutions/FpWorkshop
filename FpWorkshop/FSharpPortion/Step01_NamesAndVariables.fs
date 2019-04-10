namespace FSharpPortion

module Step01_NamesAndVariables =

  type Foobar() =
    // F# Doesn't like to default values for you
    member val WhatAmI = 65 with get, set

  let run () =
    // Challenge 1 --------------------------------------
    let a = 42

    ensure (a = 42)

    // Challenge 2 --------------------------------------
    let b = 75

    // What would happen if we just said `b = 99` like in C#?
    let b = 99

    ensure (b = 99)

    // Challenge 3 --------------------------------------
    let c = 21

    c = c + 1 // What's not quite right here?

    ensure (c = 21)

    // Challenge 4 --------------------------------------
    let d: int64 = 3L // Any example of an `int64` will do

    ensure(d.GetType() = typeof<int64>)

    // Challenge 5 --------------------------------------
    let mutable e = "Hello"

    e <- e + " FP";

    ensure(e = "Hello FP")

    // Challenge 5 (aside) ------------------------------
    let e: string ref = ref "Hello"

    e := !e + " FP";

    ensure(e = ref "Hello FP")

    // Challenge 6 --------------------------------------
    let f = Foobar()

    ensure(f.WhatAmI = 65)
