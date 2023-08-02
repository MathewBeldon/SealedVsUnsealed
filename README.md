# Sealed Vs Unsealed

The choice between sealed and unsealed classes is not merely a syntactic one; it can have profound implications on the design, performance, and maintainability of a codebase. Most programming languages, such as C#/Java, provide explicit keywords to define classes as sealed, while in others, such as Swift, the concept is implicit.

### What Is Sealed

A sealed class is a class that cannot be inherited. It's a final declaration of a class, ensuring that no other class can extend it. Sealed classes provide a level of security and predictability in the code, as they prevent further modifications to the class hierarchy. They can be particularly useful when you want to encapsulate specific behavior without the risk of unintended alterations.

### What Is Unsealed

An unsealed class is open to inheritance, allowing other classes to extend it. This flexibility can lead to more dynamic and extensible code structures, enabling developers to build upon existing functionality.

## Benchmarks

These benchmarks attempt to reproduce the results from the dotnet 6 performance improvements [blog post](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#peanut-butter)

|                              Method |      Mean |     Error |    StdDev |    Median |
|------------------------------------ |----------:|----------:|----------:|----------:|
|                    'Base Benchmark' | 1.2395 ns | 0.0474 ns | 0.0466 ns | 1.2088 ns |
|   'Sealed Benchmark No Inheritance' | 0.0019 ns | 0.0048 ns | 0.0042 ns | 0.0000 ns |
| 'Unsealed Benchmark No Inheritance' | 0.0043 ns | 0.0065 ns | 0.0051 ns | 0.0030 ns |
|                  'Sealed Benchmark' | 0.0079 ns | 0.0124 ns | 0.0116 ns | 0.0000 ns |
|                'Unsealed Benchmark' | 0.0188 ns | 0.0198 ns | 0.0212 ns | 0.0132 ns |
|          'Sealed Virtual Benchmark' | 0.0143 ns | 0.0185 ns | 0.0173 ns | 0.0076 ns |
|        'Unsealed Virtual Benchmark' | 1.0502 ns | 0.0066 ns | 0.0055 ns | 1.0511 ns |
|          'Sealed Is Type Benchmark' | 0.2032 ns | 0.0043 ns | 0.0034 ns | 0.2022 ns |
|        'Unsealed Is Type Benchmark' | 1.7030 ns | 0.0316 ns | 0.0295 ns | 1.6929 ns |

The results for `Sealed Benchmark`, `Unsealed Benchmark`, `Sealed Virtual Benchmark`, `Sealed Benchmark No Inheritance` and `Unsealed Benchmark No Inheritance` are marked as "ZeroMeasurement", highlighting that the methods being benchmarked are executing so quickly that they are indistinguishable from empty methods. This means that we cannot reliably mesure these methods, and the speed can vary between different runs.


## Performance


## Sealed By Default

### Benefits

* Sealed classes can offer some performance benefits, especially when a class has overwritten virtual methods.
* Encourages developers to think more about the design of classes and how they are intended to be consumed.
* Sealed classes can easily be unsealed if design requirements change. 

### Quotes

> I know many people (including myself) who believe that classes should indeed be sealed by default.   
>  – <cite>[Jon Skeet, 2008](https://stackoverflow.com/a/252738/18039381)</cite>

> Which is why sealed should be the default for classes, of course.  
> – <cite>[Jon Skeet, 2018](https://twitter.com/jonskeet/status/1037458061097684992)</cite>

> Please yes!  
> – <cite>[Random HN Reader](https://news.ycombinator.com/item?id=18914605)</cite>

### Aditional Resources

[Why all your classes should be sealed by default in C#](https://www.youtube.com/watch?v=d76WWAD99Yo) By Nick Chapsas
[Pendulum swing: sealed by default](https://blog.ploeh.dk/2021/03/08/pendulum-swing-sealed-by-default/) By Mark Seemann

## Unsealed By Default

### Benefits 

* Unsealed classes can be extended, allowing developers to build upon existing functionality.
* Using the sealed keyword selectively, emphasizes clear intent that a class should not be extended, making the keyword more meaningful and impactful. 

### Quotes 

> There is quite a lot of controversy about whether sealing is a good idea.  
> Those with a [DirectingAttitude](https://martinfowler.com/bliki/DirectingAttitude.html) like be very careful about what classes and features are available for overriding and confine extenders to only override things they consider safe.  
> Those with an [EnablingAttitude](https://martinfowler.com/bliki/EnablingAttitude.html) take the view that they cannot predict what extenders may need to do and thus shouldn't deny them the flexibility - extenders can override whatever they like, but they have to take the responsibility to be careful.  
> As in most things I tend to being an enabler.  
> – <cite>[Martin Fowler](https://martinfowler.com/bliki/Seal.html)</cite>

> Please, no! This shouldn't be the _default_ - it's a constant bugbear of mine where I want to extend a class from a library, and I can't because it's been sealed for no good reason.  
> – <cite>[Random HN reader](https://news.ycombinator.com/item?id=18914228)</cite>

> DO NOT seal classes without having a good reason to do so.  
> – <cite>[MSDN, 2022](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/sealing)</cite>

> #final #java I use it for constants, but nothing else. I don't declare classes are arguments final.
> – <cite>[Uncle Bob, 2011](https://twitter.com/unclebobmartin/status/71679793367744512)</cite>

### Additional Resources

[Framework design guidelines - Sealing](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/sealing)