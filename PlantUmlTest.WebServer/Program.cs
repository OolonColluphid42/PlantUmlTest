// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;



using var plantUmlProcess = Process.Start("java.exe",
    "-jar plantuml-1.2024.7.jar -picoweb:8000:localhost");

using var client = HttpClientFactory.Create();

const string diagram = @"@startuml test
!pragma teoz

class Foo { 
}

class Bar {

}

Foo *-- Bar

@enduml";

var req = new RenderRequest(["-Tpng"], diagram);

using var json = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json");

var response = await client.PostAsync("http://localhost:8000/render", json);

var data = await response.Content.ReadAsByteArrayAsync();

var filename = Path.Join(Environment.GetEnvironmentVariable("TMP"), "test.png");

await File.WriteAllBytesAsync(filename, data);

plantUmlProcess.Kill();

record RenderRequest(string[] options, string source);
