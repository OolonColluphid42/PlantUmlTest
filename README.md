# PlantUmlTests

This repo demostrates two ways of interacting with PlantUml from DotNet:

1. IKVM

   This wraps the PlantUml jar with [IKVM](https://github.com/ikvmnet/ikvm) to enable it to run in-process and it's accessed directly from
   the DotNet code. 

2. WebServer

   This starts the PlantUml jar in it's webserver mode and demonstrates POSTing a diagram to its
   (undocumented - the PlantUml website is rather out of date) `/render` endpoint.

In both cases, these projects just create a very simple UML class diagram and write the output to
`%TMP%`.

## Compiling and Running

Before you can compile and run these examples, you'll need to put a copy of [`plantuml-1.2024-7.jar`](https://github.com/plantuml/plantuml/releases/download/v1.2024.8/plantuml-1.2024.8.jar) in the 
main directory of each project. 


