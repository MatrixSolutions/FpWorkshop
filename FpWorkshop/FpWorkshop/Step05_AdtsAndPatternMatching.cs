using System;
using System.Collections.Generic;
using System.Linq;

namespace FpWorkshop
{
  public class Step05_AdtsAndPatternMatching
  {
    public interface ILunchOption
    {
      bool SellsSandwiches { get; }
    }

    public class ElBurrito : ILunchOption
    {
      public bool SellsSandwiches
      {
        get
        {
          throw new NotImplementedException();
        }
      }
    }

    public class GoodCatchFishAndTurf : ILunchOption
    {
      public bool SellsSandwiches 
      {
        get
        {
          throw new NotImplementedException();
        }
      }
    }

    public class CornerDeli : ILunchOption
    {
      public bool SellsSandwiches 
      {
        get
        {
          throw new NotImplementedException();
        }
      }
    }

    public interface IHungryFor
    {
      IEnumerable<ILunchOption> GoodLunchOptions();
    }

    public class FishSandwiches : IHungryFor
    {
      public override bool Equals(object obj)
      {
        throw new NotImplementedException();
      }

      public override int GetHashCode()
      {
        throw new NotImplementedException();
      }

      public IEnumerable<ILunchOption> GoodLunchOptions()
      {
        throw new NotImplementedException();
      }
    }

    public class Burritos : IHungryFor
    {
      public override bool Equals(object obj)
      {
        throw new NotImplementedException();
      }

      public override int GetHashCode()
      {
        throw new NotImplementedException();
      }

      public IEnumerable<ILunchOption> GoodLunchOptions()
      {
        throw new NotImplementedException();
      }
    }

    public class DeepFriedGoodness : IHungryFor
    {
      public override bool Equals(object obj)
      {
        throw new NotImplementedException();
      }

      public override int GetHashCode()
      {
        throw new NotImplementedException();
      }

      public IEnumerable<ILunchOption> GoodLunchOptions()
      {
        throw new NotImplementedException();
      }
    }

    public static void Challege1()
    {
      // C# doesn't have ADTs or pattern matching.

      // To get the same effect we have to use interfaces for the type and
      // derived classes for the members

      // Implement the above classes to make the types pass
      // Observe the similarities with the F# code

      Help.Ensure(new GoodCatchFishAndTurf().SellsSandwiches);
      Help.Ensure(new CornerDeli().SellsSandwiches);
      Help.Ensure(!new ElBurrito().SellsSandwiches);

      Help.Ensure(new FishSandwiches().GoodLunchOptions().SequenceEqual(new [] { new GoodCatchFishAndTurf() as ILunchOption, new CornerDeli() }));
      Help.Ensure(new Burritos().GoodLunchOptions().SequenceEqual(new [] { new ElBurrito(), }));
      Help.Ensure(new DeepFriedGoodness().GoodLunchOptions().SequenceEqual(new [] { new ElBurrito() as ILunchOption, new GoodCatchFishAndTurf() }));
    }

    public interface ILocation
    {
      T Match<T>(
        Func<string, int, T> whenCity,
        Func<string, int, T> whenSmallCountryTown,
        Func<T> whenWilderness
      );
    }

    public class City : ILocation
    {
      public City(string name, int population)
      {
      }

      public override bool Equals(object obj)
      {
        throw new NotImplementedException();
      }

      public override int GetHashCode()
      {
        throw new NotImplementedException();
      }

      public T Match<T>(Func<string, int, T> whenCity, Func<string, int, T> whenSmallCountryTown, Func<T> whenWilderness)
      {
        throw new NotImplementedException();
      }
    }

    public class SmallCountryTown : ILocation
    {
      public SmallCountryTown(string name, int population)
      {
      }

      public override bool Equals(object obj)
      {
        throw new NotImplementedException();
      }

      public override int GetHashCode()
      {
        throw new NotImplementedException();
      }

      public T Match<T>(Func<string, int, T> whenCity, Func<string, int, T> whenSmallCountryTown, Func<T> whenWilderness)
      {
        throw new NotImplementedException();
      }
    }

    public class Wilderness : ILocation
    {
      public override bool Equals(object obj)
      {
        throw new NotImplementedException();
      }

      public override int GetHashCode()
      {
        throw new NotImplementedException();
      }

      public T Match<T>(Func<string, int, T> whenCity, Func<string, int, T> whenSmallCountryTown, Func<T> whenWilderness)
      {
        throw new NotImplementedException();
      }
    }

    private static bool HasKnownPopulation(ILocation location) =>
      ReplaceMe.__<bool>();

    private static ILocation UpdateName(string newName, ILocation location) =>
      ReplaceMe.__<ILocation>();

    private static ILocation Subsume(ILocation locA, ILocation locB) =>
      ReplaceMe.__<ILocation>();

    private static bool IsPittsburgh(ILocation location) =>
      ReplaceMe.__<bool>();

    public static void Challege2()
    {
      // Notice F#'s pattern matching gives us the ability to create new behaviors ad hoc
      // without needing to add them to the interface. We tend to try to get around this
      // by writing our own version of `Match` but this construct proves very weak when
      // compared with pattern matching because (1) pattern can be re-ordered, (2) they
      // allow nesting other patterns and (3) they can include wildcards/destructure data.

      // I don't mean to belabor the point but also notice that F# gives us a lot of
      // things for free when we use ADTs:
      //  - Equality checks with `=` (under-the-covers this includes `.Equals` and `.HashCode`)
      //  - `ToString` with `string`
      //  - constructors
      //  - immutability

      // Let's implement that location code using a custom Match and see how it works out

      var pittsburgh = new City("Pittsburgh", 308144);
      var whiteHaven = new SmallCountryTown("White_Haven", 1097);

      Help.Ensure(HasKnownPopulation(pittsburgh));
      Help.Ensure(HasKnownPopulation(whiteHaven));
      Help.Ensure(!HasKnownPopulation(new Wilderness()));

      Help.Ensure(UpdateName("White Haven", whiteHaven).Equals(new SmallCountryTown("White Haven", 1097)));
      Help.Ensure(
        whiteHaven
          .Match(
            (_, __) => false,
            (name, pop) => name == "White_Haven" && pop == 1097,
            () => false
          )
      );
      Help.Ensure(UpdateName("Desert", new Wilderness()).Equals(new Wilderness()));

      // We can't really do this because what do we do for Wilderness' name?

//      let getName location =
//        __
//
//      ensure (getName whiteHaven = Step04_Options.Some<> "White_Haven")
//      ensure (getName pittsburgh = Step04_Options.Some<> "Pittsburgh")
//      ensure (getName Wilderness = Step04_Options.None<>)

      Help.Ensure(Subsume(pittsburgh, whiteHaven).Equals(new City("Pittsburgh", 308144 + 1097)));
      Help.Ensure(Subsume(whiteHaven, pittsburgh).Equals(new City("White_Haven", 308144 + 1097)));
      Help.Ensure(Subsume(new Wilderness(), whiteHaven).Equals(new Wilderness()));
      Help.Ensure(Subsume(new Wilderness(), pittsburgh).Equals(new Wilderness())));
      Help.Ensure(Subsume(pittsburgh, new Wilderness()).Equals(pittsburgh));
      Help.Ensure(Subsume(whiteHaven, new Wilderness()).Equals(whiteHaven));

      // Think about how odd it would feel to need to put this on the interface
      Help.Ensure(IsPittsburgh(pittsburgh));
      Help.Ensure(!IsPittsburgh(new City("New York City", 8622698)));
      Help.Ensure(!IsPittsburgh(whiteHaven));
      Help.Ensure(!IsPittsburgh(new Wilderness()));
    }
  }
}
