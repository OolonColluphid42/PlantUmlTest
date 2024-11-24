// See https://aka.ms/new-console-template for more information
using java.io;

using net.sourceforge.plantuml;

const string diagram = @"@startuml test
!pragma teoz

class Foo { 
}

class Bar {

}

Foo *-- Bar

@enduml";

SourceStringReader ssr = new (diagram);

ByteArrayOutputStream os = new ();

var desc = ssr.outputImage(os, new FileFormatOption(FileFormat.PNG));

os.close();

byte[] bytes = os.toByteArray();

var filename = Path.Join(Environment.GetEnvironmentVariable("TMP"), "test2.png");

await System.IO.File.WriteAllBytesAsync(filename, bytes);


