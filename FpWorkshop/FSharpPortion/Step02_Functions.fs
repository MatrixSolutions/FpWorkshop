namespace FSharpPortion

module Step02_Functions =

  let run () =
    // Challenge 1 --------------------------------------
    let iTellYouWhatYouToldMe x = x

    ensure(iTellYouWhatYouToldMe 42 = 42)

    // Challenge 1 (aside) ------------------------------
    /// The above function definition syntax is actually just syntactic sugar for this
    let iTellYouWhatYouToldMeLowCarb = fun x -> x

    ensure(iTellYouWhatYouToldMeLowCarb 42 = 42)

    // Challenge 2 --------------------------------------

    ensure((fun x -> x) "Wait! You lost your name" = "Wait! You lost your name")

    // Challenge 3 --------------------------------------
    let myAdd a b = a + b

    // Application is just whitespace in F#, no parens necessary unless expressing order of op!
    ensure(myAdd 2 3 = 5)

    // Challenge 4 --------------------------------------
    let specialAdd = myAdd 4 // Arguments can be applied later, no problem!

    ensure(specialAdd 2 = 6)

    // Challenge 5 --------------------------------------
    let alwaysReturnTheFirst a b = a

    // Given this test compiles, how many possible implementations does `alwaysReturnTheFirst` have?
    ensure(alwaysReturnTheFirst "foo" 42 = "foo")

    // Challenge 6 --------------------------------------
    // All that functions really do is bind names to values in a given scope... Sound familiar?
    (
      fun a b c ->
        ensure(b = "blue")
        ensure(a = "red")
        ensure(c = "green")

    ) "red" "blue" "green" 

    ensure(alwaysReturnTheFirst "foo" 42 = "foo")

    // Challenge 6 (aside) ------------------------------
    // It turns out that `let` can be thought of as just syntactic sugar for function application.
    // Can you think of a case where the following 2 forms behave differently?

//    let a = value
//    do some stuff

//    (fun a -> do some stuff) value


    // Challenge 7 --------------------------------------
    // Let's make let, shall we? Hehe

    let sillyLet value scope = scope value

    sillyLet 5 (fun a ->
    sillyLet 6 (fun b ->
      ensure(a + b = 11)
    ))

    // Challenge 8 --------------------------------------
    // Functions can accept functions as arguments
    let applyThenMultiply f a b = f a * f b

    let addOne = myAdd 1

    ensure (applyThenMultiply addOne 4 5 = 30)

    // Challenge 9 --------------------------------------
    // Which function that we've already seen acts like "choose value"?
    ensure (applyThenMultiply iTellYouWhatYouToldMe 7 3 = (7*3))

    // Challenge 9 (spoiler/note) -----------------------
    // This function exists in F#'s global namespace as `id`
    ensure (applyThenMultiply id 7 3 = 21)

    // Challenge 10 --------------------------------------
    // Which function that we've already seen acts like "ignore value, use this instead"?
    ensure (applyThenMultiply (alwaysReturnTheFirst 5) 7 3 = (5*5))

    // Challenge 11 --------------------------------------
    // In F# even symbolic operators are functions!
    // They can be moved to infix notation (apply in the front) by wrapping in parens

    ensure ((*) 3 4 = 3 * 4)

    // Challenge 12 --------------------------------------
    // This is pretty powerful when combined with partial application
    let alwaysAdd21 = (+) 21

    ensure (alwaysAdd21 3 = 24)

    // Challenge 13 --------------------------------------
    // Since functional languages are all about function application
    // sometimes things get a little, well, nested
    let myMult = (*)
    let yuckNesting a = myAdd 1 (myMult 21 (myAdd 4 (myMult 2 a)))

    // So functional languages typically introduce a "pipe" operator so that
    // computation can be thought of as a pipeline

    // In F# this is the `|>` operator. It's defined like so (look familiar?)

    (*
    let (|>) someValue someFunction = someFunction someValue
    *)

    // You can think of this operator as
    // "flowing data through a pipe, left-to-right"

    let pipedResult = 21 |> myAdd 1 |> myMult 2

    ensure (pipedResult = 44)

    // Challenge 14 --------------------------------------
    // F# also has a "backwards pipe operator" but it's only recommended for
    // "undoing" one set of parens. If you guessed its symobol was `<|` you get
    // a golden star! If not, just think about the `<` and `>` is indicating the
    // direction that data flows

    let ``rewrite me using one back pipe`` =
      myAdd 1 <| myMult 2 6

    ensure (``rewrite me using one back pipe`` = 13)

    // Challenge 15-----------------------------------
    // Piping is pretty slick! Many functions in F# end up looking like
    let add1ThenMult5ThenAdd2ThenMult3 x =
      x
        |> myAdd 1
        |> myMult 5
        |> myAdd 2
        |> myMult 3

    // It reads pretty well, but we can take it a step further...
    // F# introduces a compose operator which uses the symbol `>>`

    // Compose says give me two functions, and, if one returns the input type
    // of the other, I'll glue them together and give you a new function!

    // So `add1ThenMult5ThenAdd2ThenMult3` can be rewritten without even talking about
    // the input value! Just by gluing functions together

    let doMathyStuffUsingCompose =
      myAdd 1
        >> myMult 5
        >> myAdd 2
        >> myMult 3

    // Notice it's basically the same thing except the `x` goes away and we replace
    // the `|` characters with `>`

    let refloogleThePreStewgledDrewgle x =
      x
        |> stewgle
        |> drewgle
        |> refloogle

    let refloogleUsingCompose =
      stewgle
        >> drewgle
        >> refloogle

    ensure (refloogleThePreStewgledDrewgle "space" = refloogleUsingCompose "space")

    // Challenge 16 -----------------------------------
    // "Backwards compose" also exists. Can you guess it's symbol?
    // (don't forget to wrap it in parens since it's a symbolic operator)

    let backComposeSymbol = (<<)

    ensure ((backComposeSymbol (myAdd 1) (myMult 4)) 2 = (2 * 4) + 1)
