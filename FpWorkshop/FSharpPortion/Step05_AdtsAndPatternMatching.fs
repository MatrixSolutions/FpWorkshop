namespace FSharpPortion

module Step05_AdtsAndPatternMatching =

  // Work through all the F# first, here as well

  type LunchOption =
    | ElBurrito
    | GoodCatchFishAndTurf
    | CornerDeli

  type HungryFor =
    | FishSandwiches
    | Burritos
    | DeepFriedGoodness

  let challenge1 () =
    // Algebraic data types (ADTs) are excellent at modeling alternatives (see above)
    
    // Pattern matching is the primary way of working with ADTs. Matches "de-structure" values
    // and are tried from the top to the bottom until a hit is made. `_` is a special value
    // to the F# compiler that roughly means "I don't care what goes here"

    let sellsSandwiches lunchOption =
      match lunchOption with
        | ElBurrito -> false
        | _ -> true

    ensure (sellsSandwiches GoodCatchFishAndTurf)
    ensure (sellsSandwiches CornerDeli)
    ensure (not (sellsSandwiches ElBurrito))

    // Fill in the following cases to find the best lunch options

    let goodLunchOptions hungryFor =
      match hungryFor with
        | _ -> []

    ensure (goodLunchOptions FishSandwiches = [GoodCatchFishAndTurf; CornerDeli])
    ensure (goodLunchOptions Burritos = [ElBurrito])
    ensure (goodLunchOptions DeepFriedGoodness = [ElBurrito; GoodCatchFishAndTurf])

  let challenge2 () =
    // Just about any F# value can be matched, not just ADTs!

    let nonZero n =
      match n with
        | 0 -> false
        | _ -> true

    let startsWithH (text: string) =
      match text with
        | "" -> false
        | _ ->
          match text.[0] with
            | 'h' -> true
            | 'H' -> true
            | _ -> false

    let pickIf condition consequent alternative =
      // Extra credit if you can say why this is not a good
      // implementation of `if`
      match condition with
        | true -> consequent
        | false -> alternative

    // Why don't you try one!
    let greetBigAndLittleBobOnly x =
      __

    ensure(greetBigAndLittleBobOnly "bob" = "Hello!")
    ensure(greetBigAndLittleBobOnly "BOB" = "Hello!")
    ensure(greetBigAndLittleBobOnly "Bob" = "(Silence)")
    ensure(greetBigAndLittleBobOnly "Justice Beaver" = "(Silence)")

  let challenge3 () =
    // Lists are pattern matched using what are called "cons cells" which basically means
    // that a list is either empty or a "head" value "consed" with another list.

    // Cons is the special operator `::`

    // Here's our pal, `tryHead`
    let tryHead list =
      match list with
        | (v::_) -> Some v // `v` is the head and `_` is the ignored tail (i.e. rest, remainder).
        | [] -> None // If we couldn't match the head, it means we have an empty list!

    // Give `tryTail` a go! Extra credit if you can use `_` in two patterns (i.e. part before `->`)
    let tryTail list =
      __

    ensure (tryTail [] = None)
    ensure (tryTail [1; 2; 3; 4] = Some [2; 3; 4])

  let challenge4 () =
    // Our pal option can also be matched

    let isSomeOf42 v =
      match v with
        | Some 42 -> true // Notice we can put `42` in the pattern to make sure it's matched
        | _ -> false

    ensure (isSomeOf42 (Some 42))
    ensure (not (isSomeOf42 (Some 55)))
    ensure (not (isSomeOf42 None))

    // Your turn!

    let squashOptionList ol =
      __

    ensure(squashOptionList None = [])
    ensure(squashOptionList (Some []) = [])
    ensure(squashOptionList (Some [1; 2; 3]) = [1; 2; 3])

  type MyOption<'a> =
    | MySome of 'a // ADTs can hang onto data!
    | MyNone

  let challenge5 () =
    // The above ADT is the definition of our pal option! Minus the `My`s of course...
    // That's all it takes to make a structure representing the absence of data -- wow.

    // For good practice, give `map` a try

    let map f myOpt =
      __

    ensure(map ((*) 2) MyNone = MyNone)
    ensure(map ((*) 2) (MySome 21) = (MySome 42))
    ensure(map ((*) 2) (MySome 1) = (MySome 2))

  type Number =
    | Zero
    | Successor of Number

  let challenge6 () =
    // The above ADT is a definition for natural numbers! Notice that it's recursive
    // (`Number` is referenced in the definition).

    // If we wanted to represent three it's a little cumbersome but we can do it!

    let three = Successor (Successor (Successor Zero))

    // Converting back to ints could look like this (notice we need recursion, have no fear!)

    let rec toInt num =
      match num with
        | Zero -> 0
        | Successor prev -> 1 + toInt prev

    ensure(toInt Zero = 0)
    ensure(toInt three = 3)

    // Here's a classic, give `isEven` a try

    let rec isEven num =
      __

    ensure(isEven Zero)
    ensure(not (isEven three))
    ensure(isEven (Successor three))
    ensure(not (isEven (Successor Zero)))

  type MyList<'a> =
    | Cons of 'a * MyList<'a>
    | EmptyList

  let challenge7 () =
    // The above ADT is the definition of a linked list! Notice that it's also recursive
    // (`MyList` is referenced in the definition).

    // The `*` is type-level language meaning "AND". So a cons cell is a value AND another list
    // just like we said before.

    // It's a little cumbersome to write lists this way, that's why F# defines `::` as sugar
    // for `Cons`

    // Here's what it looks like to make our list :(

    let list = Cons (1, (Cons (2, (Cons (3, EmptyList)))))
    // Observe the simliar structure to 1::2::3::[]
    // `::` is just an infix (in the middle) operator

    // For good practice, give `map` a try

    // hint, you'll need recursion! Ask for help if you need it.
    let map f myOpt =
      __

    ensure(map ((*) 2) EmptyList = EmptyList)
    ensure(map ((*) 2) list = Cons (2, (Cons (4, (Cons (6, EmptyList))))))
    ensure(map ((*) 2) (Cons (5, EmptyList)) = Cons (10, EmptyList))

  let challenge8 () =
    // It'd be a shame to not mention tuples at this point

    // Tuples are a special type in F# that almost make the `,` behave like a magical operator!
    // If you've been wondering why lists are delimited with `;` then here's your answer:
    // The F# designers thought tuples were important enough to get `,` (so they must be pretty
    // important, eh?)

    // When we made list Cons cells above I mentioned `*` means "AND." Well, it's really just
    // the type-level way to say TUPLE.
    // Repeat after me:
    // `*` in the type, `,` in the value
    // `*` in the type, `,` in the value
    // `*` in the type, `,` in the value
    // ...

    // Here's a tuple with two values
    let aTuple = ("Jack-O-Lantern", 27)

    // Here's one with 5
    let tuple5 = (1, 9, "hi", Some 1, [":)"])

    // Hover over these and notice the types use `*` where the values use `,`

    // Note that parens are optional and typically left out 
    let tuple3 = 1, 2, ""

    // Tuples work really well with pattern matching on multiple values

    // For example, here's a classic
    let fizzbuzz n =
      match n % 3 = 0, n % 5 = 0 with
        | true, true -> "FizzBuzz"
        | true, false -> "Fizz"
        | false, true -> "Buzz"
        | _ -> string n

    // Tuples can be passed to functions (though they can't be partially applied
    // so they're generally not preferred) 

    let flipTuple tuple = (snd tuple, fst tuple)

    ensure (flipTuple (42, "hi") = ("hi", 42))

    // Note that, when a type only has one case (for example tuples) they can
    // be matched IN THE FUNCTION SIGNATURE!

    let nicerFlipTuple (a, b) = (b, a)

    // Try out a function that takes a tuple and returns one!
    // You don't see `bimap` too much in F# but it's mighty useful

    let bimap f g (x, y) =
      __

    let add1 = (+) 1
    let greet name = "Hi " + name

    ensure (bimap add1 greet (41, "John") = (42, "Hi John"))
    ensure (bimap greet add1 ("Jacob", 9) = ("Hi Jacob", 10))

  type Location =
    | City of string*int
    | SmallCountryTown of string*int
    | Wilderness

  let challenge9 () =
    // Let's practice pattern matching with the locations above. We'll use options
    // wherever things may be arbitrary

    let pittsburgh = City ("Pittsburgh", 308144)
    let whiteHaven = SmallCountryTown ("White_Haven", 1097)

    let hasKnownPopulation location =
      __

    ensure (hasKnownPopulation pittsburgh)
    ensure (hasKnownPopulation whiteHaven)
    ensure (not (hasKnownPopulation Wilderness))

    let updateName newName location =
      __

    ensure (updateName "White Haven" whiteHaven = (SmallCountryTown ("White Haven", 1097)))
    ensure (updateName "Desert" Wilderness = Wilderness)

    let getName location =
      __

    ensure (getName whiteHaven = Some "White_Haven")
    ensure (getName pittsburgh = Some "Pittsburgh")
    ensure (getName Wilderness = None)

    let subsume locA locB =
      __

    ensure (subsume pittsburgh whiteHaven = City ("Pittsburgh", 308144 + 1097))
    ensure (subsume whiteHaven pittsburgh = City ("White_Haven", 308144 + 1097))
    ensure (subsume Wilderness whiteHaven = Wilderness)
    ensure (subsume Wilderness pittsburgh = Wilderness)
    ensure (subsume pittsburgh Wilderness = pittsburgh)
    ensure (subsume whiteHaven Wilderness = whiteHaven)

    let isPittsburgh location =
      __

    ensure (isPittsburgh pittsburgh)
    ensure (not <| isPittsburgh (City ("New York City", 8622698)))
    ensure (not <| isPittsburgh whiteHaven)
    ensure (not <| isPittsburgh Wilderness)
