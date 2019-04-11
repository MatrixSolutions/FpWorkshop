[<AutoOpen>]
module Help

let inline __<'T> : 'T = failwith "Seek wisdom by filling in the __"

let stewgle x = x + " stewgled"
let drewgle x = x + " drewgled"
let refloogle x = x + " refloogled"

let inline ensure condition =
  if not condition then
    failwithf "Expected condition to be met!"
