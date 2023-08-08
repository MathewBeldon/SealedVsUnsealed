# Sealed By Default, Or Not. 

The choice between sealed and unsealed classes is not merely a syntactic one; it can have profound implications on the design, performance, and maintainability of a codebase. Most OOP languages, such as C#, provide explicit keywords to define classes as sealed, while in others, such as Swift, the concept is implicit.

## Contents
* [What Is A Sealed Class](#what-is-a-sealed-class)
* [What Is An Unsealed Class](#what-is-an-unsealed-class)
* [Benchmarks](#benchmarks)
    * [How To Run](#how-to-run)
* [Performance Tests](#performance-tests)
    * [K6 Results](#k6-results)
    * [How To Run](#how-to-run-1)
* [Sealed By Default](#sealed-by-default)
    * [Benefits](#benefits)
    * [Quotes](#quotes)
    * [Additional Resources](additional-resources)
* [Unsealed By Default](#unsealed-by-default)
    * [Benefits](#benefits-1)
    * [Quotes](#quotes-1)
    * [Additional Resources](additional-resources-1)
* [Conclusion](#conclusion)

## What Is A Sealed Class

A sealed class is a class that cannot be inherited. It's a final declaration of a class, ensuring that no other class can extend it. Sealed classes provide a level of security and predictability in the code, as they prevent further modifications to the class hierarchy. They can be particularly useful when you want to encapsulate specific behaviour without the risk of unintended alterations.

## What Is An Unsealed Class

An unsealed class is open to inheritance, allowing other classes to extend it. This flexibility can lead to more dynamic and extensible code structures, enabling developers to build upon existing functionality.

## Benchmarks

These benchmarks attempt to reproduce the results from the dotnet 6 performance improvements [blog post](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#peanut-butter)   
   
_The below classes can be found [here](SealedVsUnsealed.Benchmark/Models)_   

|                               Method |      Mean |     Error |    StdDev |    Median |
|------------------------------------- |----------:|----------:|----------:|----------:|
|                     'Base Benchmark' | 1.2395 ns | 0.0474 ns | 0.0466 ns | 1.2088 ns |
|   'Sealed Benchmark No Inheritance*' | 0.0019 ns | 0.0048 ns | 0.0042 ns | 0.0000 ns |
| 'Unsealed Benchmark No Inheritance*' | 0.0043 ns | 0.0065 ns | 0.0051 ns | 0.0030 ns |
|                  'Sealed Benchmark*' | 0.0079 ns | 0.0124 ns | 0.0116 ns | 0.0000 ns |
|                'Unsealed Benchmark*' | 0.0188 ns | 0.0198 ns | 0.0212 ns | 0.0132 ns |
|          'Sealed Virtual Benchmark*' | 0.0143 ns | 0.0185 ns | 0.0173 ns | 0.0076 ns |
|         'Unsealed Virtual Benchmark' | 1.0502 ns | 0.0066 ns | 0.0055 ns | 1.0511 ns |
|           'Sealed Is Type Benchmark' | 0.2032 ns | 0.0043 ns | 0.0034 ns | 0.2022 ns |
|         'Unsealed Is Type Benchmark' | 1.7030 ns | 0.0316 ns | 0.0295 ns | 1.6929 ns |

The results for `Sealed Benchmark`, `Unsealed Benchmark`, `Sealed Virtual Benchmark`, `Sealed Benchmark No Inheritance` and `Unsealed Benchmark No Inheritance` (denoted by *) are marked as "ZeroMeasurement", highlighting that the methods being benchmarked are executing so quickly that they are indistinguishable from empty methods. This means that we cannot reliably measure these methods, and the speed can vary between different runs.

### How To Run

From within the SealedVsUnsealed.Benchmark folder
```
dotnet run --configuration Release
```

## Performance Tests

The below performance results compare different ways of calling methods that add two numbers together, one virtual method and one non-virtual method, each then called through mediator.  
    
_Source for the controllers can be found [here](/SealedVsUnsealed.Performance/Controllers/TestController.cs)_   
_Source for the performance tests can be found [here](SealedVsUnsealed.Performance/k6/run.js)_   

### K6 Results

|                               Method |  Requests |  Requests/s |  Difference |
|------------------------------------- |----------:|------------:|------------:|
|                             'Sealed' |   1993252 |     66441/s |       0.51% |
|                           'Unsealed' |   1983031 |     66101/s |      -0.51% |
|                    'Sealed Mediator' |   1973171 |     65772/s |       0.43% |
|                  'Unsealed Mediator' |   1964774 |     65492/s |      -0.43% |
|                     'Sealed Virtual' |   1958160 |     65272/s |       1.56% |
|                   'Unsealed Virtual' |   1927837 |     64261/s |      -1.56% |
|            'Sealed Virtual Mediator' |   1866520 |     62217/s |       6.31% |
|          'Unsealed Virtual Mediator' |   1752260 |     58408/s |      -6.31% |

<details>
  <summary>Full results</summary>
  
  ```

          /\      |‾‾| /‾‾/   /‾‾/
     /\  /  \     |  |/  /   /  /
    /  \/    \    |     (   /   ‾‾\
   /          \   |  |\  \ |  (‾)  |
  / __________ \  |__| \__\ \_____/ .io

  execution: local
     script: k6/loadTest.js
     output: -

  scenarios: (100.00%) 8 scenarios, 200 max VUs, 4m7s max duration (incl. graceful stop):
           * unsealedVirtualMediator: 200 looping VUs for 30s (exec: unsealedVirtualMediator)
           * sealedVirtualMediator: 200 looping VUs for 30s (exec: sealedVirtualMediator, startTime: 31s)
           * unsealedVirtual: 200 looping VUs for 30s (exec: unsealedVirtual, startTime: 1m2s)
           * sealedVirtual: 200 looping VUs for 30s (exec: sealedVirtual, startTime: 1m33s)
           * unsealed: 200 looping VUs for 30s (exec: unsealed, startTime: 2m4s)
           * sealed: 200 looping VUs for 30s (exec: sealed, startTime: 2m35s)
           * unsealedMediator: 200 looping VUs for 30s (exec: unsealedMediator, startTime: 3m6s)
           * sealedMediator: 200 looping VUs for 30s (exec: sealedMediator, startTime: 3m37s)


running (4m07.0s), 000/200 VUs, 14281122 complete and 1600 interrupted iterations
unsealedVirtualMediator ✓ [======================================] 200 VUs  30s
sealedVirtualMediator   ✓ [======================================] 200 VUs  30s
unsealedVirtual         ✓ [======================================] 200 VUs  30s
sealedVirtual           ✓ [======================================] 200 VUs  30s
unsealed                ✓ [======================================] 200 VUs  30s
sealed                  ✓ [======================================] 200 VUs  30s
unsealedMediator        ✓ [======================================] 200 VUs  30s
sealedMediator          ✓ [======================================] 200 VUs  30s

     ✓ status code should be 200

     checks...............................: 100.00%  ✓ 15418988     ✗ 0
     data_received........................: 2.5 GB   10 MB/s
     data_sent............................: 1.5 GB   6.3 MB/s
     http_req_blocked.....................: avg=1.49µs   min=0s med=0s     max=66.44ms  p(90)=0s     p(95)=0s
     http_req_connecting..................: avg=84ns     min=0s med=0s     max=25.52ms  p(90)=0s     p(95)=0s
     http_req_duration....................: avg=2.93ms   min=0s med=2.99ms max=134.38ms p(90)=4ms    p(95)=4.34ms
       { expected_response:true }.........: avg=2.93ms   min=0s med=2.99ms max=134.38ms p(90)=4ms    p(95)=4.34ms
     http_req_failed......................: 0.00%    ✓ 0            ✗ 15419018
     http_req_receiving...................: avg=24.75µs  min=0s med=0s     max=116.68ms p(90)=0s     p(95)=0s
     http_req_sending.....................: avg=7.95µs   min=0s med=0s     max=102.26ms p(90)=0s     p(95)=0s
     http_req_tls_handshaking.............: avg=0s       min=0s med=0s     max=0s       p(90)=0s     p(95)=0s
     http_req_waiting.....................: avg=2.9ms    min=0s med=2.99ms max=134.38ms p(90)=4ms    p(95)=4.29ms
     http_reqs............................: 15419018 62423.760886/s
     iteration_duration...................: avg=3.1ms    min=0s med=3ms    max=231.56ms p(90)=4ms    p(95)=4.7ms
     iterations...........................: 15418985 62423.627286/s
     Sealed Counter.......................: 1993252  8069.663466/s
     Sealed Duration......................: avg=2.856529 min=0  med=2.9996 max=95.3019  p(90)=3.9936 p(95)=4.1124
     Sealed Mediator Counter..............: 1973171  7988.365711/s
     Sealed Mediator Duration.............: avg=2.8589   min=0  med=2.9997 max=119.1916 p(90)=3.9953 p(95)=4.0759
     Sealed Virtual Counter...............: 1958160  7927.593808/s
     Sealed Virtual Duration..............: avg=2.904552 min=0  med=2.9998 max=104.7132 p(90)=3.9999 p(95)=4.2312
     Sealed Virtual Mediator Counter......: 1866520  7556.590061/s
     Sealed Virtual Mediator Duration.....: avg=3.022377 min=0  med=2.9999 max=91.5601  p(90)=4.0012 p(95)=4.5607
     Unsealed Counter.....................: 1983031  8028.283836/s
     Unsealed Duration....................: avg=2.869557 min=0  med=2.9997 max=92.4925  p(90)=3.9995 p(95)=4.1528
     Unsealed Mediator Counter............: 1964774  7954.370529/s
     Unsealed Mediator Duration...........: avg=2.894612 min=0  med=2.9997 max=134.3892 p(90)=3.9996 p(95)=4.1571
     Unsealed Virtual Counter.............: 1927837  7804.831405/s
     Unsealed Virtual Duration............: avg=2.93878  min=0  med=2.9998 max=94.942   p(90)=4.0002 p(95)=4.3455
     Unsealed Virtual Mediator Counter....: 1752260  7094.00944/s
     Unsealed Virtual Mediator Duration...: avg=3.191408 min=0  med=3.0001 max=94.7954  p(90)=4.301  p(95)=5.001
     vus..................................: 200      min=0          max=200
     vus_max..............................: 200      min=200        max=200
  ```
</details>

### How To Run

From within the SealedVsUnsealed.Performance folder   
To start the server   
```
dotnet run --configuration Release
```

To start the performance tests   
```
k6 run k6/run.js
```
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
> – <cite>[Random HN Reader, 2019](https://news.ycombinator.com/item?id=18914605)</cite>

### Additional Resources

[Pendulum swing: sealed by default](https://blog.ploeh.dk/2021/03/08/pendulum-swing-sealed-by-default/) By Mark Seemann   
[Why all your classes should be sealed by default in C#](https://www.youtube.com/watch?v=d76WWAD99Yo) By Nick Chapsas   

## Unsealed By Default

### Benefits 

* Unsealed classes can be extended, allowing developers to build upon existing functionality.
* Using the sealed keyword selectively, emphasizes clear intent that a class should not be extended, making the keyword more meaningful and impactful. 

### Quotes 

> DO NOT seal classes without having a good reason to do so.  
> – <cite>[MSDN, 2022](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/sealing)</cite>

> #final #java I use it for constants, but nothing else. I don't declare classes are arguments final.   
> – <cite>[Uncle Bob, 2011](https://twitter.com/unclebobmartin/status/71679793367744512)</cite>

> Please, no! This shouldn't be the _default_ - it's a constant bugbear of mine where I want to extend a class from a library, and I can't because it's been sealed for no good reason.  
> – <cite>[Random HN reader, 2019](https://news.ycombinator.com/item?id=18914228)</cite>

### Additional Resources

[Framework design guidelines - Sealing](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/sealing) By Microsoft  
[Seal](https://martinfowler.com/bliki/Seal.html) By Martin Fowler

## Conclusion

After going through all this, I still believe that classes should be sealed by default. While the performance benefits are often minimal, sealing a class provides clear guidance on its intended use. This approach promotes a more modular and decoupled codebase by favouring composition over inheritance.