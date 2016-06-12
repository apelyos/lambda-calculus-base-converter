#indent "off"

module Tests

open Types;;

let tests = 
    [
      Lambda ("x",
       Lambda ("y",
        Lambda ("z",
         Lambda ("w",
          Applic (Applic (Var "x", Var "y"),
           Applic (Applic (Var "x", Var "z"), Var "w"))))))
    ;
      Lambda ("x",
       Lambda ("y",
        Applic (Applic (Applic (Var "x", Var "x"), Applic (Var "y", Var "y")),
         Applic (Applic (Var "x", Var "y"), Var "x"))))
    ; Lambda ("x", Applic (Var "x", Var "x"))
    ; Lambda ("x", Applic (Applic (Var "x", Var "x"), Var "x"))
    ;
      Lambda ("x", Applic (Applic (Applic (Var "x", Var "x"), Var "x"), Var "x"))
    ;
      Lambda ("x",
       Applic (Applic (Applic (Applic (Var "x", Var "x"), Var "x"), Var "x"),
        Var "x"))
    ;
      Lambda ("x", Lambda ("y", Lambda ("z", Lambda ("w", Var "x"))))
    ;
      Lambda ("x", Lambda ("y", Lambda ("z", Lambda ("w", Var "y"))))
    ;
      Lambda ("x", Lambda ("y", Lambda ("z", Lambda ("w", Var "z"))))
    ;
      Lambda ("x", Lambda ("y", Lambda ("z", Lambda ("w", Var "w"))))
    ;
      Lambda ("x",
       Lambda ("y",
        Lambda ("z",
         Applic (Applic (Var "x", Applic (Applic (Var "y", Var "y"), Var "z")),
          Applic (Applic (Var "z", Var "y"), Var "z")))))
    ;
      Lambda ("x",
       Lambda ("f",
        Applic (Var "f", Applic (Applic (Var "x", Var "x"), Var "f"))))
    ; Lambda ("x", Lambda ("y", Applic (Var "y", Var "x")))
    ;
      Lambda ("x",
       Lambda ("p",
        Lambda ("q",
         Applic (Applic (Var "p", Var "x"), Applic (Var "q", Var "x")))))
    ;
      Lambda ("f",
       Applic (Lambda ("x", Applic (Var "f", Applic (Var "x", Var "x"))),
        Lambda ("x", Applic (Var "f", Applic (Var "x", Var "x")))))
    ;
      Lambda ("x",
       Lambda ("y",
        Applic (Var "x",
         Applic (Var "x",
          Applic (Var "x", Applic (Var "x", Applic (Var "x", Var "y")))))))
    ;
      Lambda ("a",
       Lambda ("b",
        Lambda ("s",
         Lambda ("z",
          Applic (Applic (Var "a", Var "s"),
           Applic (Applic (Var "b", Var "s"), Var "z"))))))
    ;
      Lambda ("a",
       Lambda ("b",
        Lambda ("s",
         Lambda ("z",
          Applic (Applic (Var "b", Applic (Var "a", Var "s")), Var "z")))))
    ;
      Lambda ("x",
       Lambda ("y", Lambda ("z", Applic (Applic (Var "z", Var "x"), Var "y"))))
    ;
      Lambda ("p", Applic (Var "p", Lambda ("x", Lambda ("y", Var "x"))))
    ;
      Lambda ("p", Applic (Var "p", Lambda ("x", Lambda ("y", Var "y"))))
    ; Lambda ("x", Applic (Var "x", Applic (Var "x", Var "x")))
    ;
      Lambda ("x",
       Applic (Applic (Var "x", Applic (Var "x", Var "x")),
        Applic (Var "x", Applic (Applic (Var "x", Var "x"), Var "x"))))
    ;
      Lambda ("x",
       Applic
        (Applic (Applic (Var "x", Applic (Var "x", Var "x")),
          Applic (Var "x", Applic (Applic (Var "x", Var "x"), Var "x"))),
        Applic (Var "x",
         Applic (Applic (Applic (Var "x", Var "x"), Var "x"), Var "x"))))
    ;
      Lambda ("x",
       Lambda ("y",
        Lambda ("z",
         Lambda ("w",
          Applic (Applic (Applic (Var "w", Var "x"), Var "y"), Var "z")))))
    ];;