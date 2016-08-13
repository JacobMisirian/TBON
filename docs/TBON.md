# Text-Based-Object-Notation (TBON) Description and Specification.

TBON is a method for storing data such as configuration, databases, or save states
in a text based format that can be understood and modified easily by
both a computer and a human operator. TBON is Object Notated, meaning
that a so-called ```class``` can contain multiple children, referred to
as ```objects```, who in turn can have an infinite amount of ```attributes```
stored in a key-value format.

## A Simple TBON Database.

Say there is a company that wants to store information on their employees
in a text file. There would need to be a class called ```Employee``` that
contains all the objects foreach employee with attributes such as their name,
pay, and position. Objects in TBON all have names, so we can use the employee
ID to name each object.

```
Employees {
    1:(
        firstName : "John"
        lastName : "Smith"
        pay : "50000"
    )
    2:(
        firstName : "Jane"
        lastName : "Doe"
        pay : "55000"
    )
}
```

The first line of this code defines a class named ```Employees```. You will
notice that a class begins and ends with a curly brace { and }. From there
is the first object declaration, an object named ```1``` (the employee ID
in this case). ```1``` is declared with the name, followed by a colon, followed
by an open parentheses. From there the attributes are defined in key : value
format.

## Prototyping

TBON supports what is called prototyping. It allows someone writing TBON files
to simplify, organize, and reduce the verbosity of the classes they are writing.
Prototyping works where a list of keys is defined next to the class name, then object
children of the class do not have to use the key : value format, instead just listing
the values that match the keys in the prototype.

Here is the example above written using prototyping:
```
Employees (firstName, lastName, pay) {
    1:(
        "John", "Smith", "50000" 
    )
    2:(
        "Jane", "Doe", "55000" 
    )
}
```

On the first line you can see that the class name still comes first, followed
by a leading parentheses with a list of all the keys each employee object will
need to define. Then inside of the object declarations it lists the values that
match up with the prototype.

## Arrays

Until this point the examples have centered around having strings be the values
in our TBON code. However, you can have a list, or array of these strings
be the value for a TBON object. Arrays start with a [, contain strings seperated
by an optional comma, and end with a ].

We can update our employee class to include a field for previous salaries that
will have a value of an array type:
```
Employees (firstName, lastName, pay, pastPay) {
    1:(
        "John", "Smith", "50000", ["45000", "52000", "43000"] 
    )
    2:(
        "Jane", "Doe", "55000", ["56000", "52000"] 
    )
}
```

The values inside the [ ] are all one array that is the value for ```pastPay```
