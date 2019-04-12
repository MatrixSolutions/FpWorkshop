namespace FSharpPortion

module Step07_Oddities =

  type AgeRange =
    | Infant | Child | TeenMinor | CigarsOnlyAdult | BeerableAdult

  let challenge1 () =
    // Redundant pattern match cases can be merged!

    let getRange age =
      match age with
        | 0
        | 1
        | 2 -> Infant
        | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 -> Child 
        | 13 | 14 | 15 | 16 | 17 -> TeenMinor 
        | 18 | 19 | 20 -> CigarsOnlyAdult 
        | _ -> BeerableAdult 
     
    // Give it a try!

    let isOver12 range =
      __

    ensure (isOver12 TeenMinor)
    ensure (isOver12 CigarsOnlyAdult)
    ensure (isOver12 BeerableAdult)
    ensure (not (isOver12 Child))
    ensure (not (isOver12 Infant))

  let challenge2 () =
    // Creating functions with one argument that immediately gets
    // matched is SO common in F# that the creators introduced the `function`
    // keyword to do the same thing

    // Here's the same example from challenge 1

    let getRange = function
      | 0
      | 1
      | 2 -> Infant
      | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 -> Child 
      | 13 | 14 | 15 | 16 | 17 -> TeenMinor 
      | 18 | 19 | 20 -> CigarsOnlyAdult 
      | _ -> BeerableAdult 
     
    // Give it a try (feel free to copy your answer from 1 and use `function` instead)!

    let isOver12 range =
      __

    ensure (isOver12 TeenMinor)
    ensure (isOver12 CigarsOnlyAdult)
    ensure (isOver12 BeerableAdult)
    ensure (not (isOver12 Child))
    ensure (not (isOver12 Infant))

  let (|EmptyOrWhitespace|HasContent|) input =
    if System.String.IsNullOrWhiteSpace input
    then EmptyOrWhitespace
    else HasContent input

  let (|OldEnoughToBuyCigars|TooYoungToBuyCigars|) range =
    match range with
      | CigarsOnlyAdult
      | BeerableAdult -> OldEnoughToBuyCigars
      | _ -> TooYoungToBuyCigars

  let challenge3 () =
    // Active patterns are like ADTs that only exist in the pattern portion of
    // a match (e.g. left of `->`)

    // They're useful for summarizing data
    let getName someString =
      match someString with
        | EmptyOrWhitespace -> None
        | HasContent name -> Some name

    ensure (getName "" = None)
    ensure (getName "   " = None)
    ensure (getName "Syme" = Some "Syme")

    // Try writing `canBuyCigars` with the active pattern defined above.

    let canBuyCigars range =
      __

    ensure (not (canBuyCigars TeenMinor))
    ensure (canBuyCigars CigarsOnlyAdult)
    ensure (canBuyCigars BeerableAdult)
    ensure (not (canBuyCigars Child))
    ensure (not (canBuyCigars Infant))

  let challenge4 () =
    // In F# you can define your own symbolic operators!
    // So, if you wanted to redefine list append (normally `@`) as `<!>` that would look like
    // this

    let (<!>) a b = a @ b

    ensure ([1; 2] <!> [3; 4; 5] = [1; 2; 3; 4; 5])
    ensure ([] <!> [1] = [1])

    // Give `Option.bind` a shot (`>>=` is a pretty typical symbol for it in FP languages)

    let (>>=) opt f =
      __

    ensure (None >>= (fun _ -> None)       = None)
    ensure (None >>= (fun _ -> Some 42)    = None)
    ensure (Some 42 >>= (fun _ -> None)    = None)
    ensure (Some 42 >>= (fun _ -> Some 99) = Some 99)

  let noteOnFunctionNames () =
    // F# values can have crazy names when using back-ticks

    let ``my crazy name for 1234`` = 1234

    let ``:)`` (word: string) = word + " :)"

    let ``let`` = "uh, maybe don't do this"

    () // This is really just more of an FYI than a challenge :)

  let challenge5 () =
    // If you think about how `bool` could be defined, it could look something like this
    // in F#

    (*
      type bool = | true | false
    *)

    // How many possible values are there in the type bool?

    ensure (possibleValuesInTypeBool = __)

    // If you remove one of those values you're left with an interesting data type

    (*
      type Thing = AThing
    *)

    // This is basically the definition of unit in F#
    // (parens are magic sugar like `::` which we saw before)

    (*
      type unit = ()
    *)

    // It's impossible to derive meaning from unit. With bool we could, ya know,
    // make a decision but unit's always unit!

    // In F# all functions must take arguments and return values. Unit is the way
    // for the type system to reconcile this fact with the fact that some functions
    // may not actually have a meaningful return value.

    let printHowAreYouToday () =
      printfn "How are you today?"

    // This function takes unit (no meaningful input) and returns unit (no meaningful output)

    // So this means that `printHowAreYouToday` is actually a SINGLE-ARGUMENT function! There's
    // no such thing as a zero-argument function in F#, like there is in C#.

    // So

    let printIAmWellHowAreYou =
      printfn "I am well, how are you?"

    // Actualy doesn't create a function, it immediately prints its message and binds
    // the name `printIAmWellHowAreYou` with the value of unit!

    // Hover over `printIAmWellHowAreYou` and `printHowAreYouToday` to see the difference.

    // Now I've got to return unit because we need a return value and having a `let` at
    // the end is like having `fun printIAmWellHowAreYou -> ` without a body, as we saw
    // earlier

    ()

