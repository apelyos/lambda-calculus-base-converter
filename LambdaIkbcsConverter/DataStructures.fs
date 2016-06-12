module Types

    type raw_lexp = 
        | RVar of string
        | RApplic of raw_lexp list
        | RLambda of (string list) * raw_lexp

    type ikbcs = 
        | I | K | B | C | S ;;

    type lexp =
        | Var of string
        | Applic of lexp * lexp
        | Lambda of string * lexp
        | Base of ikbcs