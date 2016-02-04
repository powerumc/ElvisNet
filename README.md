# ElvisNet
Use Elvis Expression is C# 6.0 spec under C# 6.0

## Basic

  Expression<Func<int>> expression = () => Environment.CommandLine.Length;
  var expect = Elvis.SafeNull(expression);
  
  Func<int> func = () => Environment.CommandLine.Length;
  var expect = Elvis.SafeNull(func);
  
## Extension Methods

  var person = new Person; 
  // ...
  
  person.SafeNull();
  
  person.SafeNull(o => o.Name.First.ToString());
