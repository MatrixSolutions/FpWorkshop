namespace FSharpPortion

module Step06_Records =

  type Person = { Name: string; Age: int; SkillLevel: int }

  let chuckNorris = { Name="Chuck Norris"; Age=79; SkillLevel=9001 }

  let challenge1 () =
    // Records (like ADTs) give you value-level equality for free!

    ensure (chuckNorris <> { Name="Chuck Norris"; Age=1000000; SkillLevel=9001 })

    ensure (chuckNorris = { Name="Chuck Norris"; Age=79; SkillLevel=9001 })

  let challenge2 () =
    // Records are immutable and have a convenient update and get (.) syntax

    let duckTorris = { chuckNorris with Name="Duck Torris"; SkillLevel=2 }

    ensure (chuckNorris.Name = "Chuck Norris")
    ensure (chuckNorris.Age = 79)
    ensure (chuckNorris.SkillLevel = 9001)
    ensure (duckTorris.Name = "Duck Torris")
    ensure (duckTorris.Age = 79)
    ensure (duckTorris.SkillLevel = 2)

  let challenge3 () =
    // Records are nice with pattern matching

    let hasSkillOf9000 person =
      match person with
        | { SkillLevel=9000 } -> true
        | _ -> false

    // Actually, they can even be de-structured as arguments

    let isNotChuckNorris { Name=name } = name <> chuckNorris.Name

    // Give it a try using match or destructing, whichever you prefer
    let skillLevelsAreWithin10OfEachOther { SkillLevel=skill1 } { SkillLevel=skill2 } =
      abs (skill1 - skill2) < 10

    // OR

    let skillLevelsAreWithin10OfEachOther person1 person2 =
      match person1, person2 with
        | { SkillLevel=skill1 }, { SkillLevel=skill2 } -> abs (skill1 - skill2) < 10

    // OR

    let skillLevelsAreWithin10OfEachOther person1 person2 =
      abs (person1.SkillLevel - person2.SkillLevel) < 10

    let donaldDuck = { Name="Donald"; Age=85; SkillLevel=6 }
    let tomCruise = { Name="Tom Cruise"; Age=56; SkillLevel=15 }
    let oprah = { Name="Oprah"; Age=65; SkillLevel=16 }

    ensure (skillLevelsAreWithin10OfEachOther chuckNorris chuckNorris)
    ensure (not (skillLevelsAreWithin10OfEachOther chuckNorris donaldDuck))
    ensure (not (skillLevelsAreWithin10OfEachOther chuckNorris oprah))
    ensure (skillLevelsAreWithin10OfEachOther tomCruise oprah)
    ensure (skillLevelsAreWithin10OfEachOther tomCruise donaldDuck)
    ensure (not (skillLevelsAreWithin10OfEachOther oprah donaldDuck))
