namespace FSharpPortion

module Step03_Sequences =

  let run () =
    // Challenge 1 --------------------------------------
    let anArray = [|1; 3; __|]

    ensure (anArray = [|1; 3; 5|])

    // Challenge 2 --------------------------------------
    ensure (anArray.[1] = __)

    // Challenge 3 --------------------------------------
    let aList = [7; 11; __; 17]

    ensure (aList = [7; 11; 13; 17])

    // Challenge 4 --------------------------------------
    let aSet = Set.ofList [1; 2; 3; __]

    ensure (aSet = Set.ofList [1; 2; 3; 7])

    // Challenge 5 --------------------------------------
    let aSeq = Seq.ofList [__; 100; 103]

    ensure (aSeq = Seq.ofList [99; 100; 103])

    // NOTE: From now on we'll use lists and the `List` module but most of
    // the following exists for the other containers we've mentioned also.
    // Seq is the most general (e.g. can be use on arrays, lists, etc) but
    // it will convert the containers to sequences.

    // Challenge 6 --------------------------------------
    // `head` gets the first element but it's unsafe because it can throw exceptions!
    ensure (List.head [] = 42)

    // Challenge 7 --------------------------------------
    // Similar story with `tail`
    ensure (List.tail [] = [2; 3; 4])

    // NOTE: because `head` and `tail` are partial function (i.e. they don't handle
    // all possible inputs) they are considered unsafe and should be avoided in
    // production code. We'll discover safer ways of dealing with lists later...

    // Challenge 8 --------------------------------------
    // `filter` picks elements that match a "check function" (aka predicate)

    let startsWithH (x: string) = x.StartsWith("h")

    let r1 = List.filter startsWithH ["hi"; "howdy"; "yo"; "sup"; "hello"]

    ensure (r1 = __)

    // Challenge 9 --------------------------------------
    // Try it with an unnamed function (hint "not equals" is `<>` in F#)
    let noYo = List.filter (fun x -> __) ["hi"; "howdy"; "yo"; "sup"; "hello"]

    let noYoExpected = ["hi"; "howdy"; "sup"; "hello"]

    ensure (noYo = noYoExpected)

    // Challenge 10 --------------------------------------
    // Try it with a partially applied function
    let noYo = List.filter (__ "yo") ["hi"; "howdy"; "yo"; "sup"; "hello"]

    ensure (noYo = noYoExpected)

    // Challenge 11 --------------------------------------
    // `map` transforms all values in a container making a new container
    let allIncremented = List.map (fun x -> __) [0; 1; 2; 3]

    ensure (allIncremented = [1; 2; 3; 4])

    // It's kinda like `map` does this
    (*
      List.map myFunction [1; 2; 3; 4; 5]
      -> [myFunction 1; myFunction 2; myFunction 3; myFunction 4; myFunction 5]
      -> results after applying :)
    *)

    // Challenge 12 --------------------------------------
    // `collect` transforms values into containers and merges them all together
    // It's a little odd at first, but you can think of it as being like "map then squish"
    // or "map then concat"
    let double x = [x; x]
    let doubled = List.collect double [1; 2; 3]

    ensure (doubled = __)

    // (SPOILER) In this case, `collect` does 
    (*
      [double 1; double 2; double 3] -> apply each ->
      [[1; 1]; [2; 2]; [3; 3]] -> squish! ->
      [1; 1; 2; 2; 3; 3]
    *)

    // Challenge 13 --------------------------------------
    // `collect` is super powerful. It can even be used to do a sort of
    // `map` and `filter` in one step
    let exclaimOnlyStartsWithH =
      ["hi"; "howdy"; "yo"; "sup"; "hello"]
        |> List.collect (fun v -> if startsWithH v then [v + "!"] else [])

    ensure (exclaimOnlyStartsWithH  = __)

    // Challenge 14 --------------------------------------
    // `fold` rolls-up the values in a collection to form a result
    let sum = List.fold (+) 0 [1; 2; 3; 4]

    ensure (sum = __)

    // You can think of this as building up an operation that looks like
    (*
      ((((0 + 1) + 2) + 3) + 4)
    *)

    // Challenge 15 --------------------------------------
    // the `0` was the initial value, or the value used if given an empty list
    let a1 = List.fold (+) 42 []
    ensure (a1 = __)

    let a2 = List.fold (+) __ [1; 2; 3]
    ensure (a2 = 106)

    // Challenge 16 --------------------------------------
    // the result type can be different from the elements' type!
    let stringLen (x: string) = x.Length

    let totalStringLen = List.fold (fun result aStr -> __) 0 ["good"; "day"; "mate"]
    ensure (totalStringLen = 11)
