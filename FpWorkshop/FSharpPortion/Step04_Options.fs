namespace FSharpPortion

module Step04_Options =

  let run () =
    // NOTE: Do this entire file before trying the C# one

    // An option is an F# type that represents the absense or presence of a value

    // Many find it useful to think of options as special lists that are only allowed
    // to have one element (e.g. `[42]`) or no elements (e.g. `[]`).

    // ^^ this intuition is useful because it shows that options basically have all the
    // same capabilities as lists!

    // Challenge 1 --------------------------------------
    // We can check if a value is present or absent
    let present = Some 42  // Kinda like [42]
    let absent = None      // Kinda like []

    ensure (Option.isSome present = true)
    ensure (Option.isSome absent = false)

    ensure (Option.isNone present = false)
    ensure (Option.isNone absent = true)

    // Challenge 2 --------------------------------------
    // If options are like lists, `Option.get` is like `List.head`
    // Also similarly, this is unsafe and should be avoided in production
    // (more to say about this later)
    ensure (Option.get (Some 42) = 42)

    // Challenge 3 --------------------------------------
    // We can transform values inside of options using `map` (sound familiar?)

    ensure (Option.map (fun v -> v - 1) (Some 43) = Some 42)

    // Challenge 4 --------------------------------------
    // If we `map` over an empty list we get the empty list. What do you think
    // mapping over `None` yields?

    ensure (Option.map (fun v -> v + "!") None = None)

    // Challenge 5 --------------------------------------
    // Unfortunately (or fortunately, depending on how you look at it) options' version
    // of `List.collect` is called `Option.bind` but it does the same thing! Map then squish.

    // I find it fun to think of how the "squish stage" might work so let's work with that first

    ensure (pretendSquish (Some None) = None)
    ensure (pretendSquish None = None)
    ensure (pretendSquish (Some (Some 99)) = Some 99)

    // Challenge 6 --------------------------------------
    // So with actual `bind`...

    ensure (Option.bind (fun _ -> None)    None      = None)
    ensure (Option.bind (fun _ -> Some 42) None      = None)
    ensure (Option.bind (fun _ -> None)    (Some 42) = None)
    ensure (Option.bind (fun _ -> Some 99) (Some 42) = Some 99)

    // SPOILER: any None makes the whole thing none!

    // Challenge 7 --------------------------------------
    // So what does that mean? Basically it means that we can write code
    // in the context that values might not be there without actually ever
    // talking about their absense!

    let result =
      Some 42 |> Option.bind (fun v1 ->
      None |> Option.bind (fun v2 ->
      Some 99 |> Option.map (fun v3 ->
        (v1 + v2) * v3
      )))

    ensure (result = None)

    // Challenge 8 --------------------------------------
    // Why is there a `map` in the innermost part above?
    // NOTE: this is an extremely common pattern in FP, `bind, bind, bind ... bind, map`

    // Challenge 9 --------------------------------------
    // In lists, remember how `head` is unsafe? Well, option to the rescue!
    // `tryHead` returns an option so it's a safe alternative.

    ensure (List.tryHead [] = None)
    ensure (List.tryHead [42; 3; 9] = Some 42)

    // Challenge 10 --------------------------------------
    // If you've been skeptical about options being similar to lists this whole time
    // Here's a little evidence!

    ensure (Option.toList None = [])
    ensure (Option.toList (Some 42) = [42])

    // How'd you get in here, array!?
    ensure (Option.toArray (Some 3) = [|3|])
    ensure (Option.toArray None = [||])

    // Challenge 11 --------------------------------------
    // If options are so simlar to lists then why not just use lists everywhere?

    // Challenge 12 --------------------------------------
    // Option has safer ways to get the value, like providing a default for when it's
    // not found

    ensure (Option.defaultValue 42 None = 42)
    ensure (Option.defaultValue 42 (Some 99) = 99)
