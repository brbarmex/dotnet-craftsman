# Value object

The '<b>Value Object</b>' is an object that represents a value! basically that. :)
Value Object is mentioned by Eric Evans in his famous <b>DDD</b> book because value objects help in building strong domains avoiding future problems in their modeling and the famous "code smell bad"

# Characteristics

- They are immutable.
- They have no identity.
- Are small.
- Avoids the use of primitive obsession.
- Help with documentation.

# See in practice

Below, I show some of the most common fictional examples today.


``` cs 

string document = "132.545.983-32";

var documentIsValid = CPFHelper.Validate(cpf);

if (documentIsValid)
{
    var cpfFormated = CPFHelper.Format(cpf);
    Console.WriteLine(cpfFormated);

    //output: 13254598332
}

```

or

``` cs

public class Customer
{
  public string Id { get; set; }
  
  private readonly string _cpf;
  public string Cpf 
  { 
    get { return _cpf; } 
    set 
    { 
        var documentCpf = CPFHelper.Validate(value);

        if(documentCpf)
        {
            _cpf = CPFHelper.Format(value); 
        }
        else
        {
            throw new CpfException("Any stupid message.");
        }
        
    } 
  }
}

```


## Okay, but what's wrong with the code snippet above? 

If you are using this in your modeling software, you will need to study a little more about good practice and OOP.

> Reader: But Bruno, what is the problem with the section above bro?
> Author: It seems harmless but it is not, there are those who disagree but this excerpt is a "code smell bad" and that's it !!!

Let's analyze the reference pass for the variable ``document``. As much as there are better ways of implementation in the example above, the result will be the same (big shit).

Realize that the value is from a document and not from a primitive type of string type, and to manipulate that value you always end up needing a
Standard or auxiliary utility (or rather, non-standard). If you are using this type of pattern (anti-pattern) it means that your modeling went to the hole because something was born wrong and is growing wrong.

We will try to predict the future and imagine the possible problems of this use.

- I predict that you will have duplication of logic to handle this value. At some point you will find someone manipulating
the value which in turn will not be the Helper or Ultil class.

- When the above prophecy happens, armageddon will be near because you will lose control of whoever manipulates this value.

- The value will be assigned by variables with bizarre names, example: ``` _ ```, ``` cpf ```, ``` value ```, ``` customerPerson ```, etc ... Now imagine your system growing and being used and manipulated by 100 methods in 200 classes.

Writing ... will soon be finished ....