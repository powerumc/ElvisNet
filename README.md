# ElvisNet
Use Elvis Expression is C# 6.0 spec under C# 6.0

## Basic

```C#
  Expression<Func<int>> expression = () => Environment.CommandLine.Length;
  var expect = Elvis.SafeNull(expression);
```

```C#
  Func<int> func = () => Environment.CommandLine.Length;
  var expect = Elvis.SafeNull(func);
```  
## Extension Methods

```C#
  var person = new Person();
  // ...
  
  person.SafeNull();
  
  person.SafeNull(o => o.Name.First.ToString());
```
