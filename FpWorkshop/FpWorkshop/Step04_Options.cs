﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FpWorkshop
{
  public class Step04_Options
  {
    public interface IOption<T>
    {
      bool IsSome { get; }
      bool IsNone { get; }
      bool IsSomeOf(T value);
      IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> f);
      IOption<TResult> Map<TResult>(Func<T, TResult> f);
      T DefaultValue(T aDefault);
      IList<T> ToList();
    }

    public class None<T> : IOption<T>
    {
      public bool IsSome => false;
      public bool IsSomeOf(T value) => false;

      public bool IsNone => true;

      public IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> f) => new None<TResult>();

      public IOption<TResult> Map<TResult>(Func<T, TResult> f) => new None<TResult>();

      public T DefaultValue(T aDefault) => aDefault;

      public IList<T> ToList() => new List<T>();

      public override bool Equals(object obj) => obj is None<T>;
    }

    public class Some<T> : IOption<T>
    {
      private readonly T _v;

      public Some(T v)
      {
        _v = v;
      }

      public bool IsSomeOf(T value) => _v.Equals(value);

      public bool IsSome => true;

      public bool IsNone => false;

      public IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> f) =>
        f(_v);

      public IOption<TResult> Map<TResult>(Func<T, TResult> f) =>
        new Some<TResult>(f(_v));

      public T DefaultValue(T aDefault) => _v;

      public IList<T> ToList() => new List<T> {_v};
    }

    public static void Run()
    {
      // Challenge: Make all these tests pass by implementing option
      // (hehe :trollface:)

      // Extra Credit: make IOption implement IEnumerable (it's not too hard)

      // Challenge 1 --------------------------------------
      var present = new Some<int>(42);
      var absent = new None<int>();

      Help.Ensure(present.IsSome);
      Help.Ensure(!absent.IsSome);

      Help.Ensure(!present.IsNone);
      Help.Ensure(absent.IsNone);

      // Challenge 2 --------------------------------------
      // Let's ignore this in our implementation

      // Challenge 3 --------------------------------------
      Help.Ensure(new Some<int>(43).Map(v => v - 1).IsSomeOf(42));

      // Challenge 4 --------------------------------------
      Help.Ensure(new None<string>().Map(v => v + "!").IsNone);

      // Challenge 5 --------------------------------------
      // If bind is correct, squishing works :)

      // Challenge 6 --------------------------------------
      // So with actual `bind`...

      Help.Ensure(new None<int>().Bind(_ => new None<int>()).IsNone);
      Help.Ensure(new Some<int>(42).Bind(_ => new None<int>()).IsNone);
      Help.Ensure(new None<int>().Bind(_ => new Some<int>(42)).IsNone);
      Help.Ensure(new Some<int>(42).Bind(_ => new Some<int>(99)).IsSomeOf(99));

      // Challenge 7 --------------------------------------

      var result =
        new Some<int>(42).Bind(v1 =>
        new None<int>().Bind(v2 =>
        new Some<int>(99).Map(v3 =>
          (v1 + v2) * v3
        )));

      Help.Ensure(result.IsNone);

      var result2 =
        new Some<int>(42).Bind(v1 =>
        new Some<int>(2).Bind(v2 =>
        new Some<int>(99).Map(v3 =>
          (v1 + v2) * v3
        )));

      Help.Ensure(result2.IsSomeOf((42 + 2) * 99));

      // Challenge 8 --------------------------------------

      // Challenge 9 --------------------------------------

      // Challenge 10 --------------------------------------

      Help.Ensure(!new None<int>().ToList().Any());
      Help.Ensure(new Some<int>(42).ToList().SequenceEqual(new List<int>{ 42 }));

      // Challenge 11 --------------------------------------
      // If options are so simlar to lists then why not just use lists everywhere?

      // Challenge 12 --------------------------------------
      // Option has safer ways to get the value, like providing a default for when it's
      // not found

      Help.Ensure(new None<int>().DefaultValue(42) == 42);
      Help.Ensure(new Some<int>(99).DefaultValue(42) == 99);
    }
  }
}