# F# Lambda calculus parser & IKBCS base expression converter
* IKBCS-Base converter module algorithm is based on Dr. Mayer Goldberg algorithm found here: http://www.little-lisper.org/website/files/lambda-calculus-tutorial.pdf
* This is the solution for exercise 74 (page 60) from the above book.
* Course: Advanced Programming Methods 
* Lecturer: Dr. Mayer Goldberg
* Ben-Gurion University of the Negev, 2016 Sems.B
* The parser is based on FParsec (parser combinator library for F#): http://www.quanttec.com/fparsec/

# Examples
Examples for valid lambda-expression syntax:
* "lambda abc.(cbacba)"
* "lambda p.(p lambda x.lambda y.x)"
* "lambda xyz.lambda d.(x(y(zd)))"
* "lambda x.lambda y.(x(x(x(x(xy)))))"
* "lambda x.lambda f.(f((xx)f))"
