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
    (1:
        firstName : "John"
        lastName : "Smith"
        pay : "50000"
    )
    (2:
        firstName : "Jane"
        lastName : "Doe"
        pay : "55000"
    )
}
```
