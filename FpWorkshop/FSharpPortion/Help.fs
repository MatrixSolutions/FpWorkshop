[<AutoOpen>]
module Help

let inline __<'T> : 'T = failwith "Seek wisdom by filling in the __"

let inline ensure condition =
  if not condition then
    failwithf "Expected condition to be met!"
