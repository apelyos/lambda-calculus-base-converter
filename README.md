# F# Lambda calculus parser & IKBCS base expression converter

IKBCS-Base converter is based on Dr. Mayer Goldberg algorithm found here:
http://www.little-lisper.org/website/files/lambda-calculus-tutorial.pdf
Advanced Programming Methods Course, 
Ben-Gurion University of the Negev, 2016

The parser is based on FParsec (parser combinator library for F#)
http://www.quanttec.com/fparsec/

Examples for valid lambda-expressions:
* "lambda abc.(cbacba)"
* "lambda p.(p lambda x.lambda y.x)"
* "lambda xyz.lambda d.(x(y(zd)))"
* "lambda x.lambda y.(x(x(x(x(xy)))))"
* "lambda x.lambda f.(f((xx)f))"
